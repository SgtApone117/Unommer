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
    public class UpdateParentData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();
        public static DataSet GetParentInfo(ParentRegistration clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("SP_GetParentInfo")) 
                {
                    db.AddInParameter(cmd, "@Username", DbType.String, clsobj.Parent_mail);
                    db.AddInParameter(cmd,"@CurrPass",DbType.String, clsobj.Pass);
                    db.AddInParameter(cmd, "@NewPass", DbType.String, clsobj.NewPass);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { ds.Clear(); }
            return ds;
        }
    }
}