using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Contracts.Models;

namespace uplink.NET.UnoHelpers.Contracts.Interfaces
{
    public interface ILoginService
    {
        bool GetIsLoggedIn();
        AppConfig GetLogin();
        bool Login(AppConfig appConfig);
        void Logout();
    }
}
