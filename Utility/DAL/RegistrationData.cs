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
    public class RegistrationData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();


        public DataSet FetchSchoolBoard(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_FetchSchoolBoard"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;

        }

        public DataSet ChangePassword(string School, ParentRegistration obj)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Forgot_password"))
                {
                    db.AddInParameter(cmd, "@Email", DbType.String, obj.Parent_mail);
                    db.AddInParameter(cmd, "@Password", DbType.String, obj.Pass);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }




        public static SchoolRegistration InsertSchoolRegistration(SchoolRegistration clsobj,string School)
        {
            DataSet Ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_InsertSchool"))
                {
                    db.AddInParameter(cmd, "@SchoolName", DbType.String, clsobj.SchoolName);
                    db.AddInParameter(cmd, "@Address", DbType.String, clsobj.Address);
                    db.AddInParameter(cmd, "@SchoolBoard", DbType.String, clsobj.SchoolBoard);
                    db.AddInParameter(cmd, "@City", DbType.String, clsobj.City);
                    db.AddInParameter(cmd, "@TelephoneNum", DbType.String, clsobj.TelphoneNumber);
                    db.AddInParameter(cmd, "@MobileNum", DbType.String, clsobj.MobileNumber);
                    db.AddInParameter(cmd, "@Affiliation", DbType.String, clsobj.AffiliationNumber);
                    db.AddInParameter(cmd, "@AdminName", DbType.String, clsobj.AdministratorName);
                    db.AddInParameter(cmd, "@AdminEmail", DbType.String, clsobj.AdministratorEmail);
                    db.AddInParameter(cmd, "@AdminContact", DbType.String, clsobj.AdministratorContactNum);
                    db.AddInParameter(cmd, "@RegistrationDate", DbType.String, clsobj.RegistrationDate);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    db.AddInParameter(cmd, "@ActivationCode", DbType.String, clsobj.Guid);
                    db.AddInParameter(cmd, "@Pass", DbType.String, clsobj.Pass);
                    Ds = db.ExecuteDataSet(cmd);
                    clsobj.Result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
                Ds.Clear(); 
            }
            return clsobj;
        }

        public static TeacherRegistration InsertTeacherRegistration(TeacherRegistration clsobjTea,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_InsertTeacherData"))
                {
                    db.AddInParameter(cmd, "@TeacherName", DbType.String, clsobjTea.Teacher_Name);
                    db.AddInParameter(cmd, "@TeacherMail", DbType.String, clsobjTea.Teacher_Mail);
                    db.AddInParameter(cmd, "@TeacherRegDate", DbType.String, clsobjTea.Teacher_Reg_Date);
                    db.AddInParameter(cmd, "@ActivationCode", DbType.String, clsobjTea.Guid);
                    db.AddInParameter(cmd, "@Pass", DbType.String, clsobjTea.Pass);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    db.ExecuteNonQuery(cmd);
                    clsobjTea.Result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
            return clsobjTea;
        }

        public static ParentRegistration InsertParentRegistration(ParentRegistration clsobjPar,string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_InsertParentData"))
                {
                    db.AddInParameter(cmd, "@ParentName", DbType.String, clsobjPar.Parent_Name);
                    db.AddInParameter(cmd, "@ParentMail", DbType.String, clsobjPar.Parent_mail);
                    db.AddInParameter(cmd, "@ParentRegDate", DbType.String, clsobjPar.Parent_Reg_Date);
                    db.AddInParameter(cmd, "@ActivationCode", DbType.String, clsobjPar.Guid);
                    db.AddInParameter(cmd, "@Pass", DbType.String, clsobjPar.Pass);
                    db.AddInParameter(cmd, "@Parenttype", DbType.String, clsobjPar.Parent_type);
                    db.AddOutParameter(cmd, "@Result", DbType.Int32, 10);
                    db.ExecuteNonQuery(cmd);
                    clsobjPar.Result = Convert.ToInt32(db.GetParameterValue(cmd, "@Result"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
            return clsobjPar;
        }

        public ParentRegistration GetStudentInfo(ParentRegistration clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchStudentDetails"))
                {
                    db.AddInParameter(cmd, "@Parent_mail", DbType.String, clsobj.Parent_mail);
                    db.AddInParameter(cmd, "@Parent_type", DbType.String, clsobj.Parent_type);
                    ds = db.ExecuteDataSet(cmd);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            clsobj.StudentList.Add(new StudentDetails()
                             {
                                 Student_FirstName = dr["Student_fname"].ToString(),
                                 Student_LastName = dr["Student_lname"].ToString(),
                                 Class = dr["Class"].ToString(),
                                 Section = dr["Section"].ToString(),
                                 RollNo = Convert.ToInt32(dr["Roll_no"])
                             });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Clear();
            }
            return clsobj;
        }

        public DataSet GetSchoolInfo(SchoolDetails clsobj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchSchoolDetails"))
                {
                    db.AddInParameter(cmd, "@AdminMail", DbType.String, clsobj.School_admin);
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
        public DataSet GetRosterDetails(RosterDetails obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_FetchRosterDetails"))
                {
                    db.AddInParameter(cmd, "@Teacher_id", DbType.Int16, obj.Teacher_id);
                    db.AddInParameter(cmd, "@Month", DbType.String, obj.month);
                    db.AddInParameter(cmd, "@Year", DbType.String, obj.year);
                    db.AddOutParameter(cmd, "@Result", DbType.Int16, obj.result);

                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex)
            { 
            }
            finally {
            }
            return ds;

        }

        public DataSet GetTeacherRoster(Teachers_Data_Roster obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Create_Roster"))
               {
                    db.AddInParameter(cmd, "@StartDate", DbType.DateTime, obj.StartDate);
                    db.AddInParameter(cmd, "@EndDate", DbType.DateTime, obj.EndDate);
                    db.AddInParameter(cmd, "@TempName", DbType.String, obj.TemplateName);
                    db.AddInParameter(cmd, "@Month", DbType.String, obj.Month);
                    db.AddInParameter(cmd, "@Year", DbType.String, obj.Year);
                    db.AddInParameter(cmd, "@Teacherid", DbType.Int32, obj.Teacher_id);
                    db.AddInParameter(cmd, "@Template_Name", DbType.String, obj.TemplateName);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            { 
            
            }
            return ds;
        }
        public DataSet GetTeacherId(Teachers_Data_Roster obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_Fetch_Teacherid"))
                {
                    db.AddInParameter(cmd, "@TeacherMail", DbType.String, obj.Teacher_Mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            { 
            
            }
            return ds;
        }

        public DataSet UpdateAdmin(Admin_Update obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_UpdateAdminPass"))
                {
                    db.AddInParameter(cmd, "@AdminEmail", DbType.String, obj.AdminEmail);
                    db.AddInParameter(cmd, "@NewPass", DbType.String, obj.NewPass);
                    //db.AddInParameter(cmd, "@CurrPass", DbType.String, obj.Currentpass);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex)
            { 
            
            }
            return ds;
        }

        public DataSet fetch_admin_name(Admin_Update obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_fetch_admin_name"))
                {
                    db.AddInParameter(cmd, "@AdminEmail", DbType.String, obj.AdminEmail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex) 
            { }
            return ds;
        }

        public DataSet fetch_teacher_subjects(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_fetch_teacher_subjects"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_class(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_fetch_class"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_section(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_fetch_section"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_subject(string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_fetch_subject"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_status(string School)
        {
            Database db = new SqlDatabase(DBConnection.Connection(School));
            DataSet ds = null;
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_fetch_status"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;

        }

        public DataSet fetch_template_name(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_fetch_template"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_template_name_view_template(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_fetch_template_view"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }


        public DataSet fetch_teacher_month(string School)
        {
            DataSet ds= null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_insert_teacher_month"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet search_teacher_month(Teachers obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_search_teacher_month"))
                {
                    db.AddInParameter(cmd, "@Search", DbType.String,obj.FirstName);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet search_teacher_data(Teachers obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_search_teacher_details"))
                {
                    db.AddInParameter(cmd, "@Search", DbType.String, obj.FirstName);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }


        public DataSet search_teacher_fetch_month(Teachers obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_search_teacher_insert_month"))
                {
                    db.AddInParameter(cmd, "@TeachName", DbType.String, obj.FirstName);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet view_admin_available_template(avail_temp obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd = db.GetStoredProcCommand("Sp_View_Admin_Available_Template"))
                {
                    db.AddInParameter(cmd, "@TempName", DbType.String, obj.Template_Name);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet view_admin_available_template_status(avail_temp obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_View_Admin_Available_Template_Status_Fetch"))
                {
                    db.AddInParameter(cmd, "@TempName", DbType.String, obj.Template_Name);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }


        public DataSet delete_available_template(avail_temp obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Delete_Available_Template"))
                {
                    db.AddInParameter(cmd, "@TempName", DbType.String, obj.Template_Name);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_school_name(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Fetch_School_Name"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }


        
    }
}