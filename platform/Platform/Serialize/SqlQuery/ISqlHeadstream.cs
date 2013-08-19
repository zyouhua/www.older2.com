namespace platform
{
    public interface ISqlHeadstream
    {
        void _runSelect(SqlFormat nSqlFormat);

        void _runWhere(SqlFormat nSqlFormat);

        string _tableName();

        SqlType_ _sqlType();
    }
}
