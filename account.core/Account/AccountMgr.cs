using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace account.core
{
    public class AccountMgr
    {
        public void _setId(uint nId)
        {
            mId = nId;
        }

        public AccountMgr()
        {
            mAccounts = new Dictionary<uint, Account>();
            mId = 0;
        }

        Dictionary<uint, Account> mAccounts;
        uint mId;
    }
}
