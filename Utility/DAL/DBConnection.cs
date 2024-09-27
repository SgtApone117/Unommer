using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Unommer.DAL
{
    public class DBConnection
    {
        public static string Connection(string School)
        {
            string ConnectionString = string.Empty;
            if (School == "Default")
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            else if (School == "Marias public School")
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMaria"].ConnectionString;
            }
            else
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            return ConnectionString;
        }

        //public static string Connection(string School)
        //{
        //    string ConnectionString = string.Empty;
        //    if (School == "Delhi Public School")
        //    {
        //        ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    }

        //    return ConnectionString;
        //}
    }
}