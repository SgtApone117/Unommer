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
    public class AvailData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public static avail_temp InsertAvailTemp(avail_temp clsobj,string School)
        {
            DataSet Ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_InsertAvailTemp"))
                {

                    db.AddInParameter(cmd, "@TempName", DbType.String, clsobj.Template_Name);
                    db.AddInParameter(cmd, "@TempStatus", DbType.String, clsobj.Template_Status);

                    db.AddInParameter(cmd, "@st1", DbType.String, Convert.ToDouble(clsobj.StartTimeMonMorng));
                    db.AddInParameter(cmd, "@et1", DbType.String, Convert.ToDouble(clsobj.EndTimeMonMorng));
                    db.AddInParameter(cmd, "@st2", DbType.String, Convert.ToDouble(clsobj.StartTimeMonAfter));
                    db.AddInParameter(cmd, "@et2", DbType.String, Convert.ToDouble(clsobj.EndTimeMonAfter));
                    db.AddInParameter(cmd, "@Day", DbType.String, clsobj.Day);

                    Ds = db.ExecuteDataSet(cmd);
                    
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Ds.Clear(); }
            return clsobj;
        }
    }
}