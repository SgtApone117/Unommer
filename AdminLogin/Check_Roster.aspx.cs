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
    public partial class Check_Roster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["LoginID"]== null)
                {
                    Response.Redirect("log_out.aspx");
                }
            }
        }
        protected void TxtTeachMail_TextChanged(object sender, EventArgs e)
        {
            RosterDetails clsobj = new RosterDetails();
            RegistrationData dataobj = new RegistrationData();
            DataSet ds = null;
            clsobj.Teacher_id = Convert.ToInt16(TxtTeachMail.Text);
            ds = dataobj.GetRosterDetails(clsobj, Session["SchoolName"].ToString());
            if(ds.Tables.Count>0)
            {
                if(ds.Tables[0].Rows.Count>0)
                {
                    MainRoster.DataSource = ds;
                    MainRoster.DataBind();
                    LblYear.Text = ds.Tables[0].Rows[0][1].ToString();
                    LblMonth.Text = ds.Tables[0].Rows[0][2].ToString();
                    LblStartT.Text = ds.Tables[0].Rows[0][3].ToString();
                    LblEndT.Text = ds.Tables[0].Rows[0][4].ToString();
                    LblUnitD.Text = ds.Tables[0].Rows[0][5].ToString();
                    LblYear.Visible = true;
                    LblMonth.Visible = true;
                    LblStartT.Visible = true;
                    LblEndT.Visible = true;
                    LblUnitD.Visible = true;
                    LblShowEndDate.Visible = true;
                    LblShowStartDate.Visible = true;
                    LblShowMonth.Visible = true;
                    LblShowUnitDur.Visible = true;
                    Lblshowyear.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data not found')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data not found')", true);
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int i = 2;
                for (int j = 540; j <= 1080; j = j + 15)
                {
                    for (; i <= 37; )
                    {
                        TableCell cell = e.Row.Cells[i];
                        char quantity = char.Parse(cell.Text);
                        if (quantity == 'N')
                        {
                            cell.BackColor = Color.Gray;
                            cell.Text = "";
                            double k = (double)j / 60;
                            double a = k;
                            a = Math.Floor(a) + ((a - Math.Floor(a)) * 60 / 100);
                            string c = string.Format("{0:N2}", a);
                            cell.ToolTip = c;
                        }
                        else if (quantity == 'P')
                        {
                            cell.BackColor = Color.Green;
                            cell.Text = "";
                            double k = (double)j / 60;
                            double a = k;
                            a = Math.Floor(a) + ((a - Math.Floor(a)) * 60 / 100);
                            string c = string.Format("{0:N2}", a);
                            cell.ToolTip = c;

                        }
                        i++;
                        break;
                    }
                }
            }
        }
    }
}