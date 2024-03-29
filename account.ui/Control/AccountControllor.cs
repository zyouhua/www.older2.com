﻿using System.Web.Http;

using platform;
using account.message;

namespace account.ui
{
    public class AccountControllor : ApiController
    {
        [HttpGet]
        public ErrorCode_ _createAccount(string nName, string nNickname, string nPassward)
        {
            AccountSink accountSink_ = __singleton<AccountSink>._instance();
            return accountSink_.m_tAccountCreate(nName, nNickname, nPassward);
        }
    }
}
