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
    public partial class Admin_Modify_Delete_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Teacher_Record();
            }
        }


        //Fetching record of teachers
        public void Teacher_Record()
        {
            TeacherData clsobj = new TeacherData();
            DataSet ds = null;
            ds = clsobj.GetTeacherRecordInfo(Session["SchoolName"].ToString());
            gvDetails.Visible = true;
            gvDetails.DataSource = ds;
            gvDetails.DataBind();

        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetails.PageIndex = e.NewPageIndex;
            Teacher_Record();
        }


        //On search find teacher and bind it
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Teachers obj = new Teachers();
                obj.FirstName = txtsearch.Text.ToString();
                RegistrationData dataobj = new RegistrationData();
                DataSet ds = dataobj.search_teacher_data(obj, Session["SchoolName"].ToString());
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
            }
            catch (Exception ex) { }
        }
       
    }
}