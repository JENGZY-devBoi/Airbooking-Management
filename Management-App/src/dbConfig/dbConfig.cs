using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Management_App
{
    static class dbConfig
    {
        static private string server = "LAPTOP-2IC0MAKH\\KMUTNBMC";
        static private string database = "airbooking";
        static private string userID = "sa";
        static private string password = "123";

        static private String cnn =
            $"server={server};" +
            $"database={database};" +
            $"user id={userID};" +
            $"password={password}";

        static public SqlConnection connection =
            new SqlConnection(cnn);
    }
}
