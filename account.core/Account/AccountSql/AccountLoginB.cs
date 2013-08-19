using System;

using platform;

namespace account.core
{
    public class AccountLoginB : ISqlHeadstream
    {
        public void _runSelect(SqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mNickName, @"nickName");
            nSqlFormat._serialize(ref mPassward, @"passward");
            nSqlFormat._serialize(ref mTicks, @"createTime");
        }

        public void _runWhere(SqlFormat nSqlFormat)
        {
            nSqlFormat._serialize(ref mAccountId, @"WHERE id = ");
        }

        public string _tableName()
        {
            return ("account_" + mAccountMgrId);
        }

        public SqlType_ _sqlType()
        {
            return SqlType_.mSelect_;
        }

        public AccountLoginB(string nAccountName, uint nAccountMgrId)
        {
            mAccountId = GenerateId._runNameId(nAccountName);
            mAccountName = nAccountName;
            mAccountMgrId = nAccountMgrId;
        }

        uint mAccountId;
        string mAccountName;
        string mNickName;
        string mPassward;
        long mTicks;
        uint mAccountMgrId;
    }
}
