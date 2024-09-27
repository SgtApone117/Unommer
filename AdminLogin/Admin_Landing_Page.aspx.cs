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
    public partial class Admin_Landing_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    RegistrationData dataobj = new RegistrationData();
                    //To bind the teacher data to the gridview
                    DataSet ds = dataobj.fetch_teacher_month(Session["SchoolName"].ToString());
                    grdteachermonth.DataSource = ds;
                    grdteachermonth.DataBind();
                }
                catch (Exception ex) { }
            }
        }

        //On page index change we are binding new data each time
        protected void grdteachermonth_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdteachermonth.PageIndex = e.NewPageIndex;
                RegistrationData dataobj = new RegistrationData();
              
                DataSet ds = dataobj.fetch_teacher_month(Session["SchoolName"].ToString());
                grdteachermonth.DataSource = ds;
                grdteachermonth.DataBind();
            }
            catch (Exception ex) { }
        }


        //On the search button click
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Teachers obj = new Teachers();
                obj.FirstName = txtsearch.Text.ToString();
                RegistrationData dataobj = new RegistrationData();
                DataSet ds = dataobj.search_teacher_month(obj, Session["SchoolName"].ToString());
                grdteachermonth.DataSource = ds;
                grdteachermonth.DataBind();
            }
            catch (Exception ex) { }
        }
    }
}
