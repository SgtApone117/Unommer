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
    public class UpdateSchoolData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public static SchoolRegistration UpdateSchool(SchoolRegistration clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("SP_UpdateSchool"))
                {
                    db.AddInParameter(cmd, "@AdminEmail", DbType.String, clsobj.AdministratorEmail);
                    db.AddInParameter(cmd, "@SchoolAddr", DbType.String, clsobj.Address);
                    db.AddInParameter(cmd, "@SchoolTele", DbType.String, clsobj.TelphoneNumber);
                    db.AddInParameter(cmd, "@SchoolMobile", DbType.String, clsobj.MobileNumber);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { ds.Clear(); }

            return clsobj;
        }
    }
}