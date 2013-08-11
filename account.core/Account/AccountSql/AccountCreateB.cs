using System;

using platform;

namespace account.core
{
    public class AccountCreateB : ISqlStream
    {
        public void _serialize(ISqlSerialize nSqlSerialize)
        {
            nSqlSerialize._serialize(ref mAccountId, @"id");
            nSqlSerialize._serialize(ref mAccountName, @"accountName");
            nSqlSerialize._serialize(ref mNickName, @"nickName");
            nSqlSerialize._serialize(ref mPassward, @"passward");
            nSqlSerialize._serialize(ref mTicks, @"createTime");
            nSqlSerialize._serialize(ref mClusterID, @"clusterID");
            nSqlSerialize._serialize(ref mServerID, @"serverID");
            nSqlSerialize._serialize(ref mDatabaseId, @"databaseId");
            nSqlSerialize._serialize(ref mTableId, @"tableId");
        }

        public AccountCreateB(string nAccountName, string nNickname, string nPassward)
        {
            mAccountId = GenerateId._runNameId(nAccountName);
            mClusterID = GenerateId._runClusterID(nAccountName);
            mServerID = GenerateId._runServerID(nAccountName);
            mDatabaseId = GenerateId._runDatabaseId(nAccountName);
            mTableId = GenerateId._runTableId(nAccountName);
            mAccountName = nAccountName;
            mNickName = nNickname;
            mPassward = nPassward;
            mTicks = DateTime.Now.Ticks;
        }

        uint mAccountId;
        string mAccountName;
        string mNickName;
        string mPassward;
        long mTicks;
        uint mClusterID;
        uint mServerID;
        uint mDatabaseId;
        uint mTableId;
    }
}
