using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace uplink.NET.UnoHelpers.TestApp.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new uplink.NET.UnoHelpers.TestApp.App(), args);
            host.Run();
        }
    }
}
