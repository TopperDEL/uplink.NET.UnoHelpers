using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uplink.NET.UnoHelpers.Models
{
    public class AppConfig
    {
        public string BucketName { get; private set; }
        public string AccessGrant { get; private set; }
        public string SatelliteAddress { get; private set; }
        public string ApiKey { get; private set; }
        public string Secret { get; private set; }
        public string SecretVerify { get; private set; }

        public AppConfig(string accessGrant, string bucketName, string satelliteAddress, string apiKey, string secret): this(accessGrant, bucketName, satelliteAddress, apiKey, secret, secret)
        {
        }

        public AppConfig(string accessGrant, string bucketName, string satelliteAddress, string apiKey, string secret, string secretVerify)
        {
            AccessGrant = accessGrant;
            BucketName = bucketName;
            SatelliteAddress = satelliteAddress;
            ApiKey = apiKey;
            Secret = secret;
            SecretVerify = secretVerify;
        }
    }
}
