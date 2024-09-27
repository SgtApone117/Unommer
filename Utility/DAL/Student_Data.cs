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
    public class Student_Data
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public DataSet GetStudentRecordsInfo(string School)
        {
            StudentDetails clsobj = new StudentDetails();
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_GetStudentRecords"))
                {

                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds;
        }
        public static StudentDetails InsertStudentDetails(StudentDetails clsobj, string School)
        {
            DataSet Ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_InsertStudentData"))
                {
                    db.AddInParameter(cmd, "@FirstName", DbType.String, clsobj.Student_FirstName);
                    db.AddInParameter(cmd, "@LastName", DbType.String, clsobj.Student_LastName);
                    db.AddInParameter(cmd, "@Class", DbType.String, clsobj.Class);
                    db.AddInParameter(cmd, "@Section", DbType.String, clsobj.Section);
                    db.AddInParameter(cmd, "@RollNo", DbType.Int32, clsobj.RollNo);
                    db.AddInParameter(cmd, "@FatherMail", DbType.String, clsobj.FatherMail);
                    db.AddInParameter(cmd, "@MotherMail", DbType.String, clsobj.MotherMail);
                    db.AddInParameter(cmd, "@GuardianMail", DbType.String, clsobj.GuardianMail);
                    db.AddInParameter(cmd, "@Status", DbType.String, clsobj.Status);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    Ds = db.ExecuteDataSet(cmd);
                    clsobj.result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
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

        public Debrief_Parent updatepasswordparent(Debrief_Parent obj, string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Password_Parent"))
                {
                    db.AddInParameter(cmd, "@ParentEmail", DbType.String, obj.parent_mail);
                    db.AddInParameter(cmd, "@ParentNewPass", DbType.String, obj.password);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    ds = db.ExecuteDataSet(cmd);
                    obj.result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch { }
            finally
            {
                ds.Clear();
            }
            return obj;
        }

    }
}