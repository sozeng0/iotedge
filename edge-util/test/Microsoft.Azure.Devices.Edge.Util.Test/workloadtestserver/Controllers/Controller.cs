// Copyright (c) Microsoft. All rights reserved.
namespace Microsoft.Azure.Devices.Edge.Util.Test.Common.WorkloadTestServer.Controllers
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.16.1.0 (NJsonSchema v9.10.41.0 (Newtonsoft.Json v9.0.0.0))")]
    public interface IController
    {
        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module on whose behalf the payload will be signed. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="payload">The data to be signed.</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<SignResponse> SignAsync(string api_version, string name, string genid, SignRequest payload);

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module on whose behalf the plaintext will be encrypted. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="payload">The data to be encrypted.</param>
        /// <returns>OK</returns>
        System.Threading.Tasks.Task<EncryptResponse> EncryptAsync(string api_version, string name, string genid, EncryptRequest payload);

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module on whose behalf the ciphertext will be decrypted. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="payload">The data to be decrypted.</param>
        /// <returns>OK</returns>
        System.Threading.Tasks.Task<DecryptResponse> DecryptAsync(string api_version, string name, string genid, DecryptRequest payload);

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module to get certificate. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<CertificateResponse> CreateIdentityCertificateAsync(string api_version, string name, string genid);

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module to get certificate. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="request">Parameters for certificate creation.</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<CertificateResponse> CreateServerCertificateAsync(string api_version, string name, string genid, ServerCertificateRequest request);

        /// <param name="api_version">The version of the API.</param>
        /// <returns>Ok</returns>
        System.Threading.Tasks.Task<TrustBundleResponse> TrustBundleAsync(string api_version);

    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.16.1.0 (NJsonSchema v9.10.41.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        private IController _implementation;

        public Controller(IController implementation)
        {
            _implementation = implementation;
        }

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module on whose behalf the payload will be signed. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="payload">The data to be signed.</param>
        /// <returns>Ok</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("modules/{name}/genid/{genid}/sign")]
        public System.Threading.Tasks.Task<SignResponse> Sign(string api_version, string name, string genid, [Microsoft.AspNetCore.Mvc.FromBody] SignRequest payload)
        {
            return _implementation.SignAsync(api_version, name, genid, payload);
        }

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module on whose behalf the plaintext will be encrypted. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="payload">The data to be encrypted.</param>
        /// <returns>OK</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("modules/{name}/genid/{genid}/encrypt")]
        public System.Threading.Tasks.Task<EncryptResponse> Encrypt(string api_version, string name, string genid, [Microsoft.AspNetCore.Mvc.FromBody] EncryptRequest payload)
        {
            return _implementation.EncryptAsync(api_version, name, genid, payload);
        }

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module on whose behalf the ciphertext will be decrypted. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="payload">The data to be decrypted.</param>
        /// <returns>OK</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("modules/{name}/genid/{genid}/decrypt")]
        public System.Threading.Tasks.Task<DecryptResponse> Decrypt(string api_version, string name, string genid, [Microsoft.AspNetCore.Mvc.FromBody] DecryptRequest payload)
        {
            return _implementation.DecryptAsync(api_version, name, genid, payload);
        }

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module to get certificate. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <returns>Ok</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("modules/{name}/genid/{genid}/certificate/identity")]
        public System.Threading.Tasks.Task<CertificateResponse> CreateIdentityCertificate(string api_version, string name, string genid)
        {
            return _implementation.CreateIdentityCertificateAsync(api_version, name, genid);
        }

        /// <param name="api_version">The version of the API.</param>
        /// <param name="name">The name of the module to get certificate. (urlencoded)</param>
        /// <param name="genid">The generation identifier for the module as generated by IoT Hub.</param>
        /// <param name="request">Parameters for certificate creation.</param>
        /// <returns>Ok</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("modules/{name}/genid/{genid}/certificate/server")]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> CreateServerCertificate(string api_version, string name, string genid, [Microsoft.AspNetCore.Mvc.FromBody] ServerCertificateRequest request)
        {
            var response = await _implementation.CreateServerCertificateAsync(api_version, name, genid, request);
            return StatusCode(201, response);
        }

        /// <param name="api_version">The version of the API.</param>
        /// <returns>Ok</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("trust-bundle")]
        public System.Threading.Tasks.Task<TrustBundleResponse> TrustBundle(string api_version)
        {
            return _implementation.TrustBundleAsync(api_version);
        }

    }



    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SignRequest : System.ComponentModel.INotifyPropertyChanged
    {
        private string _keyId;
        private SignRequestAlgo _algo;
        private byte[] _data;

        /// <summary>Name of key to perform sign operation.</summary>
        [Newtonsoft.Json.JsonProperty("keyId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string KeyId
        {
            get { return _keyId; }
            set
            {
                if (_keyId != value)
                {
                    _keyId = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Sign algorithm to be used.</summary>
        [Newtonsoft.Json.JsonProperty("algo", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SignRequestAlgo Algo
        {
            get { return _algo; }
            set
            {
                if (_algo != value)
                {
                    _algo = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Data to be signed.</summary>
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] Data
        {
            get { return _data; }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SignRequest FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SignRequest>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SignResponse : System.ComponentModel.INotifyPropertyChanged
    {
        private byte[] _digest;

        /// <summary>Signature of the data.</summary>
        [Newtonsoft.Json.JsonProperty("digest", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] Digest
        {
            get { return _digest; }
            set
            {
                if (_digest != value)
                {
                    _digest = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static SignResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SignResponse>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class EncryptRequest : System.ComponentModel.INotifyPropertyChanged
    {
        private byte[] _plaintext;
        private byte[] _initializationVector;

        /// <summary>The data to be encrypted.</summary>
        [Newtonsoft.Json.JsonProperty("plaintext", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] Plaintext
        {
            get { return _plaintext; }
            set
            {
                if (_plaintext != value)
                {
                    _plaintext = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>An initialization vector used to encrypt the data.</summary>
        [Newtonsoft.Json.JsonProperty("initializationVector", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] InitializationVector
        {
            get { return _initializationVector; }
            set
            {
                if (_initializationVector != value)
                {
                    _initializationVector = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static EncryptRequest FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<EncryptRequest>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class EncryptResponse : System.ComponentModel.INotifyPropertyChanged
    {
        private byte[] _ciphertext;

        /// <summary>The encrypted form of the data encoded in base 64.</summary>
        [Newtonsoft.Json.JsonProperty("ciphertext", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] Ciphertext
        {
            get { return _ciphertext; }
            set
            {
                if (_ciphertext != value)
                {
                    _ciphertext = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static EncryptResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<EncryptResponse>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DecryptRequest : System.ComponentModel.INotifyPropertyChanged
    {
        private byte[] _ciphertext;
        private byte[] _initializationVector;

        /// <summary>The data to be decrypted.</summary>
        [Newtonsoft.Json.JsonProperty("ciphertext", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] Ciphertext
        {
            get { return _ciphertext; }
            set
            {
                if (_ciphertext != value)
                {
                    _ciphertext = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>An initialization vector used to decrypt the data.</summary>
        [Newtonsoft.Json.JsonProperty("initializationVector", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] InitializationVector
        {
            get { return _initializationVector; }
            set
            {
                if (_initializationVector != value)
                {
                    _initializationVector = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DecryptRequest FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DecryptRequest>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DecryptResponse : System.ComponentModel.INotifyPropertyChanged
    {
        private byte[] _plaintext;

        /// <summary>The decrypted form of the data encoded in base 64.</summary>
        [Newtonsoft.Json.JsonProperty("plaintext", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public byte[] Plaintext
        {
            get { return _plaintext; }
            set
            {
                if (_plaintext != value)
                {
                    _plaintext = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static DecryptResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DecryptResponse>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ServerCertificateRequest : System.ComponentModel.INotifyPropertyChanged
    {
        private string _commonName;
        private System.DateTime _expiration;

        /// <summary>Subject common name</summary>
        [Newtonsoft.Json.JsonProperty("commonName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string CommonName
        {
            get { return _commonName; }
            set
            {
                if (_commonName != value)
                {
                    _commonName = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Certificate expiration date-time (ISO 8601)</summary>
        [Newtonsoft.Json.JsonProperty("expiration", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.DateTime Expiration
        {
            get { return _expiration; }
            set
            {
                if (_expiration != value)
                {
                    _expiration = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ServerCertificateRequest FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ServerCertificateRequest>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CertificateResponse : System.ComponentModel.INotifyPropertyChanged
    {
        private PrivateKey _privateKey = new PrivateKey();
        private string _certificate;
        private System.DateTime _expiration;

        [Newtonsoft.Json.JsonProperty("privateKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public PrivateKey PrivateKey
        {
            get { return _privateKey; }
            set
            {
                if (_privateKey != value)
                {
                    _privateKey = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Base64 encoded PEM formatted byte array containing the certificate and its chain.</summary>
        [Newtonsoft.Json.JsonProperty("certificate", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Certificate
        {
            get { return _certificate; }
            set
            {
                if (_certificate != value)
                {
                    _certificate = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Certificate expiration date-time (ISO 8601)</summary>
        [Newtonsoft.Json.JsonProperty("expiration", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.DateTime Expiration
        {
            get { return _expiration; }
            set
            {
                if (_expiration != value)
                {
                    _expiration = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static CertificateResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CertificateResponse>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TrustBundleResponse : System.ComponentModel.INotifyPropertyChanged
    {
        private string _certificate;

        /// <summary>Base64 encoded PEM formatted byte array containing the trusted certificates.</summary>
        [Newtonsoft.Json.JsonProperty("certificate", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Certificate
        {
            get { return _certificate; }
            set
            {
                if (_certificate != value)
                {
                    _certificate = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static TrustBundleResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TrustBundleResponse>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PrivateKey : System.ComponentModel.INotifyPropertyChanged
    {
        private PrivateKeyType _type;
        private string _ref;
        private string _bytes;

        /// <summary>Indicates format of the key (present in PEM formatted bytes or a reference)</summary>
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PrivateKeyType Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Reference to private key.</summary>
        [Newtonsoft.Json.JsonProperty("ref", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Ref
        {
            get { return _ref; }
            set
            {
                if (_ref != value)
                {
                    _ref = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>Base64 encoded PEM formatted byte array</summary>
        [Newtonsoft.Json.JsonProperty("bytes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Bytes
        {
            get { return _bytes; }
            set
            {
                if (_bytes != value)
                {
                    _bytes = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PrivateKey FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PrivateKey>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ErrorResponse : System.ComponentModel.INotifyPropertyChanged
    {
        private string _message;

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ErrorResponse FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(data);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum SignRequestAlgo
    {
        [System.Runtime.Serialization.EnumMember(Value = "HMACSHA256")]
        HMACSHA256 = 0,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.41.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum PrivateKeyType
    {
        [System.Runtime.Serialization.EnumMember(Value = "ref")]
        Ref = 0,

        [System.Runtime.Serialization.EnumMember(Value = "key")]
        Key = 1,

    }

}
