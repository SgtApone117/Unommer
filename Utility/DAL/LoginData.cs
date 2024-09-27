using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Unommer.Models;

namespace Unommer.DAL
{
    public class LoginData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public Login_User CheckLogin(Login_User clsobj, string School)
        {

            DataSet Ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));

            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_CheckLogin"))
                {
                    db.AddInParameter(cmd, "@Username", DbType.String, clsobj.Username);
                    db.AddInParameter(cmd, "@Pass", DbType.String, clsobj.Pass);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    Ds = db.ExecuteDataSet(cmd);
                    clsobj.Result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Ds.Clear(); }
            return clsobj;
        }

        //public DataSet FetchChatData(Login_User obj)
        //{
        //    DataSet ds = null;
        //    Database db = new SqlDatabase(ConnectionString);
        //    try { 
        //        using(DbCommand cmd = db.GetStoredProcCommand("Sp_Fetch_User_Chat"))
        //        {
        //            db.AddInParameter(cmd, "@Mail",DbType.String, obj.Username);
        //            ds = db.ExecuteDataSet(cmd);
        //        }
        //    }
        //    catch { }
        //    return ds;
        //}

        public DataSet Check_Collaboration_Chat(Login_User obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Check_Collaboration_Chat"))
                {
                    db.AddInParameter(cmd, "@Username", DbType.String, obj.Username);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }
    }
}