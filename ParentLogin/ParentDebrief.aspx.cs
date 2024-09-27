using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Unommer;
using Unommer.Models;
using Unommer.DAL;
using System.IO;

namespace Unommer
{
    public partial class ParentDebrief : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Debrief_Parent obj = new Debrief_Parent();
                DebriefData dataobj = new DebriefData();
                Label lblparentemail = (Label)Master.FindControl("lblparentemail");
                if(Session["LoginID"]==null)
                {
                    Response.Redirect("log_out.aspx");
                }
                lblparentemail.Text = Session["LoginID"].ToString();
                obj.parent_mail = lblparentemail.Text.ToString();
                DataSet ds = null;
                ds = dataobj.fetch_debrief_parent(obj, Session["SchoolName"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdshowdebrief.DataSource = ds;
                        grdshowdebrief.DataBind();
                    }
                    else
                    {
                        grdshowdebrief.DataSource = ds;
                        grdshowdebrief.DataBind();

                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add();
                    grdshowdebrief.DataSource = dt;
                    grdshowdebrief.DataBind();

                }
            }

        }

        protected void grdshowdebrief_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = null;
            int row_index = 0;
            DebriefInsert obj = new DebriefInsert();
            DebriefData dataobj = new DebriefData();
            
            foreach (GridViewRow row in grdshowdebrief.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox c = (CheckBox)row.FindControl("chkboxdebrief");
                    TextBox t = (TextBox)row.FindControl("txtsubdeb");
                    HiddenField h = (HiddenField)row.FindControl("hdnreq");
                    FileUpload fu = (FileUpload)row.FindControl("flup");
                    Label l = (Label)row.FindControl("lblrequestor");
                    string FileWithPath;
                    row_index = row.RowIndex;
                    string filename;
                    if (c.Checked == true)
                    {
                        obj.parentmail = l.Text.ToString();

                        filename = Path.GetFileName(fu.PostedFile.FileName);
                        if (System.IO.File.Exists(filename))
                        {
                            System.IO.File.Delete(filename);
                        }
                        if(fu.FileName!="")
                        {
                            fu.SaveAs(Server.MapPath("Files/" + filename));
                            obj.filename = filename.ToString();
                             FileWithPath = "C:/Users/Admin/Downloads/Qiblah/WebApplication7/WebApplication7/Files/" + filename;
                            Session["Sent_File_Name"] = fu.PostedFile.FileName;
                            obj.request_id = Convert.ToInt32(h.Value.ToString());
                            obj.debrief_subject = t.Text.ToString();
                            dataobj.insert_debrief_data(obj, Session["SchoolName"].ToString());

                            Label lblteachermail = (Label)Master.FindControl("lblparentemail");
                            MailDebrief obj1 = new MailDebrief(obj.parentmail.ToString(), lblteachermail.Text, FileWithPath, t.Text.ToString());

                            Boolean success = obj1.senddebriefmail();
                            if (success == true)
                            {
                                string message ="Debrief mail sent";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                            }
                            else
                            {
                                string message ="Debrief mail not sent";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                            }
                        }
                        if (fu.FileName=="")
                        {
                            obj.request_id = Convert.ToInt32(h.Value.ToString());
                            obj.debrief_subject = t.Text.ToString();
                            obj.filename = null;
                            dataobj.insert_debrief_data(obj, Session["SchoolName"].ToString());
                            Label lblteachermail = (Label)Master.FindControl("lblparentemail");
                            MailDebrief obj1 = new MailDebrief(obj.parentmail.ToString(), lblteachermail.Text, null, t.Text.ToString());
                            Boolean success = obj1.senddebriefmail();
                            if (success == true)
                            {
                                string message ="Debrief mail sent";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                            }
                            else
                            {
                                string message ="Debrief mail not sent";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);

                            }
                        }
                        
                    }
                }
            }
            Debrief_Parent clsobj = new Debrief_Parent();
            ds = dataobj.fetch_debrief_parent(clsobj, Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdshowdebrief.DataSource = ds;
                    grdshowdebrief.DataBind();
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add();
                    grdshowdebrief.DataSource = dt;
                    grdshowdebrief.DataBind();
               
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add();
                grdshowdebrief.DataSource = dt;
                grdshowdebrief.DataBind();
               
            }

        }

        protected void chkboxdebrief_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdshowdebrief.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox c = (CheckBox)row.FindControl("chkboxdebrief");
                    TextBox t = (TextBox)row.FindControl("txtsubdeb");
                    Label l = (Label)row.FindControl("lblprimary");
                    FileUpload fu = (FileUpload)row.FindControl("flup");
                    if (c.Checked == true)
                    {
                        int row_index = row.RowIndex;
                        t.Enabled = true;
                        fu.Enabled = true;

                    }
                }
            }
        }

        protected void grdshowdebrief_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                for (int i = 0; i < grdshowdebrief.Columns.Count - 1; i++)
                {
                    e.Row.Cells.RemoveAt(1);
                }

                e.Row.Cells[0].ColumnSpan = grdshowdebrief.Columns.Count;
            }
        }
    }
}