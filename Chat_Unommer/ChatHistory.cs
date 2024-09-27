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

namespace Unommer.Chat_Unommer
{
    public class ChatHistory
    {

        private static string ConnectionStr = ConnClass.Connection1.ToString();
        public static Messages InsertPrivateChatHistory(Messages clsobj)
        {

            DataSet Ds = null;
            Database db = new SqlDatabase(ConnectionStr);
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_insertchatdetails"))
                {
                    db.AddInParameter(cmd, "@Messages", DbType.String, clsobj.Message);
                    db.AddInParameter(cmd, "@FromUserName", DbType.String, clsobj.FromUserName);
                    db.AddInParameter(cmd, "@ToUserName", DbType.String, clsobj.ToUserName);
                    db.AddInParameter(cmd, "@FromEmail", DbType.String, clsobj.FromEmail);
                    db.AddInParameter(cmd, "@ToEmail", DbType.String, clsobj.ToEmail);
                    Ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Ds.Clear();
            }
            return clsobj;
        }
    }
}