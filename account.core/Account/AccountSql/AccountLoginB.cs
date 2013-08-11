using System;

using platform;

namespace account.core
{
    public class AccountLoginB : ISqlStream
    {
        public void _serialize(ISqlSerialize nSqlSerialize)
        {
            nSqlSerialize._serialize(ref mNickName, @"nickName");
            nSqlSerialize._serialize(ref mPassward, @"passward");
        }

        string mNickName;
        string mPassward;
    }
}
