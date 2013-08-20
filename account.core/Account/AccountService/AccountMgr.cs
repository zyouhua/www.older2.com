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
            SqlQuery sqlQuery_ = new SqlQuery();
            sqlQuery_._addHeadstream(new AccountCreateB(nAccountName, nNickname, nPassward, mId));
            SqlSingleton mySqlSingleton_ = __singleton<SqlSingleton>._instance();
            SqlErrorCode_ sqlErrorCode_ = mySqlSingleton_._runSqlQuery(sqlQuery_);
            return _getErrorCode(sqlErrorCode_);
        }

        ErrorCode_ _getErrorCode(SqlErrorCode_ nSqlErrorCode)
        {
            ErrorCode_ result_ = ErrorCode_.mSucess_;
            if (SqlErrorCode_.mFail_ == nSqlErrorCode)
            {
                result_ = ErrorCode_.mFail_;
            }
            return result_;
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
