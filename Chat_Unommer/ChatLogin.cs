using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using Unommer;
using Unommer.Chat_Unommer;
using Unommer.Models;

namespace Unommer.Chat_Unommer
{
    public class ChatLogin
    {
        private static string ConnectionStr = ConnClass.Connection1.ToString();
        public DataSet FetchChatData(Login_User obj)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(ConnectionStr);
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Fetch_User_Chat"))
                {
                    db.AddInParameter(cmd, "@Mail", DbType.String, obj.Username);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }


    }
}