using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    public partial class Admin_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Label lbladminemail = new Label();
                EnableViewState = true;
                if(Session["LoginID"]==null)
                {
                    Response.Redirect("log_out.aspx");
                }
                EnableViewState = true;
                lbladminemail.Text = Session["LoginID"].ToString();
                Admin_Update obj = new Admin_Update();
                obj.AdminEmail = lbladminemail.Text.ToString();
                lbladminemail.Visible = false;
                RegistrationData dataobj = new RegistrationData();
                DataSet ds = dataobj.fetch_admin_name(obj, Session["SchoolName"].ToString());
                lbladminname.Text = ds.Tables[0].Rows[0]["u_name"].ToString();
                

            }
        }
    }
}