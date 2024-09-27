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
using AjaxControlToolkit;

namespace Unommer
{
    public partial class View_Delete_Template : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            
            }
        }
        public void bind()
        {
            DataSet ds = null;
            RegistrationData dataobj = new RegistrationData();
            ds = dataobj.fetch_template_name_view_template(Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                ddlselecttemp.DataSource = ds;
                ddlselecttemp.DataTextField = "Template_Name";
                ddlselecttemp.DataValueField = "Template_Name";
                ddlselecttemp.DataBind();
                ddlselecttemp.Items.Insert(0, new ListItem("--Select Template--", "0"));
            }
        }

        protected void ddlselecttemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            avail_temp obj = new avail_temp();
            RegistrationData dataobj = new RegistrationData();
            obj.Template_Name = ddlselecttemp.SelectedValue.ToString();
            DataSet ds1 = dataobj.view_admin_available_template_status(obj, Session["SchoolName"].ToString());
            Session["Template_Status"] = ds1.Tables[0].Rows[0]["Status"];
            if(string.Compare(ds1.Tables[0].Rows[0]["Status"].ToString(),"Active") == 0)
            {
                btndeletetemplate.Text = "Inactivate Template";
            }
            else
            {
                btndeletetemplate.Text = "Activate Template";
            }
            if (string.Compare(obj.Template_Name, "0") != 0)
            {
                //For viewing the template
                DataSet ds = dataobj.view_admin_available_template(obj, Session["SchoolName"].ToString());
                grdviewtemplate.Visible = true;
                grdviewtemplate.DataSource = ds;
                grdviewtemplate.DataBind();
                pnlbutton.Visible = true;
            }
            else
            {
                grdviewtemplate.Visible = false;
                pnlbutton.Visible = false;
            }

        }

        protected void btndeletetemplate_Click(object sender, EventArgs e)
        {
            avail_temp obj = new avail_temp();
            RegistrationData dataobj = new RegistrationData();
            string message ="";
            obj.Template_Name = ddlselecttemp.SelectedValue.ToString();
            DataSet ds = dataobj.delete_available_template(obj, Session["SchoolName"].ToString());
            if(string.Compare(btndeletetemplate.Text.ToString(),"Inactivate Template")==0)
            {
                message ="Template Inactivated Successfully";
            }
            else
            {
                message = "Template Activated Successfully";
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
            grdviewtemplate.DataSource = null;
            grdviewtemplate.DataBind();
            pnlbutton.Visible = false;
            
            bind();
        }
    }
}