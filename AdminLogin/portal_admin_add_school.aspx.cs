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
using System.Data.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Management.Automation;
namespace Unommer
{
    public partial class portal_admin_add_school : System.Web.UI.Page
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
            DataSet ds = dataobj.Fetch_School_Details(Session["SchoolName"].ToString());
            grdshowschool.DataSource = ds;
            grdshowschool.DataBind();

        }

        protected void grdshowschool_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField stud_id = (HiddenField)grdshowschool.SelectedRow.FindControl("hdnschoolid");
            Label stud_name = (Label)grdshowschool.SelectedRow.FindControl("lblschoolname");
            School clsobj = new School();
            Portal_Admin_Data dataobj = new Portal_Admin_Data();
            clsobj.SchoolID = Convert.ToInt32(stud_id.Value.ToString());
            
            clsobj.SchoolName = "\"" + stud_name.Text.ToString() + "\"";


            //Powershell script to create database
            var shell = PowerShell.Create();
            shell.AddScript("D:\\PowerShell_Scripts\\database_create.ps1 -schoolname "+""+clsobj.SchoolName.ToString());
            shell.Invoke();

            //Powershell script to create table to the new database
            var shell1 = PowerShell.Create();
            shell1.AddScript("D:\\PowerShell_Scripts\\all_table_create.ps1 -DestDatabase " + "" + clsobj.SchoolName.ToString());
            shell1.Invoke();

            //Powershell script to insert procedures to the new database
            var shell2 = PowerShell.Create();
            shell2.AddScript("D:\\PowerShell_Scripts\\procedure_functions_insert -DestDatabase " + "" + clsobj.SchoolName.ToString());
            shell2.Invoke();





            DataSet ds = dataobj.Update_Status_School(Session["SchoolName"].ToString(), clsobj);

            string Message = "School database created";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + Message + "');", true);
            
            bind();
        }
    }
}