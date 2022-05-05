using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Management_App
{
    static class dbOperation
    {
        #region Properties
        static private SqlCommand cmdSelect;
        static private SqlCommand cmdInsert;
        #endregion

        #region Properties
        static public SqlCommand commandSelect
        {
            get => cmdSelect;
        }

        static public SqlCommand commandInsert
        {
            get => cmdInsert;
        }
        #endregion

        #region Functions
        static public void createCmdSelect(string sql)
        {
            cmdSelect = new SqlCommand(sql, dbConfig.connection);
        }

        static public void createCmdInsert(string sql)
        {
            cmdInsert = new SqlCommand(sql, dbConfig.connection);
        }

        static public void disposeCmdSelect()
        {
            cmdSelect.Dispose();
        }

        static public void disposeCmdInsert()
        {
            cmdInsert.Dispose();
        }
        #endregion
    }
}
