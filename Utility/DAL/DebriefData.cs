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
    public class DebriefData
    {
        //private static readonly string ConnectionString = DBConnection.Connection();

        public DataSet fetch_debrief_data(Debrief obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd=db.GetStoredProcCommand("Sp_fetch_debrief"))
                {
                    db.AddInParameter(cmd, "@TeacherEmail", DbType.String, obj.teacher_email);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch(Exception ex)
            {
            
            }
            return ds;
        }

        public DataSet insert_debrief_data(DebriefInsert obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_Insert_Debrief"))
                {
                    db.AddInParameter(cmd, "@RequestId", DbType.Int32, obj.request_id);
                    db.AddInParameter(cmd, "@DebriefSubject", DbType.String, obj.debrief_subject);
                    db.AddInParameter(cmd, "@File", DbType.String,obj.filename);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch (Exception ex) 
            { }
            return ds;
        }

        public DataSet fetch_month(roster_info_fetch obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using(DbCommand cmd= db.GetStoredProcCommand("Sp_fetch_month"))
                {
                    db.AddInParameter(cmd, "@Year", DbType.String, obj.year);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_year(string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try
            {
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_fetch_year"))
                {
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }

        public DataSet fetch_debrief_parent(Debrief_Parent obj,string School)
        {
            DataSet ds = null;
            Database db = new SqlDatabase(DBConnection.Connection(School));
            try { 
                using (DbCommand cmd = db.GetStoredProcCommand("Sp_fetch_parent_collab"))
                {
                    db.AddInParameter(cmd, "@Parentemail", DbType.String, obj.parent_mail);
                    ds = db.ExecuteDataSet(cmd);
                }
            }
            catch { }
            return ds;
        }
    }
}