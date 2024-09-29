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
    public partial class View_Roster_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DebriefData dataobj1 = new DebriefData();
                DataSet ds1 = dataobj1.fetch_year(Session["SchoolName"].ToString());
                ddlyear.DataSource = ds1;
                ddlyear.DataTextField = "year_no";
                ddlyear.DataValueField = "year_no";
                ddlyear.DataBind();
                ddlyear.Items.Insert(0, new ListItem("--Select--", "0"));

                ddlmonth.Visible = false;
                lblmonth.Visible = false;
                pnlviewrostleg.Visible = false;
                
            }
        }

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind();

            lbltemplate.Visible = true;
            grdsumarry.Visible = true;

            databind_summary();
        }

        void databind_summary()
        {
            roster_info_fetch obj = new roster_info_fetch();
            Label lblteachemail = (Label)Master.FindControl("lblteachemail");
            obj.teacher_email = lblteachemail.Text.ToString();
            obj.month = ddlmonth.SelectedValue.ToString();
            obj.year = ddlyear.SelectedValue.ToString();

            CollabrationData dataobj = new CollabrationData();
            DataSet ds = dataobj.fetch_summary_details(obj, Session["SchoolName"].ToString());
            if(ds.Tables.Count>0)
            {
                if(ds.Tables[0].Rows[0]["Scheduled"].ToString()!="")
                {
                    grdsumarry.DataSource = ds;
                    grdsumarry.DataBind();
                    pnlsummary.Visible = true;
                }
                else
                {

                    pnlsummary.Visible = false;

                   
                }
            }
            else
            {
                pnlsummary.Visible = false;
               
            }

        }


        void databind()
        {
            roster_info_fetch obj = new roster_info_fetch();
            Label lblteachemail = (Label)Master.FindControl("lblteachemail");
            obj.teacher_email = lblteachemail.Text.ToString();
            obj.month = ddlmonth.SelectedValue.ToString();
            obj.year = ddlyear.SelectedValue.ToString();

            CollabrationData dataobj = new CollabrationData();
            //For fetching roster of the teacher
            DataSet ds = dataobj.fetch_roster_teacher_mail(obj, Session["SchoolName"].ToString());
            if(ds.Tables.Count>0)
            {
                pnlviewrostleg.Visible = true;
                grdviewroster.DataSource = ds;
                grdviewroster.DataBind();
            }
            else
            {
                pnlviewrostleg.Visible = false;

                DataTable dt = new DataTable();
                dt.Columns.Add();
                grdviewroster.DataSource = dt;
                grdviewroster.DataBind();
            }
            
        }

        protected void grdviewroster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int i = 2;
                string ControlName = "chk";
                int ControlNumber = 1;
                CultureInfo gbCulture = new CultureInfo("en-GB");
                DateTime today = DateTime.Today;

                Label lbldate = (Label)e.Row.FindControl("lbldate");

                DateTime rowdatime = Convert.ToDateTime(lbldate.Text);
                
                    e.Row.Enabled = false;
                if (lbldate != null || lbldate.Text != "")
                {
                    DateTime date = Convert.ToDateTime(lbldate.Text);
                    lbldate.Text = string.Format("{0:dd-MMM-yyyy}", date);
                }

                for (int j = 540; j <= 1080; j = j + 15)
                {
                    for (; i <= 37; )
                    {                                              
                        CheckBox ddl = (CheckBox)e.Row.Cells[i].FindControl(ControlName + ControlNumber);
                        Label lblday = (Label)e.Row.FindControl("lblday");
                        TableCell cell = e.Row.Cells[i];
                        TableCell cell1 = e.Row.Cells[1];

                        if (lblday.Text == "Monday")
                        {
                            cell1.BackColor = Color.Bisque;
                        }
                        else if (lblday.Text == "Tuesday")
                        {
                            cell1.BackColor = Color.Thistle;
                        }
                        else if (lblday.Text == "Wednesday")
                        {
                            cell1.BackColor = Color.Azure;
                        }
                        else if (lblday.Text == "Thursday")
                        {
                            cell1.BackColor = Color.BlanchedAlmond;
                        }
                        else if (lblday.Text == "Friday")
                        {
                            cell1.BackColor = Color.PaleGoldenrod;
                        }
                        else if (lblday.Text == "Saturday")
                        {
                            cell1.BackColor = Color.OldLace;
                        }
                        else if (lblday.Text == "Sunday")
                        {
                            cell1.BackColor = Color.PowderBlue;
                        }

                        if (ddl.Enabled == true)
                        {
                            cell.BackColor = Color.FromArgb(0, 204, 0);

                            if (ddl.Checked == true)
                            {
                                ddl.Enabled = false;
                                cell.BackColor = Color.Coral;
                            }
                            double k = (double)j / 60;
                            double a = k;
                            a = Math.Floor(a) + ((a - Math.Floor(a)) * 60 / 100);
                            string c = string.Format("{0:N2}", a);
                            cell.ToolTip = c;
                        }
                        else if (ddl.Enabled == false)
                        {

                            cell.BackColor = Color.Maroon;
                            ddl.Enabled = true;
                            if (ddl.Checked == true)
                            {
                                ddl.Enabled = false;
                                cell.BackColor = Color.Orange;
                            }
                            double k = (double)j / 60;
                            double a = k;
                            a = Math.Floor(a) + ((a - Math.Floor(a)) * 60 / 100);
                            string c = string.Format("{0:N2}", a);
                            cell.ToolTip = c;
                        }
                        i++;
                        ControlNumber++;
                        break;
                    }
                }


            }
        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmonth.Visible = true;
            ddlmonth.Visible = true;
            roster_info_fetch obj = new roster_info_fetch();
            obj.year = ddlyear.SelectedValue.ToString();
            
            DebriefData dataobj1 = new DebriefData();
            DataSet ds2 = dataobj1.fetch_month(obj, Session["SchoolName"].ToString());
            ddlmonth.DataSource = ds2;
            ddlmonth.DataTextField = "month_name";
            ddlmonth.DataValueField = "month_name";
            ddlmonth.DataBind();
            ddlmonth.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void grdviewroster_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                for (int i = 0; i < grdviewroster.Columns.Count - 1; i++)
                {
                    e.Row.Cells.RemoveAt(1);
                }
                e.Row.Cells[0].ColumnSpan = grdviewroster.Columns.Count;

            }
        }
    }
}