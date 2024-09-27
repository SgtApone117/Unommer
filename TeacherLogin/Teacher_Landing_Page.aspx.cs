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

namespace Unommer
{
    public partial class Teacher_Landing_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CollabrationData dataobj = new CollabrationData();                
                CollabTeacherFetch clsobj = new CollabTeacherFetch();
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                clsobj.Teacher_mail = Session["LoginID"].ToString();
                DataSet ds1 = null;
                ds1 = dataobj.fetch_day_collab_teacher(clsobj, Session["SchoolName"].ToString());
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        grdshowrosterday.DataSource = ds1;
                        grdshowrosterday.DataBind();
                    }
                    else
                    {
                        grdshowrosterday.DataSource = ds1;
                        grdshowrosterday.DataBind();
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add();
                    grdshowrosterday.DataSource = dt;
                    grdshowrosterday.DataBind();
                }


            }
        }
    }
}