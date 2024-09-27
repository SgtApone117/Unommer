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
    public partial class Admin_add_subjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                TeacherData dataobj = new TeacherData();
                //Bind teacher name to drop down list
                DataSet ds = dataobj.Fetch_Teacher_Name(Session["SchoolName"].ToString());
                ddlteacherlist.DataSource = ds;
                ddlteacherlist.DataTextField = "teacher_name";
                ddlteacherlist.DataValueField = "teacher_id";
                ddlteacherlist.DataBind();
                ddlteacherlist.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        //Bind teacher record to gridview
        public void bind(string a)
        {
            Teachers obj = new Teachers();
            obj.Id = Convert.ToInt32(a);
            TeacherData dataobj = new TeacherData();

            DataTable ds = dataobj.fetch_teacher_all_record(obj, Session["SchoolName"].ToString());
            EnableViewState = true;
            ViewState["ds"] = ds;
            grdshowteacherdetails.DataSource = ds;
            grdshowteacherdetails.DataBind();
        }

        protected void ddlteacherlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Id"] = ddlteacherlist.SelectedValue.ToString();
            bind(Session["Id"].ToString());
        }



        //Function to add a new row each time
        public void addnewrow()
        {
            int rowindex = 0;
            if(ViewState["ds"]!=null)
            {
                DataTable dt = (DataTable)ViewState["ds"];
                DataRow drcurrentrow = null;
                
                
                if(dt.Rows.Count>0)
                {
                    for(int i=1;i<=dt.Rows.Count;i++)
                    {

                        DropDownList TxtSubject = (DropDownList)grdshowteacherdetails.Rows[rowindex].Cells[1].FindControl("ddlsubject");
                        DropDownList TxtClass = (DropDownList)grdshowteacherdetails.Rows[rowindex].Cells[2].FindControl("ddlclass");
                        DropDownList TxtSec = (DropDownList)grdshowteacherdetails.Rows[rowindex].Cells[3].FindControl("ddlsection");
                        DropDownList TxtStatus = (DropDownList)grdshowteacherdetails.Rows[rowindex].Cells[3].FindControl("ddlstatus");
                        drcurrentrow = dt.NewRow();
                        dt.Rows[i - 1]["Subject"] = TxtSubject.SelectedValue.ToString();
                        dt.Rows[i - 1]["Class"] = TxtClass.SelectedValue.ToString();
                        dt.Rows[i - 1]["Section"] = TxtSec.SelectedValue.ToString();
                        dt.Rows[i - 1]["Status"] = TxtStatus.SelectedValue.ToString();
                        rowindex++;
                    }
                    dt.Rows.Add(drcurrentrow);
                    ViewState["ds"] = dt;
                    grdshowteacherdetails.DataSource = dt;
                    grdshowteacherdetails.DataBind();
                }
            }
            else
            {

            }
            
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            addnewrow();
        }

        protected void grdshowteacherdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Teachers obj = new Teachers();
            TeacherData dataobj = new TeacherData();
            DataSet ds = null;
            foreach(GridViewRow row in grdshowteacherdetails.Rows)
            {
                if(row.RowType == DataControlRowType.DataRow)
                {
                                DropDownList TxtSubject = (DropDownList)row.FindControl("ddlsubject");
                                 DropDownList TxtClass = (DropDownList)row.FindControl("ddlclass");
                                 DropDownList TxtSection = (DropDownList)row.FindControl("ddlsection");
                    if(TxtSubject==null|| TxtClass==null|| TxtSection==null)
                    {
                    
                    }
                    else
                            {
                        obj.Id = Convert.ToInt32(Session["Id"]);
                        obj.Subjects = TxtSubject.SelectedValue.ToString();
                        obj.Class = TxtClass.SelectedValue.ToString();
                        obj.Section = TxtSection.SelectedValue.ToString();
                        if (obj.Subjects != "0" && obj.Class != "0" && obj.Section != "0")
                        {
                            //Adding teacher subject to the database
                            ds = dataobj.insert_teacher_subject(obj, Session["SchoolName"].ToString());
                                }
                     }
                      
                }
            }
            if(string.Compare(e.CommandName,"More")==0)
            {

                string message = "Successfully added subject";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
            }
            
            
        }


        //Function used for removing the extra column
        protected void grdshowteacherdetails_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                for (int i = 0; i < grdshowteacherdetails.Columns.Count - 1; i++)
                {
                    e.Row.Cells.RemoveAt(1);
                }

                e.Row.Cells[0].ColumnSpan = grdshowteacherdetails.Columns.Count;
            }
        }

        protected void grdshowteacherdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TeacherData dataobj = new TeacherData();
            //For checking on click of edit
                if (e.Row.RowType == DataControlRowType.DataRow && grdshowteacherdetails.EditIndex == e.Row.RowIndex)
                {
                    HiddenField hdnstat = (HiddenField)e.Row.FindControl("hdnstat");
                    DropDownList ddlstat = (DropDownList)e.Row.FindControl("ddlstat");
                    ddlstat.Items.FindByValue(hdnstat.Value).Selected = true;

                }
                    //For assigning values to each row
            else if(e.Row.RowType==DataControlRowType.DataRow)
            {
                DropDownList ddlsubject = (DropDownList)e.Row.FindControl("ddlsubject");
                DropDownList ddlclass = (DropDownList)e.Row.FindControl("ddlclass");
                DropDownList ddlsection = (DropDownList)e.Row.FindControl("ddlsection");
                DropDownList ddlstatus = (DropDownList)e.Row.FindControl("ddlstatus");

                HiddenField hdnsubject = (HiddenField)e.Row.FindControl("hdnsubject");
                HiddenField hdnclass = (HiddenField)e.Row.FindControl("hdnclass");
                HiddenField hdnsection = (HiddenField)e.Row.FindControl("hdnsection");
                HiddenField hdnstatus = (HiddenField)e.Row.FindControl("hdnstatus");

                RegistrationData dataobj1 = new RegistrationData();
                DataSet ds1 = dataobj1.fetch_subject(Session["SchoolName"].ToString());

                DataSet ds2 = dataobj1.fetch_class(Session["SchoolName"].ToString());

                DataSet ds3 = dataobj1.fetch_section(Session["SchoolName"].ToString());

                DataSet ds4 = dataobj1.fetch_status(Session["SchoolName"].ToString());
                
                ddlsubject.DataSource = ds1;
                ddlsubject.DataTextField = "subject";
                ddlsubject.DataValueField = "subject";
                ddlsubject.DataBind();

                ddlclass.DataSource = ds2;
                ddlclass.DataTextField = "class";
                ddlclass.DataValueField = "class";
                ddlclass.DataBind();

                ddlsection.DataSource = ds3;
                ddlsection.DataTextField = "section";
                ddlsection.DataValueField = "section";
                ddlsection.DataBind();

                ddlstatus.DataSource = ds4;
                ddlstatus.DataTextField = "Status";
                ddlstatus.DataValueField = "Status";
                ddlstatus.DataBind();

                
                //This segment is used for disabling all the previous rows after adding a new row
                if(hdnsubject.Value.ToString()!="" && hdnclass.Value.ToString()!="" && hdnsection.Value.ToString()!="" )
                {
                    ddlsubject.Items.FindByValue(hdnsubject.Value).Selected = true;
                    ddlclass.Items.FindByValue(hdnclass.Value).Selected = true;
                    ddlsection.Items.FindByValue(hdnsection.Value).Selected = true;
                    ddlstatus.Items.FindByValue(hdnstatus.Value).Selected = true;

                    ddlsubject.Enabled = false;
                    ddlclass.Enabled = false;
                    ddlsection.Enabled = false;
                    ddlstatus.Enabled = false;
                }
                  
                    //This segment is only used in the new row added
                else 
                {
                    ddlsubject.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlclass.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlsection.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlstatus.Enabled = false;
                }
                

                
            }
        }

        protected void grdshowteacherdetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set  grdshowteacherdetails.EditIndex for the current index on click of edit
            grdshowteacherdetails.EditIndex = e.NewEditIndex;
            bind(Session["Id"].ToString());
        }

        protected void grdshowteacherdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Set  grdshowteacherdetails.EditIndex to -1 on click of cancel
            grdshowteacherdetails .EditIndex = -1;
            bind(Session["Id"].ToString());

        }


        protected void grdshowteacherdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        Teachers obj = new Teachers();
            TeacherData dataobj = new TeacherData();
            DataSet ds = null;
            try
            {
                obj.Subjects = ((TextBox)grdshowteacherdetails.Rows[e.RowIndex].FindControl("txtsubject")).Text;
                obj.Class = ((TextBox)grdshowteacherdetails.Rows[e.RowIndex].FindControl("txtclass")).Text;
                obj.Section = ((TextBox)grdshowteacherdetails.Rows[e.RowIndex].FindControl("txtsection")).Text;
                obj.Status = ((DropDownList)grdshowteacherdetails.Rows[e.RowIndex].FindControl("ddlstat")).SelectedValue.ToString();
                //Function used to update the above columns in the database
                ds = dataobj.update_teacher_subject(obj, Session["SchoolName"].ToString());
            }
            catch { }
            string message = "Data updated successfully";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);

        }

        
    }
}