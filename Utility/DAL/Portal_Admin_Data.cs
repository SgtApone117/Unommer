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
    public class Portal_Admin_Data
    {
        public DataSet Fetch_School_Details(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_Get_School_Details"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet Update_Status_School(string School,School obj)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Update_School_Status"))
                {
                    db.AddInParameter(cmd, "@SchoolID", DbType.Int32, obj.SchoolID);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet Fetch_School_Details_Active(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Active_School_Details"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;

        }

        public DataSet Update_Active_School(String School, School obj)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Update_Active_School"))
                {
                    db.AddInParameter(cmd, "@SchoolID", DbType.Int32, obj.SchoolID);
                    db.AddInParameter(cmd, "@AdminMail", DbType.String, obj.adminmail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }
    }
}