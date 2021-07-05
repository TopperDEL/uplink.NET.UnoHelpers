using System;
using System.Collections.Generic;
using System.Text;
using uplink.NET.Models;
using uplink.NET.UnoHelpers.Contracts.Models;

namespace uplink.NET.UnoHelpers.Services
{
    public static class AppConfigExtension
    {
        public static string TryGetAccessGrant(this AppConfig appConfig, out bool success)
        {
            try
            {
                if (!string.IsNullOrEmpty(appConfig.AccessGrant))
                {
                    success = true;
                    return appConfig.AccessGrant;
                }
                else
                {
                    Access acc = new Access(appConfig.SatelliteAddress, appConfig.ApiKey, appConfig.Secret);
                    var accessGrant = acc.Serialize();
                    success = true;
                    return accessGrant;
                }
            }
            catch
            {
                success = false;
                return string.Empty;
            }
        }
    }
}
