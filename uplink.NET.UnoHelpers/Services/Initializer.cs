using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uplink.NET.UnoHelpers.Services
{
    public static class Initializer
    {
        private static IServiceProvider _serviceProvider;
        internal static string _passwordResource;

        public static void Init(IServiceProvider serviceProvider, string passwordResource)
        {
            _serviceProvider = serviceProvider;
            _passwordResource = passwordResource;
        }

        public static IServiceProvider GetServiceProvider()
        {
            if(_serviceProvider == null)
            {
                throw new NullReferenceException("No ServiceProvider set - init UnoHelpers with uplink.NET.UnoHelpers.Services.Initializer.Init().");
            }

            return _serviceProvider;
        }
    }
}
