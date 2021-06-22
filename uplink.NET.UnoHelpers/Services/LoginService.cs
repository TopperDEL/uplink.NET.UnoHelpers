using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Interfaces;
using uplink.NET.UnoHelpers.Models;
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
            return new AppConfig(_vault.Retrieve(Initializer._passwordResource, ACCESS_GRANT)?.Password,
                                 _vault.Retrieve(Initializer._passwordResource, BUCKET_NAME)?.Password,
                                 _vault.Retrieve(Initializer._passwordResource, SATELLITE_ADDRESS)?.Password,
                                 _vault.Retrieve(Initializer._passwordResource, API_KEY)?.Password,
                                 _vault.Retrieve(Initializer._passwordResource, SECRET)?.Password);
        }

        public bool Login(AppConfig appConfig)
        {
            //ToDo: Verify if access is valid

            //Save access grant to vault
            _vault.Add(new PasswordCredential(Initializer._passwordResource, ACCESS_GRANT, appConfig.AccessGrant));
            _vault.Add(new PasswordCredential(Initializer._passwordResource, BUCKET_NAME, appConfig.BucketName));
            _vault.Add(new PasswordCredential(Initializer._passwordResource, SATELLITE_ADDRESS, appConfig.SatelliteAddress));
            _vault.Add(new PasswordCredential(Initializer._passwordResource, API_KEY, appConfig.ApiKey));
            _vault.Add(new PasswordCredential(Initializer._passwordResource, SECRET, appConfig.Secret));

            return true;
        }

        public void Logout()
        {
            var list = _vault.FindAllByResource(Initializer._passwordResource);
            foreach (var entry in list)
                _vault.Remove(entry);
        }
    }
}
