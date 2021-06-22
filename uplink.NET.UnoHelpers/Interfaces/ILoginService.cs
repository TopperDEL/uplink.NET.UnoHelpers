using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uplink.NET.UnoHelpers.Models;

namespace uplink.NET.UnoHelpers.Interfaces
{
    public interface ILoginService
    {
        bool GetIsLoggedIn();
        AppConfig GetLogin();
        bool Login(AppConfig appConfig);
        void Logout();
    }
}
