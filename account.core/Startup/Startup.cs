using platform;

namespace account.core
{
    public class Startup : IStartup
    {
        public void _runStart()
        {
            AccountService accountService_ = __singleton<AccountService>._instance();
            accountService_._runInit();
        }
    }
}
