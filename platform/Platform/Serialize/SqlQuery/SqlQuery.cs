using System.Collections.Generic;

namespace platform
{
    public class SqlQuery
    {
        public void _runFormat(SqlFormat nSqlFormat)
        {
            foreach (ISqlHeadstream i in mSqlHeadstreams)
            {
                nSqlFormat._runFormat(i);
            }
        }

        public void _addHeadstream(ISqlHeadstream nSqlHeadstreams)
        {
            mSqlHeadstreams.Add(nSqlHeadstreams);
        }

        public SqlQuery()
        {
            mSqlHeadstreams = new List<ISqlHeadstream>();
        }

        List<ISqlHeadstream> mSqlHeadstreams;
    }
}
