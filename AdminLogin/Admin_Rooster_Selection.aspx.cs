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
    public partial class Admin_Rooster_Selection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //On page load bind template name and drop down lists
            if (!IsPostBack)
            {
                LabelRosterYear.Text = DateTime.Now.Year.ToString();
                DataSet ds = null;
                RegistrationData dataobj = new RegistrationData();
                ds = dataobj.fetch_template_name(Session["SchoolName"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DropDownListTemplateSelctionRoster.DataSource = ds;
                        DropDownListTemplateSelctionRoster.DataTextField = "Template_Name";
                        DropDownListTemplateSelctionRoster.DataValueField = "Template_Name";
                        DropDownListTemplateSelctionRoster.DataBind();
                        DropDownListTemplateSelctionRoster.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }

                TeacherData dataobj2 = new TeacherData();
                DataSet ds2 = dataobj2.Fetch_Teacher_Name(Session["SchoolName"].ToString());
                TxtTeacherEmailRoster.DataSource = ds2;
                TxtTeacherEmailRoster.DataTextField = "teacher_name";
                TxtTeacherEmailRoster.DataValueField = "teacher_mail";
                TxtTeacherEmailRoster.DataBind();
                TxtTeacherEmailRoster.Items.Insert(0, new ListItem("--Select--", "0"));



                DebriefData dataobj1 = new DebriefData();
                roster_info_fetch clsobj1 = new roster_info_fetch();
                clsobj1.year = LabelRosterYear.Text;
                DataSet ds1 = dataobj1.fetch_month(clsobj1, Session["SchoolName"].ToString());
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ddlrostermonth.DataSource = ds1;
                        ddlrostermonth.DataTextField = "month_name";
                        ddlrostermonth.DataValueField = "month_id";
                        ddlrostermonth.DataBind();
                    }
                }
            }         

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DatePicker1.Visible = true;
        }

        //On Showing it in Textbox when date is picked
        protected void DatePicker1_SelectionChanged(object sender, EventArgs e)
        {
            TxtTakeDate1.Text = DatePicker1.SelectedDate.ToLongDateString();
            DatePicker1.Visible = true;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DatePicker2.Visible = true;
        }


        //On Showing it in Textbox when date is picked
        protected void DatePicker2_SelectionChanged(object sender, EventArgs e)
        {
            TxtTakeDate2.Text = DatePicker2.SelectedDate.ToLongDateString();
            DatePicker2.Visible = true;
        }

        protected void TxtTeacherEmailRoster_TextChanged(object sender, EventArgs e)
        {

            Teachers_Data_Roster clsobj = new Teachers_Data_Roster();
            RegistrationData dataobj = new RegistrationData();
            DataSet ds = null;
            clsobj.Teacher_Mail = TxtTeacherEmailRoster.SelectedValue.ToString();
            if(clsobj.Teacher_Mail!="0")
            {
                ds = dataobj.GetTeacherId(clsobj, Session["SchoolName"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Teacher_id"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Teacher_id"]);
                        Grdteachername.Visible = true;
                        Grdteachername.DataSource = ds;
                        Grdteachername.DataBind();
                    }
                    else
                    {

                        string message = "Teacher not found.Please select a different Teacher Mail";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    }
                }
                else
                {
                    string message = "Teacher not found.Please select a different Teacher Mail";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }
            else
            {
                Grdteachername.Visible = false;
            }
            
        }



        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            Teachers_Data_Roster clsobj = new Teachers_Data_Roster();
            RegistrationData dataobj = new RegistrationData();
            DataSet ds = null;

            clsobj.Teacher_Name = TxtTeacherEmailRoster.SelectedValue.ToString();
            clsobj.StartDate = Convert.ToDateTime(TxtTakeDate1.Text);
            clsobj.EndDate = Convert.ToDateTime(TxtTakeDate2.Text);
            clsobj.Month = ddlrostermonth.SelectedItem.ToString();
            clsobj.Year = LabelRosterYear.Text.ToString();
            clsobj.TemplateName = DropDownListTemplateSelctionRoster.SelectedValue.ToString();
            clsobj.Teacher_id = Convert.ToInt32(Session["Teacher_id"]);


            //Here the roster is added to the subsequent teacher
            ds = dataobj.GetTeacherRoster(clsobj, Session["SchoolName"].ToString());
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Checker"])==0)
            {
                string message = "Roster Created Successfully";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
            }
            else
            {
                string message = "Roster Creation Failed! Roster already exists";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }
        


        protected void ddlrostermonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            //On selecting a month, the 1st day and last day of the month is to be selected automatically  
            if (Convert.ToInt32(ddlrostermonth.SelectedValue) == DatePicker1.TodaysDate.Month)
            {
                DatePicker1.SelectedDate = new DateTime(DatePicker1.TodaysDate.Year,
                                            Convert.ToInt32(ddlrostermonth.SelectedValue),
                                            DatePicker1.TodaysDate.Day);
                TxtTakeDate1.Text = DatePicker1.SelectedDate.ToLongDateString();

                DatePicker1.VisibleDate = new DateTime(DatePicker1.TodaysDate.Year,
                                                 Convert.ToInt32(ddlrostermonth.SelectedValue),
                                                 1);
            }
            else
            {
                DatePicker1.SelectedDate = new DateTime(DatePicker1.TodaysDate.Year,
                                                Convert.ToInt32(ddlrostermonth.SelectedValue),
                                                1);
                TxtTakeDate1.Text = DatePicker1.SelectedDate.ToLongDateString();
                DatePicker1.VisibleDate = new DateTime(DatePicker1.TodaysDate.Year,
                                                 Convert.ToInt32(ddlrostermonth.SelectedValue),
                                                 1);
            }

            if (Convert.ToInt32(ddlrostermonth.SelectedValue) == (DatePicker2.TodaysDate.Month))
            {
                DatePicker2.SelectedDate = new DateTime(DatePicker2.TodaysDate.Year,
                                            Convert.ToInt32(ddlrostermonth.SelectedValue),
                                           DateTime.DaysInMonth((DatePicker2.TodaysDate.Year), Convert.ToInt32(ddlrostermonth.SelectedValue)));
                TxtTakeDate2.Text = DatePicker2.SelectedDate.ToLongDateString();

                DatePicker2.VisibleDate = new DateTime(DatePicker2.TodaysDate.Year,
                                                 Convert.ToInt32(ddlrostermonth.SelectedValue),
                                                 1);


            }
            else
            {
                DatePicker2.SelectedDate = new DateTime(DatePicker2.TodaysDate.Year,
                                                Convert.ToInt32(ddlrostermonth.SelectedValue),
                                                DateTime.DaysInMonth((DatePicker2.TodaysDate.Year), Convert.ToInt32(ddlrostermonth.SelectedValue)));


                DatePicker2.VisibleDate = new DateTime(DatePicker2.TodaysDate.Year,
                                                 Convert.ToInt32(ddlrostermonth.SelectedValue),
                                                 2);
                TxtTakeDate2.Text = DatePicker2.SelectedDate.ToLongDateString();
            }
        }
    }
}