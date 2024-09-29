using System;
using System.IO;
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
using System.Data.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Management.Automation;


namespace Unommer
{
    public partial class portal_admin_create_backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                bind();
            }
        }
        void bind()
        {
            Portal_Admin_Data dataobj = new Portal_Admin_Data();
            DataSet ds = dataobj.Fetch_School_Details_Active(Session["SchoolName"].ToString());
            grdschoolactive.DataSource = ds;
            grdschoolactive.DataBind();

        }

        protected void grdschoolactive_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField school_name = (HiddenField)grdschoolactive.SelectedRow.FindControl("hdnschoolname");

            string school_name_old= school_name.Value.ToString();
            string school_name_new = school_name_old.Replace(" ", "_");

            DateTime today = DateTime.Now;
            school_name_new = school_name_new + "_" + today.ToString("dd_MM_yyyy_hh_mm");
            school_name_new += ".bak";
            string pathname = "D:\\PowerShell_Backup\\"+school_name_new;

            var shell = PowerShell.Create();
            shell.AddScript("D:\\PowerShell_Scripts\\create_backup.ps1 -Dbname " + "\"" + school_name_old + "\""+ " -filename " + "\"" + school_name_new.ToString()+"\"");
            shell.Invoke();


            //Checking whether the backup for the database is created or not
            if(File.Exists(pathname))
            {
                string message = "Backup file of the Database is created successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
            }
            else
            {
                string message = "Failed to create backup file of the database";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }
    }
}