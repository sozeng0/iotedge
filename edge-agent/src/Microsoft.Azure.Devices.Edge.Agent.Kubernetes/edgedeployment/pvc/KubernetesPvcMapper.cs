// Copyright (c) Microsoft. All rights reserved.
namespace Microsoft.Azure.Devices.Edge.Agent.Kubernetes.EdgeDeployment.Pvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using k8s.Models;
    using Microsoft.Azure.Devices.Edge.Agent.Docker.Models;
    using Microsoft.Azure.Devices.Edge.Util;

    public class KubernetesPvcMapper : IKubernetesPvcMapper
    {
        readonly Option<string> persistentVolumeName;
        readonly Option<string> storageClassName;
        readonly uint persistentVolumeClaimSizeMb;

        public KubernetesPvcMapper(
            string persistentVolumeName,
            string storageClassName,
            uint persistentVolumeClaimSizeMb)
        {
            this.persistentVolumeName = Option.Maybe(persistentVolumeName)
                .Filter(p => !string.IsNullOrWhiteSpace(p));
            this.storageClassName = Option.Maybe(storageClassName);
            this.persistentVolumeClaimSizeMb = persistentVolumeClaimSizeMb;
        }

        public Option<List<V1PersistentVolumeClaim>> CreatePersistentVolumeClaims(KubernetesModule module, IDictionary<string, string> labels) =>
            module.Config.CreateOptions.HostConfig
                .FlatMap(hostConfig => Option.Maybe(hostConfig.Mounts))
                .Map(mounts => mounts.Where(this.ShouldCreatePvc).Select(mount => this.ExtractPvc(module, mount, labels)).ToList())
                .Filter(mounts => mounts.Any());

        bool ShouldCreatePvc(Mount mount)
        {
            if (!mount.Type.Equals("volume", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            return this.storageClassName.HasValue || this.persistentVolumeName.HasValue;
        }

        V1PersistentVolumeClaim ExtractPvc(KubernetesModule module, Mount mount, IDictionary<string, string> labels)
        {
            string volumeName = KubeUtils.SanitizeK8sValue(mount.Source);
            string pvcName = KubernetesModule.PvcName(module, mount);
            bool readOnly = mount.ReadOnly;

            var persistentVolumeClaimSpec = new V1PersistentVolumeClaimSpec()
            {
                // What happens if the PV access mode is not compatible with the access we're requesting?
                // Deployment will be created and will be in a failed state. The user will see this as
                // module running == false.
                AccessModes = new List<string> { readOnly ? "ReadOnlyMany" : "ReadWriteMany" },
                Resources = new V1ResourceRequirements()
                {
                    Requests = new Dictionary<string, ResourceQuantity>() { { "storage", new ResourceQuantity($"{this.persistentVolumeClaimSizeMb}Mi") } }
                },
            };
            if (this.persistentVolumeName.HasValue)
            {
                string pvName = this.persistentVolumeName.OrDefault();
                if (pvName != volumeName)
                {
                    throw new InvalidModuleException(string.Format("The mount name {0} has to be the same as the PV name {1}", volumeName, pvName));
                }

                persistentVolumeClaimSpec.VolumeName = volumeName;
            }

            if (this.storageClassName.HasValue)
            {
                persistentVolumeClaimSpec.StorageClassName = this.storageClassName.OrDefault();
            }

            var pvcMeta = new V1ObjectMeta(
                name: pvcName,
                labels: labels,
                ownerReferences: module.Owner.ToOwnerReferences());

            return new V1PersistentVolumeClaim(metadata: pvcMeta, spec: persistentVolumeClaimSpec);
        }

        public void UpdatePersistentVolumeClaim(V1PersistentVolumeClaim to, V1PersistentVolumeClaim from)
        {
            to.Metadata.ResourceVersion = from.Metadata.ResourceVersion;
        }
    }
}
