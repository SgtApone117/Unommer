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

namespace Unommer
{
    public partial class portal_admin_inactivate_school : System.Web.UI.Page
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
            grdactiveschool.DataSource = ds;
            grdactiveschool.DataBind();
        }

        protected void grdactiveschool_SelectedIndexChanged(object sender, EventArgs e)
        {
            HiddenField school_id = (HiddenField)grdactiveschool.SelectedRow.FindControl("hdnschoolid");
            HiddenField admin_mail = (HiddenField)grdactiveschool.SelectedRow.FindControl("hdnadminemail");
            School obj = new School();
            Portal_Admin_Data dataobj = new Portal_Admin_Data();
            obj.SchoolID = Convert.ToInt32(school_id.Value.ToString());
            obj.adminmail = admin_mail.Value.ToString();
            DataSet ds = dataobj.Update_Active_School(Session["SchoolName"].ToString(), obj);
            bind();
        }
    }
}