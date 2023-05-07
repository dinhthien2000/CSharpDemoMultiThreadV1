using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMultiThread.Connection
{
    internal class Connect
    {
        static string host = "localhost";
        static int port = 3306;
        static string database = "CSharpTutorial";
        static string username = "root";
        static string password = "";

        public static MySqlConnection getConnection()
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
    }
}
