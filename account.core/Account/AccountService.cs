using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using platform;

namespace account.core
{
    public class AccountService : PropertySink
    {
        public void _runInit()
        {
            string accountConfigUrl_ = @"rid://account.accoutConfig";
            PlatformSingleton platformSingleton_ = __singleton<PlatformSingleton>._instance();
            AccountConfig accountConfig_ = __singleton<AccountConfig>._instance();
            platformSingleton_._loadHeadstream<AccountConfig>(accountConfig_, accountConfigUrl_);

            uint accountMgrCount_ = accountConfig_._getAccountMgrCount();
            for (uint i = 0; i < accountMgrCount_; ++i)
            {
                AccountMgr accountMgr_ = new AccountMgr();
                accountMgr_._setId(i);
                mAccountMgrs[i] = accountMgr_;
            }
        }

        public AccountService()
        {
            mAccountMgrs = new Dictionary<uint, AccountMgr>();
        }

        Dictionary<uint, AccountMgr> mAccountMgrs;
    }
}
