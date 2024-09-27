using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Unommer;
using Unommer.Models;
using Unommer.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Net.Mail;
using System.Net;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Unommer.DAL
{
    public class Demo_User_Data
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public static Demo InsertDemoDetails(Demo clsobj,string School)
        {
            DataSet Ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_InsertDemoData"))
                {
                    db.AddInParameter(cmd, "@req_name", DbType.String, clsobj.Name);
                    db.AddInParameter(cmd, "@email", DbType.String, clsobj.Email);
                    db.AddInParameter(cmd, "@phonenumber", DbType.String, clsobj.NameofSchool);
                    db.AddInParameter(cmd, "nameofschool", DbType.String, clsobj.PhoneNumber);
                    db.AddInParameter(cmd, "dateofdemo", DbType.String, clsobj.dateofdemo);
                    db.AddInParameter(cmd, "timeofdemo", DbType.String, clsobj.timeofdemo);
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