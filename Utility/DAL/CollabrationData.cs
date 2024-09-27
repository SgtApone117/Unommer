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
    public class CollabrationData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public DataSet CollabDataSchool(CollabStudDetails clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchCollabStudent"))
                {
                    db.AddInParameter(cmd, "@Parent_email", DbType.String, clsobj.parent_email);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex)
            {
                
            }
          
            return ds;
         }

        public DataSet FetchTeachData(TeacherInfo clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try{
                using (DbCommand cmd= db.GetStoredProcCommand("Sp_FetchTeachData"))
                {
                    db.AddInParameter(cmd,"@teacher_email",DbType.String,clsobj.teacher_email);
                    ds=db.ExecuteDataSet(cmd);
                }

            }
            catch(Exception ex)
            {

            }
            return ds;
        }

        public DataSet FetchStudData(StudentInfo clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_FetchStudentData"))
                {
                    db.AddInParameter(cmd, "@class_name", DbType.String, clsobj.class_name);
                    db.AddInParameter(cmd, "@section", DbType.String, clsobj.section);
                    ds = db.ExecuteDataSet(cmd);

                }
            }
            catch(Exception ex)
            {
            }
            return ds;
        }

        public DataSet CollabParentData(CollabParentData clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchCollabParent"))
                {
                    db.AddInParameter(cmd, "@Parent_email", DbType.String, clsobj.parent_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
                
            }
            catch (Exception ex)
            { 
            
            }
            return ds;
        }


        public DataSet CollabTeachDetails(CollabTeacherDetails clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchCollabTeach"))
                {
                    db.AddInParameter(cmd, "@class", DbType.String, clsobj.Class);
                    db.AddInParameter(cmd, "@section", DbType.String, clsobj.Section);
                    db.AddInParameter(cmd, "@subject", DbType.String, clsobj.Teacher_Subject);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public  DataSet insert_update_collab_request(collab_request clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("[Sp_Get_Collab_Request]"))
                {
                    db.AddInParameter(cmd, "@collab_type", DbType.String, clsobj.collab_type);
                    db.AddInParameter(cmd, "@student_id", DbType.Int32, clsobj.student_id);
                    db.AddInParameter(cmd, "@requestor", DbType.String, clsobj.requestor);
                    db.AddInParameter(cmd, "@class_no", DbType.String, clsobj.class_no);
                    db.AddInParameter(cmd, "@section", DbType.String, clsobj.section);
                    db.AddInParameter(cmd, "@subject", DbType.String, clsobj.subject);
                    db.AddInParameter(cmd, "@teacher_id", DbType.Int32, clsobj.teacher_id);
                    db.AddInParameter(cmd, "@parent_id", DbType.String, clsobj.parent_id);
                    db.AddInParameter(cmd, "@start_time", DbType.Decimal, clsobj.start_time);
                    db.AddInParameter(cmd, "@end_time", DbType.Decimal, clsobj.end_time);
                    db.AddInParameter(cmd, "@Date", DbType.String, clsobj.date);
                    db.AddInParameter(cmd, "@teachermail", DbType.String, clsobj.teacher_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex)
            { 
            
            }

            return ds;
        }

        public DataSet insert_update_collab_teach_reuqest(Teacher_fetch_Roster obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Teacher_Collab_Request"))
                {
                    db.AddInParameter(cmd, "@start_time", DbType.Decimal, obj.start_time);
                    db.AddInParameter(cmd, "@end_time", DbType.Decimal, obj.end_time);
                    db.AddInParameter(cmd, "@teacher_id", DbType.Int32, obj.teacher_id);
                    db.AddInParameter(cmd, "@date", DbType.String, obj.date);
                    db.AddInParameter(cmd, "@student_id", DbType.Int32, obj.student_id);
                    db.AddInParameter(cmd, "@collab_type", DbType.String, obj.collab_type);
                    db.AddInParameter(cmd, "@parent_id", DbType.String, obj.parent_id);
                    db.AddInParameter(cmd, "@subject", DbType.String, obj.subject);
                    db.AddInParameter(cmd, "@class_no", DbType.String, obj.class_no);
                    db.AddInParameter(cmd, "@section", DbType.String, obj.section);
                    db.AddInParameter(cmd, "@requestor", DbType.String, obj.requestor);
                    db.AddInParameter(cmd, "@topic", DbType.String, obj.topic);
                   // db.AddInParameter(cmd, "@teachermail", DbType.String, obj.teacher_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            { 
            
            }
            return ds;
        }

        public DataSet fetch_collab_requests(CollabTeacherFetch obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Fetch_Teacher_Collab_Request"))
                {
                    db.AddInParameter(cmd, "@TeacherEmail", DbType.String, obj.Teacher_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex) 
            { 
            
            }
            return ds;
        }

        public DataSet delete_collab_requests(CollabTeachDelete obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try 
            { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Delete_Teacher_Collab_Request"))
                {

                    db.AddInParameter(cmd, "@RequestId", DbType.Int32, obj.req_id);
                    db.AddInParameter(cmd, "@start_time", DbType.Decimal, obj.start_time);
                    db.AddInParameter(cmd, "@end_time", DbType.Decimal, obj.end_time);
                    db.AddInParameter(cmd, "@date", DbType.String, obj.req_date);
                    db.AddInParameter(cmd, "@teacher_mail", DbType.String, obj.teacher_mail);
                    db.AddInParameter(cmd, "@choice", DbType.String, obj.choice);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex) 
            { 
            }
            return ds;
        }

        public DataSet fetch_collab_parent(ParentCollabDetails obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Get_Parent_Collaboration"))
                {
                    db.AddInParameter(cmd, "@ParentMail", DbType.String, obj.parent_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet delete_collab_parent(CollabParentDelete obj,string School)
        {

            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Delete_Parent_Collabration"))
                {
                    db.AddInParameter(cmd, "@RequestId", DbType.Int32, obj.req_id);
                    db.AddInParameter(cmd, "@TeacherMail", DbType.String, obj.teachername);
                    db.AddInParameter(cmd, "@start_time", DbType.Decimal, obj.start_time);
                    db.AddInParameter(cmd, "@end_time", DbType.Decimal, obj.end_time);
                    db.AddInParameter(cmd, "@date", DbType.String, obj.req_date);
                    db.AddInParameter(cmd, "@choice", DbType.String, obj.choice);
                    db.AddInParameter(cmd, "@reason", DbType.String, obj.reason);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

       public DataSet fetch_roster_teacher_mail(roster_info_fetch obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Fetch_Roster_Teacher"))
                {
                    db.AddInParameter(cmd, "@TeacherMail", DbType.String, obj.teacher_email);
                    db.AddInParameter(cmd, "@Month", DbType.String, obj.month);
                    db.AddInParameter(cmd, "@Year", DbType.String, obj.year);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            {
 
            }
            return ds;
        }

        public DataSet fetch_summary_details(roster_info_fetch obj,string School)
       {
           DataSet ds = null;
           Database db = new SqlDatabase(DBConnection.Connection(School));
           try { 
            using(DbCommand cmd= db.GetStoredProcCommand("Sp_Summary_Collaboration"))
            {
                db.AddInParameter(cmd, "@Month", DbType.String, obj.month);
                db.AddInParameter(cmd, "@Year", DbType.Int32, obj.year);
                db.AddInParameter(cmd, "@Teacheremail", DbType.String, obj.teacher_email);
                ds = db.ExecuteDataSet(cmd);
            }
           }
           catch { }
           return ds;
       }

        public DataSet update_roster(roster_modify obj,string School)
       {
           DataSet ds = null;
           Database db = new SqlDatabase(DBConnection.Connection(School));
           try
           {
               using (DbCommand cmd= db.GetStoredProcCommand("Sp_Update_Roster_Teacher"))
               {
                   db.AddInParameter(cmd, "@TeacherMail", DbType.String, obj.teacher_email);
                   db.AddInParameter(cmd, "@date_change", DbType.String, obj.date);
                   db.AddInParameter(cmd, "@Array_1", DbType.String, obj.nstring);
                   ds = db.ExecuteDataSet(cmd);
               }
           }
           catch { }
           return ds;
       }

        public DataSet fetch_day_collab_teacher(CollabTeacherFetch obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Fetch_Day_Collab_Teacher"))
                {
                    db.AddInParameter(cmd, "@teacher_email", DbType.String, obj.Teacher_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch{}
            return ds;
        }

        public DataSet fetch_day_collab_parent(CollabParentData obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_Fetch_Day_Collab_Parent"))
                {
                    db.AddInParameter(cmd, "@parent_email", DbType.String, obj.parent_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_subjects_class(CollabStudDetails obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Fetch_Subject_Class"))
                {
                    db.AddInParameter(cmd, "@Class", DbType.String, obj.Class);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }
    }
}