using System;
using System.Collections.Generic;

namespace platform
{
    public class SqlFormat
    {
        static readonly string mCharacter = @"`";

        public void _serialize<__t>(ref List<__t> nValue, string nName) where __t : ISqlStream
        {
            if (SqlDeal_.mSelect_ == mSqlDeal)
            {
                foreach (__t i in nValue)
                {
                    i._runSelect(this);
                    break;
                }
            }
            else if (SqlDeal_.mInsert_ == mSqlDeal)
            {
                bool temp_ = false;
                foreach (__t i in nValue)
                {
                    if (temp_)
                    {
                        mValue += "),(";
                    }
                    i._runSelect(this);
                    temp_ = true;
                }
            }
            else if (SqlDeal_.mUpdate_ == mSqlDeal)
            {


                mValue += " WHERE ";
                mSqlDeal = SqlDeal_.mSelect_;
                mBeg = true;
                foreach (__t i in nValue)
                {
                    i._runWhen(this);
                    break;
                }
                mSqlDeal = SqlDeal_.mInsert_;
                mBeg = true;
                mValue += " IN (";
                foreach (__t i in nValue)
                {
                    i._runWhen(this);
                }
                mValue += ")";
            }
            else
            {
            }
        }

        public void _serialize<__t>(ref __t nValue, string nName)
        {
            if (SqlDeal_.mSelect_ == mSqlDeal)
            {
                if (false == mBeg)
                {
                    mValue += ",";
                }
                mValue += nName;
                if (mBeg)
                {
                    mBeg = false;
                }
            }
            else if (SqlDeal_.mInsert_ == mSqlDeal)
            {
                if (false == mBeg)
                {
                    mValue += ",";
                }
                mValue += mCharacter;
                mValue += Convert.ToString(nValue);
                mValue += mCharacter;
                if (mBeg)
                {
                    mBeg = false;
                }
            }
            else if (SqlDeal_.mWhere_ == mSqlDeal)
            {
                mValue += nName;
                mValue += mCharacter;
                mValue += Convert.ToString(nValue);
                mValue += mCharacter;
                mValue += " ";
            }
            else if (SqlDeal_.mUpdate_ == mSqlDeal)
            {
                if (false == mBeg)
                {
                    mValue += ",";
                }
                mValue += nName;
                mValue += " = ";
                mValue += mCharacter;
                mValue += Convert.ToString(nValue);
                mValue += mCharacter;
                if (mBeg)
                {
                    mBeg = false;
                }
            }
            else
            {

            }
        }

        public void _serialize(string nValue)
        {
            mValue += nValue;
        }

        public void _runFormat(ISqlHeadstream nSqlStream)
        {
            SqlType_ sqlType_ = nSqlStream._sqlType();
            if (SqlType_.mDelete_ == sqlType_)
            {
                this._runDelete(nSqlStream);
            }
            else if (SqlType_.mInsert_ == sqlType_)
            {
                this._runInsert(nSqlStream);
            }
            else if (SqlType_.mSelect_ == sqlType_)
            {
                this._runSelect(nSqlStream);
            }
            else if (SqlType_.mUpdate_ == sqlType_)
            {
                this._runUpdate(nSqlStream);
            }
            else
            {
            }
        }

        public void _runDelete(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"DELETE FROM ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" ";
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public void _runInsert(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"INSERT INTO ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" (";
            mBeg = true;
            mSqlDeal = SqlDeal_.mSelect_;
            nSqlHeadstream._runSelect(this);
            mValue += @") VALUES (";
            mBeg = true;
            mSqlDeal = SqlDeal_.mInsert_;
            nSqlHeadstream._runSelect(this);
            mValue += @") ";
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public void _runSelect(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"SELECT ";
            mBeg = true;
            mSqlDeal = SqlDeal_.mSelect_;
            nSqlHeadstream._runSelect(this);
            mValue += @" FROM ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" ";
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public void _runUpdate(ISqlHeadstream nSqlHeadstream)
        {
            mValue += @"UPDATE ";
            mValue += nSqlHeadstream._tableName();
            mValue += @" SET ";
            mBeg = true;
            mSqlDeal = SqlDeal_.mUpdate_;
            nSqlHeadstream._runSelect(this);
            mSqlDeal = SqlDeal_.mWhere_;
            nSqlHeadstream._runWhere(this);
            mSqlDeal = SqlDeal_.mNone_;
        }

        public string _sqlCommand()
        {
            return mValue;
        }

        public SqlFormat()
        {
            mSqlDeal = SqlDeal_.mNone_;
            mValue = null;
            mBeg = false;
        }

        SqlDeal_ mSqlDeal;
        string mValue;
        bool mBeg;
    }
}
