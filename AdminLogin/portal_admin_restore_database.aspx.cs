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
using System.IO;
using System.Management.Automation;

namespace Unommer
{
    public partial class portal_admin_restore_database : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                bind();
            }
        }
        void bind()
        {
            Portal_Admin_Data dataobj = new Portal_Admin_Data();
            DataSet ds = dataobj.Fetch_School_Details_Active(Session["SchoolName"].ToString());
            grdactiveschool.DataSource = ds;
            grdactiveschool.DataBind();
        }



        protected void grdshowactiveschools_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RestoreDb")
            {
                foreach (GridViewRow row in grdactiveschool.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string filename = string.Empty;
                        string filenamepath = string.Empty;
                        FileUpload file = (FileUpload)row.FindControl("flpup");
                        RadioButton c = (RadioButton)row.FindControl("chkselect");
                        if (file.Enabled == true && c.Checked==true)
                        {
                            filename = Path.GetFileName(file.PostedFile.FileName);
                            string ext = Path.GetExtension(file.PostedFile.FileName).ToString();
                            if (string.Compare(ext, ".bak") == 0)
                            {
                                filenamepath = "D:\\PowerShell_Backup\\" + filename;
                                HiddenField hdnschoolname = (HiddenField)row.FindControl("hdnschoolname");


                                //Powershell script to restore the database
                                var shell = PowerShell.Create();
                                shell.AddScript("D:\\PowerShell_Scripts\\restore_db.ps1 -dbname " + "\"" + hdnschoolname.Value.ToString() + "\"" + " -backupPath " + filenamepath.ToString());
                                shell.Invoke();
                                string message = "Database has been restored successfully";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);



                                c.Checked = false;
                                file.Enabled = false;
                            }
                            else
                            {
                                string message = "File extension not supported for back up file";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);

                                c.Checked = false;
                                file.Enabled = false;
                            }
                            return;
                            //{

                            //}
                            //filenamepath="D:\PowerShell_Backup"+filename;
                        }
                    }
                }
            }
        }

        //protected void grdshowactiveschools_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //FileUpload file = (FileUpload)grdshowactiveschools.SelectedRow.FindControl("flpup");
        //    //file.Enabled = true;
        //}

        protected void grdshowactiveschools_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                for (int i = 0; i < grdactiveschool.Columns.Count - 1; i++)
                {
                    e.Row.Cells.RemoveAt(1);
                }
                //e.Row.Cells.RemoveAt(1);
                e.Row.Cells[0].ColumnSpan = grdactiveschool.Columns.Count;
            }
        }

        protected void chkselect_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdactiveschool.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    RadioButton c = (RadioButton)row.FindControl("chkselect");
                    //TextBox t = (TextBox)row.FindControl("txtsubdeb");
                    //Label l = (Label)row.FindControl("lblprimary");
                    FileUpload fu = (FileUpload)row.FindControl("flpup");
                    if (c.Checked == true)
                    {
                        int row_index = row.RowIndex;
                        //t.Enabled = true;
                        fu.Enabled = true;
                        return;
                    }
                }
            }
        }
    }
}