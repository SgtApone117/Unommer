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
    public partial class Teacher_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CollabrationData dataobj = new CollabrationData();
                TeacherInfo obj = new TeacherInfo();
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                lblteachemail.Text = Session["LoginID"].ToString();
                DataSet ds = null;
                obj.teacher_email = lblteachemail.Text.ToString();
                lblteachemail.Visible = false;
                ds = dataobj.FetchTeachData(obj, Session["SchoolName"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblteachername.Text = ds.Tables[0].Rows[0]["teacher_name"].ToString();
                    }
                }
               
            }
        }
    }
}