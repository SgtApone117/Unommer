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
    public class WebData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public static Verifyall verifyformail(Verifyall obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Email_verify"))
                {
                    db.AddInParameter(cmd, "@guid", DbType.String, obj.Guid);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    ds = db.ExecuteDataSet(cmd);
                    obj.result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch
            {

            }
            return obj;

        }

        public static Verifyall1 verifyformail(Verifyall1 obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Email_verify_Parent"))
                {
                    db.AddInParameter(cmd, "@guid", DbType.String, obj.Guid);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    ds = db.ExecuteDataSet(cmd);
                    obj.result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch
            {

            }
            return obj;

        }

        }

    }