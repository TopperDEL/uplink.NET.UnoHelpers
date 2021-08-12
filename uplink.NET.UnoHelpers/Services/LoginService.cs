using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Models;
using uplink.NET.UnoHelpers.Contracts.Interfaces;
using Windows.Security.Credentials;

namespace uplink.NET.UnoHelpers.Services
{
    public class LoginService : ILoginService
    {
        private const string ACCESS_GRANT = "ACCESS_GRANT";
        private const string BUCKET_NAME = "BUCKET_NAME";
        private const string SATELLITE_ADDRESS = "SATELLITE_ADDRESS";
        private const string API_KEY = "API_KEY";
        private const string SECRET = "SECRET";

        private PasswordVault _vault = new PasswordVault();

        public bool GetIsLoggedIn()
        {
            try
            {
                var access = GetLogin();
                if (!string.IsNullOrEmpty(access.AccessGrant))
                    return true;
            }
            catch
            {
                //Whatever happened - consider the user as not logged in
            }
            return false;
        }

        public AppConfig GetLogin()
        {
            return new AppConfig(Retrieve(ACCESS_GRANT),
                                 Retrieve(BUCKET_NAME),
                                 Retrieve(SATELLITE_ADDRESS),
                                 Retrieve(API_KEY),
                                 Retrieve(SECRET));
        }

        public bool Login(AppConfig appConfig)
        {
            //Verify if access is valid
            if (!string.IsNullOrEmpty(appConfig.AccessGrant) && !string.IsNullOrEmpty(appConfig.BucketName))
            {
                //ToDo: Verify bucket name
                //ToDo: check Access Grant

                AddIfNotEmpty(ACCESS_GRANT, appConfig.AccessGrant);
                AddIfNotEmpty(BUCKET_NAME, appConfig.BucketName);
            }
            else if (!string.IsNullOrEmpty(appConfig.SatelliteAddress) && !string.IsNullOrEmpty(appConfig.ApiKey) && !string.IsNullOrEmpty(appConfig.Secret))
            {
                //ToDo: Check Satellite address
                //ToDo: Verify API-Key
                AddIfNotEmpty(SATELLITE_ADDRESS, appConfig.SatelliteAddress);
                AddIfNotEmpty(API_KEY, appConfig.ApiKey);
                AddIfNotEmpty(SECRET, appConfig.Secret);
            }
            else
            {
                //Some data is missing
                return false;
            }

            return true;
        }

        public void Logout()
        {
            var list = _vault.FindAllByResource(Initializer._passwordResource);
            foreach (var entry in list)
                _vault.Remove(entry);
        }

        private string Retrieve(string key)
        {
            try
            {
                return _vault.Retrieve(Initializer._passwordResource, key)?.Password;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void AddIfNotEmpty(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                _vault.Add(new PasswordCredential(Initializer._passwordResource, key, value));
        }
    }
}
