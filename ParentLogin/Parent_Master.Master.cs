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
    public partial class Parent_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CollabrationData dataobj = new CollabrationData();
                CollabParentData obj = new CollabParentData();
                if (Session["LoginID"]==null)
                {
                    Response.Redirect("log_out.aspx");
                }
                lblparentemail.Text = Session["LoginID"].ToString();

                obj.parent_mail = lblparentemail.Text.ToString();
                DataSet ds=dataobj.CollabParentData(obj,Session["SchoolName"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbparentname.Text = ds.Tables[0].Rows[0]["u_name"].ToString();
                    }
                }
            }
            
        }
    }
}