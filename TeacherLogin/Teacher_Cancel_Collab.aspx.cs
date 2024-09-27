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
    public partial class Teacher_Cancel_Collab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblteachname = (Label)Master.FindControl("lblteachemail");
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                lblteachname.Text = Session["LoginID"].ToString();
                bind(lblteachname.Text);
            }
        }

        protected void bind(string mail)
        {
            DataSet ds = null;
            CollabrationData dataobj = new CollabrationData();
            CollabTeacherFetch obj = new CollabTeacherFetch();
            obj.Teacher_mail = mail;
            //Fetch all the collaborations by the teacher
            ds = dataobj.fetch_collab_requests(obj, Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdcollabreqshow.DataSource = ds;
                    Session["countGridViewNum"] = ds.Tables[0].Rows.Count;
                    grdcollabreqshow.DataBind();
                   
                }
                else
                {
                    pnlreason.Visible = false;
                    grdcollabreqshow.DataSource = ds;
                    grdcollabreqshow.DataBind();
                }
            }
            else
            {
                pnlreason.Visible = false;
                DataTable dt = new DataTable();
                dt.Columns.Add();
                grdcollabreqshow.DataSource = dt;
                grdcollabreqshow.DataBind();
            }


        }


        protected void grdcollabreqshow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = null;
            CollabrationData dataobj = new CollabrationData();
            CollabTeachDelete obj = new CollabTeachDelete();
            int row_index = 0;
            foreach (GridViewRow row in grdcollabreqshow.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    //int a=grdcollabreqshow.SelectedDataKey["Request_id"];
                    CheckBox c = (CheckBox)row.FindControl("chkbox");
                    if (c.Checked == true)
                    {
                        row_index = row.RowIndex;
                        Label lreq = (Label)row.FindControl("lblreq");
                        Label lstart = (Label)row.FindControl("lblstart");
                        Label lend = (Label)row.FindControl("lblend");
                        HiddenField h = (HiddenField)row.FindControl("hdnreq");
                        if (h != null)
                        {

                            obj.choice = rdlchoice.SelectedValue.ToString();
                            obj.start_time = Convert.ToDecimal(lstart.Text);
                            obj.end_time = Convert.ToDecimal(lend.Text);
                            obj.req_date = lreq.Text.ToString();
                            obj.req_id = Convert.ToInt32(grdcollabreqshow.DataKeys[row_index].Values[0]);
                            Label lblteachname = (Label)Master.FindControl("lblteachemail");
                            obj.teacher_mail = lblteachname.Text.ToString();
                            ds = dataobj.delete_collab_requests(obj, Session["SchoolName"].ToString());
                        }
                    }
                }
            }
            Label lblteachname1 = (Label)Master.FindControl("lblteachemail");
            bind(lblteachname1.Text);
            string message = "The collaboration(s) has been cancelled";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
        }

        protected void grdcollabreqshow_RowCreated(object sender, GridViewRowEventArgs e)
        {
            int countGridViewNum=Convert.ToInt32(Session["countGridViewNum"]);
            if (e.Row.RowType == DataControlRowType.Footer)
            {
               
                   for (int i = 0; i < grdcollabreqshow.Columns.Count - 1; i++)
                   {
                       e.Row.Cells.RemoveAt(1);
                   }
                   e.Row.Cells[0].ColumnSpan = grdcollabreqshow.Columns.Count;
               
            }
        }

       
    }
}