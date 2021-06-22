using MvvmGen;
using MvvmGen.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Interfaces;
using uplink.NET.UnoHelpers.Messages;
using uplink.NET.UnoHelpers.Models;

namespace uplink.NET.UnoHelpers.ViewModels
{
    [Inject(typeof(ILoginService))]
    [Inject(typeof(IEventAggregator))]
    [ViewModel]
    public partial class LoginViewModel
    {
        [Property] private string _accessGrant;
        [Property] private string _bucketName;

        [Property] private string _satelliteAddress;
        [Property] private string _apiKey;
        [Property] private string _secret;
        [Property] private string _secretVerify;

        [Command]
        private void Login()
        {
            AppConfig appConfig = new AppConfig(AccessGrant, BucketName, SatelliteAddress, ApiKey, Secret, SecretVerify);
            bool loggedIn = LoginService.Login(appConfig);

            if (loggedIn)
            {
                EventAggregator.Publish(new UserLoggedInMessage(appConfig));
            }
            else
            {
                EventAggregator.Publish(new ErrorOccuredMessage("Login failed"));
            }
        }
    }
}
