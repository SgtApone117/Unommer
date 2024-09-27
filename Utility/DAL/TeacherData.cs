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
    public class TeacherData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();
        public static Teachers InsertTeacherDetails(Teachers clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_InsertTeacherData"))
                {
                    db.AddInParameter(cmd, "@TeacherName", DbType.String, clsobj.FirstName);
                    //db.AddInParameter(cmd, "LastName", DbType.String, clsobj.LastName);
                    db.AddInParameter(cmd, "@TeacherMail", DbType.String, clsobj.Email);
                    db.AddInParameter(cmd, "@Subjects", DbType.String, clsobj.Subjects);
                     db.AddInParameter(cmd, "@Status", DbType.String, clsobj.Status);
                    db.AddInParameter(cmd, "@Designation", DbType.String, clsobj.Designation);
                    db.AddInParameter(cmd, "@Class", DbType.String, clsobj.Class);
                    db.AddInParameter(cmd, "@Section", DbType.String, clsobj.Section);
                    db.AddInParameter(cmd, "@Pass", DbType.String, clsobj.Pass);
                    db.AddInParameter(cmd, "@ActivationCode", DbType.String, clsobj.Guid);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    ds = db.ExecuteDataSet(cmd);
                    clsobj.Result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return clsobj;
        }

        public DataSet GetTeacherRecordInfo(string School)
        {
            //Teachers clsobj = new Teachers();
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Teacher_Record"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet UpdateTeacherDetails(Teachers clsobj,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Update_Teacher_Details"))
                {
                    //db.AddInParameter(cmd, "@Teacher_name", DbType.String, clsobj.FirstName);
                    db.AddInParameter(cmd, "@teacher_subject_id", DbType.Int32, clsobj.Id);
                    db.AddInParameter(cmd, "@Teacher_email", DbType.String, clsobj.Email);
                    db.AddInParameter(cmd, "@Designation", DbType.String, clsobj.Designation);
                    db.AddInParameter(cmd, "@Class", DbType.String, clsobj.Class);
                    db.AddInParameter(cmd, "@Subject", DbType.String, clsobj.Subjects);
                    db.AddInParameter(cmd, "@Section", DbType.String, clsobj.Section);
                    db.AddInParameter(cmd, "@Status", DbType.String, clsobj.Status);
                    //db.AddInParameter(cmd, "@Teacher_lname", DbType.String, clsobj.LastName);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet FetchTeacherName(Teachers obj,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try { 
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchTeacherName"))
                {
                    db.AddInParameter(cmd, "@TeacherMail",DbType.String,obj.Email);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex)
            {
            
            }
            return ds;
        }

        public DataSet FetchTeacherStatus(string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchTeach_Status"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
 
            }
            return ds;
        }

        public DataSet CheckTeacherCollab(Teachers obj,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_Check_Teacher_Collab"))
                {
                    db.AddInParameter(cmd, "@TeacherMail", DbType.String, obj.Email);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;

        }

        public DataSet Fetch_Teacher_Name(string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Fetch_Teacher_Name"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataTable fetch_teacher_all_record(Teachers obj,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            DataTable dt = null;
            try {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Fetch_Teacher_All_Record"))
                {
                    db.AddInParameter(cmd, "@TeacherMail", DbType.Int32, obj.Id);
                    ds = db.ExecuteDataSet(cmd);
                    dt = ds.Tables[0];
                }
            }
            catch { }
            return dt;
        }

        public DataSet insert_teacher_subject(Teachers obj,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Insert_Teacher_Subject"))
                {
                    db.AddInParameter(cmd, "@TeacherId", DbType.Int32, obj.Id);
                    db.AddInParameter(cmd, "@Subject", DbType.String, obj.Subjects);
                    db.AddInParameter(cmd, "@Class", DbType.String, obj.Class);
                    db.AddInParameter(cmd, "@Section", DbType.String, obj.Section);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet update_teacher_subject(Teachers obj,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Update_Teacher_Subject"))
                {
                    //db.AddInParameter(cmd, "@TeacherId", DbType.Int32, obj.Id);
                    db.AddInParameter(cmd, "@Subject", DbType.String, obj.Subjects);
                    db.AddInParameter(cmd, "@Class", DbType.String, obj.Class);
                    db.AddInParameter(cmd, "@Section", DbType.String, obj.Section);
                    db.AddInParameter(cmd, "@Status", DbType.String, obj.Status);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        
    }
}