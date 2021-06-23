using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Models;

namespace uplink.NET.UnoHelpers.Messages
{
    public class UserLoggedInMessage
    {
        public UserLoggedInMessage(AppConfig appConfig)
        {
            AppConfig = appConfig;
        }

        public AppConfig AppConfig { get; }
    }
}
