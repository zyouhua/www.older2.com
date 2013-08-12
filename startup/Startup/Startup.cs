using System.IO;
using System.Web;
using System.Reflection;
using System.Web.Hosting;

using platform;

[assembly: PreApplicationStartMethod(typeof(startup.Startup), "_runStart")]
namespace startup
{
    public class Startup
    {
        public static void _runStart()
        {
            _initApp();
            _startApp();
        }

        static void _initApp()
        {
            string systemPath_ = HostingEnvironment.MapPath(@"~");
            systemPath_ = Path.Combine(systemPath_, @"../../bin/platform");
            SettingSingleton settingSingleton_ = __singleton<SettingSingleton>._instance();
            settingSingleton_._runInit(systemPath_);
        }

        static void _startApp()
        {
            string appUrl_ = @"local://";
            appUrl_ += HostingEnvironment.MapPath(@"~\platform\appUrls.xml");
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            platformSingleton_._startApp(appUrl_);
        }
    }
}
