from __future__ import print_function
import logging
import docker

class EdgeDockerClient(object):
    _DOCKER_INFO_OS_TYPE_KEY = 'OSType'

    def __init__(self):
        self._client = docker.DockerClient.from_env()
        self._api_client = docker.APIClient()

    def login(self, addr, uname, pword):
        logging.info('Logging into Registry ' + addr \
                     + ' using username ' + uname)
        try:
            self._client.login(username=uname, password=pword, registry=addr)
        except docker.errors.APIError as ex:
            logging.error('Could Not Login To Registry ' + addr \
                      + ' using username ' + uname)
            print(ex)
            raise

    def get_os_type(self):
        try:
            info = self._client.info()
            return info[self._DOCKER_INFO_OS_TYPE_KEY]
        except docker.errors.APIError as ex:
            logging.error('Could Not Obtain Docker Info')
            print(ex)
            raise

    def pull(self, image, username, password):
        logging.info('Executing Docker Pull For Image: ' + image)
        is_updated = True
        old_tag = None
        try:
            inspect_dict = self._api_client.inspect_image(image)
            old_tag = inspect_dict['Id']
            logging.info('Image Exists Locally. Tag: ' + old_tag)
        except docker.errors.APIError as ex:
            logging.info('Docker image not found locally:' + image)

        try:
            auth_dict = None
            if username:
                auth_dict = {'username': username, 'password': password}
            pull_result = self._client.images.pull(image, auth_config=auth_dict)
            logging.info('Pulled Image: ' + str(pull_result))
            if old_tag:
                inspect_dict = self._api_client.inspect_image(image)
                new_tag = inspect_dict['Id']
                logging.debug('Post Pull Image Tag: ' + new_tag)
                if new_tag == old_tag:
                    logging.debug('Image is up to date.')
                    is_updated = False
        except docker.errors.APIError as ex:
            logging.error('Docker Pull, Inspect Error For Image:' \
                          + image + ' ' + str(ex))
            raise

        return is_updated

    def get_container_by_name(self, container_name):
        logging.debug('Finding container ' + container_name \
                      + ' in list of containers')
        try:
            return self._client.containers.get(container_name)
        except docker.errors.APIError as ex:
            logging.error('Could not find container ' + container_name)
            print (ex)
            return None

    def start(self, container_name):
        logging.info('Starting Container:' + container_name)
        try:
            containers = self._client.containers.list(all=True)
            for container in containers:
                if container_name == container.name:
                    container.start()
        except docker.errors.APIError as ex:
            logging.error('Could Not Start Container ' + container_name)
            print(ex)
            raise

    def restart(self, container_name, timeout_int=5):
        logging.info('Restarting Container:' + container_name)
        try:
            containers = self._client.containers.list(all=True)
            for container in containers:
                if container_name == container.name:
                    container.restart(timeout=timeout_int)
        except docker.errors.APIError as ex:
            logging.error('Could Not Retart Container ' + container_name)
            print(ex)
            raise

    def stop(self, container_name):
        logging.info('Stopping Container:' + container_name)
        try:
            containers = self._client.containers.list(all=True)
            for container in containers:
                if container_name == container.name:
                    container.stop()
        except docker.errors.APIError as ex:
            logging.error('Could Not Stop Container ' + container_name)
            print(ex)
            raise

    def status(self, container_name):
        try:
            result = None
            containers = self._client.containers.list(all=True)
            for container in containers:
                if container_name == container.name:
                    result = container.status
            return result
        except docker.errors.APIError as ex:
            logging.error('Error Observed While Checking Status For:'
                          + container_name)
            print(ex)
            raise

    def remove(self, container_name):
        logging.info('Removing Container:' + container_name)
        try:
            containers = self._client.containers.list(all=True)
            for container in containers:
                if container_name == container.name:
                    container.remove()
        except docker.errors.APIError as ex:
            logging.error('Could Not Remove Container ' + container_name)
            print(ex)
            raise

    def stop_by_label(self, label):
        logging.info('Stopping Containers By Label:' + label)
        try:
            filter_dict = {'label': label}
            containers = self._client.containers.list(all=True,
                                                      filters=filter_dict)
            for container in containers:
                container.stop()
        except docker.errors.APIError as ex:
            logging.error('Could Not Stop Containers By Label ' + label)
            print(ex)
            raise
        return

    def remove_by_label(self, label):
        logging.info('Removing Containers By Label:' + label)
        try:
            filter_dict = {'label': label}
            containers = self._client.containers.list(all=True,
                                                      filters=filter_dict)
            for container in containers:
                container.remove()
        except docker.errors.APIError as ex:
            logging.error('Could Not Remove Containers By Label ' + label)
            print(ex)
            raise
        return

    def create_network(self, network_name):
        logging.info('Creating Network:' + network_name)
        create_network = False
        try:
            networks = self._client.networks.list(names=[network_name])
            if networks:
                num_networks = len(networks)
                if num_networks == 0:
                    create_network = True
            else:
                create_network = True
            if create_network:
                self._client.networks.create(network_name, driver="bridge")
        except docker.errors.APIError as ex:
            logging.error('Could Not Create Docker Network:' + network_name)
            print(ex)
            raise

    def run(self, image, container_name, detach_bool, env_dict, nw_name,
            ports_dict, volume_dict, log_config_dict):
        try:
            logging.info('Executing docker run ' + image
                     + ' name:' + container_name
                     + ' detach:' + str(detach_bool)
                     + ' network:' + nw_name)
            for key in list(env_dict.keys()):
                logging.info(' env: ' + key + ':' + env_dict[key])
            for key in list(ports_dict.keys()):
                logging.info(' port: ' + key + ':' + str(ports_dict[key]))
            for key in list(volume_dict.keys()):
                logging.info(' volume: ' + key + ':'
                         + volume_dict[key]['bind']
                         + ', ' + volume_dict[key]['mode'])
            self._client.containers.run(image,
                                        detach=detach_bool,
                                        environment=env_dict,
                                        name=container_name,
                                        network=nw_name,
                                        ports=ports_dict,
                                        volumes=volume_dict,
                                        log_config=log_config_dict)
        except docker.errors.ContainerError as ex_ctr:
            logging.error(container_name + ' Container Exited With Errors!')
            print(ex_ctr)
            raise
        except docker.errors.ImageNotFound as ex_img:
            logging.error('Could Not Execute Docker Run. Image Not Found:' \
                          + image)
            print(ex_img)
            raise
        except docker.errors.APIError as ex:
            logging.error('Could Not Execute Docker Run For Image:' + image)
            print(ex)
            raise