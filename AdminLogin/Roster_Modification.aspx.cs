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
    public partial class Roster_Modification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lblteacheremail.Text = Session["LoginID"].ToString();
                
                DebriefData dataobj = new DebriefData();
                DataSet ds1 = dataobj.fetch_year(Session["SchoolName"].ToString());
                ddlyearteacher.DataSource = ds1;
                ddlyearteacher.DataTextField = "year_no";
                ddlyearteacher.DataValueField = "year_no";
                ddlyearteacher.DataBind();
                ddlyearteacher.Items.Insert(0, new ListItem("--Select--", "0"));
                lblmonthteacher.Visible = false;
                ddlmonthteacher.Visible = false;
            }
        }

        protected void grdshowroster_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (rowdatime <= today.Date)
                {
                   e.Row.Enabled = false;
                }

                if (lbldate != null || lbldate.Text != "")
                {
                    DateTime date = Convert.ToDateTime(lbldate.Text);
                    lbldate.Text = string.Format("{0:dd-MMM-yyyy}", date);
                }

                for (int j = 540; j <= 1080; j = j + 15)
                {
                    for (; i <= 37; )
                    {
                        //string value = ((LinkButton)e.Row.Cells[i].Controls[0]).Text =
                        //       ((LinkButton)e.Row.Cells[i].Controls[0]).Text;                                                
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
                            cell.BackColor = Color.FromArgb(0,204,0);

                            ////cell.Text = "";
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
                            //cell.Text = "";
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
                        //m++;
                        ControlNumber++;
                        break;
                    }
                }

                
            }
        }

        protected void grdshowroster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            foreach(GridViewRow row in grdshowroster.Rows)
            {
                if(row.RowType == DataControlRowType.DataRow)
                {
                    int i;
                    int flag = 0;
                    string nstring = "";
                    int no = 1;
                    Label lbldate = (Label)row.FindControl("lbldate");
                    for (i = 2; i <= 37; i++)
                    {
                        TableCell cell = (TableCell)row.Cells[i];
                        CheckBox ddl = (CheckBox)row.FindControl("chk" + no);
                        if (ddl.Checked == true && cell.BackColor == Color.FromArgb(0, 204, 0))
                        {
                            if (flag == 0)
                            {
                                flag = 1;
                            }
                            nstring = nstring + "N";
                        }
                        else if (ddl.Checked == false && cell.BackColor == Color.FromArgb(0, 204, 0))
                        {
                            nstring = nstring + "P";
                        }
                        else if (ddl.Checked == true && cell.BackColor.Name == "Maroon")
                        {
                            if (flag == 0)
                            {
                                flag = 1;
                            }
                            nstring =nstring+ "P";
                        }
                        else if (ddl.Checked == false && cell.BackColor.Name == "Maroon")
                        {
                            nstring = nstring + "N";
                        }
                        else if (cell.BackColor.Name == "Coral")
                        {
                            nstring =nstring+ "B";
                        }
                        no++;
                    }
                    int count = Convert.ToInt32(nstring.Length);
                    if(flag==1)
                    {
                        roster_modify obj = new roster_modify();
                        Label lblteacheremail = (Label)Master.FindControl("lblteachemail");
                        obj.teacher_email = lblteacheremail.Text.ToString();
                        obj.date = lbldate.Text.ToString();
                        obj.nstring = nstring;
                        CollabrationData dataobj = new CollabrationData();
                        DataSet ds = dataobj.update_roster(obj, Session["SchoolName"].ToString());
                        string message = "Roster has been updated!";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                    }
                }
            }

            databind();
        }

        protected void grdshowroster_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdshowroster_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                for (int i = 0; i < grdshowroster.Columns.Count - 1; i++)
                {
                    e.Row.Cells.RemoveAt(1);
                }
                e.Row.Cells[0].ColumnSpan = grdshowroster.Columns.Count;

            }
        }

        protected void ddlmonthteacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind();
        }

        void databind()
        {
            roster_info_fetch obj = new roster_info_fetch();
            Label lblteacheremail = (Label)Master.FindControl("lblteachemail");
            obj.teacher_email = lblteacheremail.Text.ToString();
            obj.month = ddlmonthteacher.SelectedValue.ToString();
            obj.year = ddlyearteacher.SelectedValue.ToString();
            
            CollabrationData dataobj = new CollabrationData();
            DataSet ds = dataobj.fetch_roster_teacher_mail(obj, Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                pnlleeg.Visible = true;
                grdshowroster.DataSource = ds;
                grdshowroster.DataBind();
            }
            else
            {
                pnlleeg.Visible = false;
              
                DataTable dt = new DataTable();
                dt.Columns.Add();
                grdshowroster.DataSource = dt;
                grdshowroster.DataBind();
            }
            
        }

        protected void ddlyearteacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            roster_info_fetch obj = new roster_info_fetch();
            obj.year = ddlyearteacher.SelectedValue.ToString();
            ddlmonthteacher.Visible = true;
            lblmonthteacher.Visible = true;

            DebriefData dataobj1 = new DebriefData();
            DataSet ds2 = dataobj1.fetch_month(obj, Session["SchoolName"].ToString());
            ddlmonthteacher.DataSource = ds2;
            ddlmonthteacher.DataTextField = "month_name";
            ddlmonthteacher.DataValueField = "month_name";
            ddlmonthteacher.DataBind();
            ddlmonthteacher.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
}