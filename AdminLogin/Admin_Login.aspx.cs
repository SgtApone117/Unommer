using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Unommer;
using Unommer.Models;
using Unommer.DAL;
using System.Data.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Drawing;
using System.Globalization;

namespace Unommer
{
    public partial class Admin_Login : System.Web.UI.Page
    {

       

        protected void Page_Load(object sender, EventArgs e)
        {
        
                if (!IsPostBack)
                {
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                TxtAdminEmail.Text = Session["LoginID"].ToString();
                bind();
            }
        }

        void bind()
        {
            SchoolDetails clsobj = new SchoolDetails();
            RegistrationData dataobj = new RegistrationData();
            clsobj.School_admin = TxtAdminEmail.Text.ToString();
            //Fetching School Details of the admin on page load
            DataSet ds = dataobj.GetSchoolInfo(clsobj, Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                GrdSchool.Visible = true;
                GrdSchool.DataSource = ds;
                GrdSchool.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add();
                GrdSchool.DataSource = dt;
                GrdSchool.DataBind();
            }
        }

        protected void btnschoolsub_Click(object sender, EventArgs e)
        {
            SchoolRegistration obj = new SchoolRegistration();
            obj.AdministratorEmail = Session["LoginID"].ToString();
            obj.Address = TxtSchoolAddr.Text.ToString();
            obj.TelphoneNumber = TxtSchoolTele.Text.ToString();
            obj.MobileNumber = TxtSchoolMobile.Text.ToString();
            //Updating School details by the admin
            obj = UpdateSchoolData.UpdateSchool(obj, Session["SchoolName"].ToString());
            bind();
            if (obj.Result == 1)
            {
                string message = "Updation Failed";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                nullify();
            }
            else if (obj.Result == 0)
            {
                string message = "Updation Done Successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                nullify();
            } 

        }

        protected void reset1_Click(object sender, EventArgs e)
        {
            nullify();
        }


        //On updation this will null all the textboxes
        void nullify()
        {
            TxtSchoolAddr.Text = string.Empty;
            TxtSchoolMobile.Text = string.Empty;
            TxtSchoolTele.Text = string.Empty;
        }

        

    }
}