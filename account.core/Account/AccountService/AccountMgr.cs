using System;
using System.Collections.Generic;

using platform;
using account.message;

namespace account.core
{
    public class AccountMgr
    {
        public ErrorCode_ _createAccount(string nAccountName, string nNickname, string nPassward)
        {
        }

        public AccountMgr(uint nId)
        {
            mAccounts = new Dictionary<uint, Account>();
            mId = 0;
        }

        Dictionary<uint, Account> mAccounts;
        uint mId;
    }
}
