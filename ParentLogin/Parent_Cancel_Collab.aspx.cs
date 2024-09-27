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
    public partial class Parent_Cancel_Collab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                b(Session["LoginID"].ToString());
            }

        }

        void b(string mail)
        {
            DataSet ds = null;
            CollabrationData dataobj = new CollabrationData();
            ParentCollabDetails obj = new ParentCollabDetails();
            obj.parent_mail = mail.ToString();
            //Fetching the collaboration of that teacher
            ds = dataobj.fetch_collab_parent(obj, Session["SchoolName"].ToString());
            if(ds.Tables.Count >0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pnlreason.Visible = true;
                    Grdcollabdata.DataSource = ds;
                    Grdcollabdata.DataBind();

                }
                else
                {
                    pnlreason.Visible = false;
                    Grdcollabdata.DataSource = ds;
                    Grdcollabdata.DataBind();
                }
            }
            else
            {
                pnlreason.Visible = false;
                DataTable dt = new DataTable();
                dt.Columns.Add();
                Grdcollabdata.DataSource = dt;
                Grdcollabdata.DataBind();
            }
            
        }

        protected void Grdcollabdata_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = null;
            int row_index = 0;
            CollabParentDelete clsobj = new CollabParentDelete();
            CollabrationData dataobj = new CollabrationData();
            foreach(GridViewRow row in Grdcollabdata.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox c = (CheckBox)row.FindControl("chkgrdparent");
                    if(c.Checked==true)
                    {
                        row_index = row.RowIndex;
                        Label teach_name = (Label)row.FindControl("lblteacher_name");
                        Label req_date = (Label)row.FindControl("lbldate");
                        Label start_time = (Label)row.FindControl("lblstarttime");
                        Label end_time = (Label)row.FindControl("lblendtime");
                        HiddenField h = (HiddenField)row.FindControl("hdnreqid");
                        if(h!=null)
                        {
                            clsobj.choice = rdlcancel.SelectedValue.ToString();
                            clsobj.teachername = teach_name.Text;
                            clsobj.req_id = Convert.ToInt32(h.Value.ToString());
                            clsobj.start_time = Convert.ToDecimal(start_time.Text);
                            clsobj.end_time = Convert.ToDecimal(end_time.Text);
                            clsobj.req_date = req_date.Text;
                            clsobj.reason = txttextarea.Text.ToString();
                            //For cancelling a collaboration from parent's side
                            ds = dataobj.delete_collab_parent(clsobj, Session["SchoolName"].ToString());
                        }
                    } 
                }
            }
            
            b(Session["LoginID"].ToString());
            string message = "The collaboration(s) has been cancelled";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
        }

        //For removing the extra column
        protected void Grdcollabdata_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
               
                   for (int i = 0; i < Grdcollabdata.Columns.Count - 1; i++)
                   {
                       e.Row.Cells.RemoveAt(1);
                   }
                   e.Row.Cells[0].ColumnSpan = Grdcollabdata.Columns.Count;
            }
        }

        protected void rdlcancel_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnltextarea.Visible = true;
        }
    }
}