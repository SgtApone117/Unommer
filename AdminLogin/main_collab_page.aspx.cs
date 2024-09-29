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
    public partial class main_collab_page : System.Web.UI.Page
    {
        DataSet ds = null;
        DataSet ds1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CollabStudDetails clsobj = new CollabStudDetails();
                CollabrationData dataobj = new CollabrationData();
                Label LblParentEmail = (Label)Master.FindControl("lblparentemail");
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                LblParentEmail.Text = Session["LoginID"].ToString();

                CollabParentData clsobj1 = new CollabParentData();
                clsobj.parent_email = LblParentEmail.Text.ToString();
                clsobj1.parent_mail = LblParentEmail.Text.ToString();
                //Fetch all the collaboration data
                ds = dataobj.CollabParentData(clsobj1, Session["SchoolName"].ToString());
                Session["Parent_email"] = LblParentEmail.Text.ToString();
                Session["Parent_name"] = ds.Tables[0].Rows[0]["u_name"];
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds1 = access_dataset(clsobj, dataobj);
                        GrdCollabStudDet.DataSource = ds1;
                        GrdCollabStudDet.DataBind();
                    }
                    else
                    {
                        string message = "Error in finding data";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    }
                }
                else
                {
                    string message = "Error in finding data";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }

        }

        protected void BindGridView(int a)
        {



            RosterDetails clsobj1 = new RosterDetails();
            RegistrationData dataobj1 = new RegistrationData();
            ds = null;
            clsobj1.Teacher_id = a;
            clsobj1.month = ddlmonth.SelectedValue.ToString();
            clsobj1.year = ddlyear.SelectedValue.ToString();
            ds = dataobj1.GetRosterDetails(clsobj1, Session["SchoolName"].ToString());
            grdshowroster.DataSource = ds;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdshowroster.DataBind();
                    int nr = grdshowroster.Rows.Count;
                    int nc = grdshowroster.Rows[0].Cells.Count;
                }
                else
                {
                    string message = "Error in finding data";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);

                }
            }
            else
            { 
                string message ="Error in finding data";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }


        protected void GrdCollabStudDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CollabStudDetails clsobj = new CollabStudDetails();
            CollabrationData dataobj = new CollabrationData();
            ////DataSet ds = null;
            //ds = access_dataset(clsobj, dataobj);
            
            int nr = GrdCollabStudDet.Rows.Count;
            int nc = GrdCollabStudDet.Rows[0].Cells.Count;

            TxtFtchdStudFNname.Text = GrdCollabStudDet.SelectedRow.Cells[2].Text+','+GrdCollabStudDet.SelectedRow.Cells[1].Text;
            TxtFtchdStudClass.Text = GrdCollabStudDet.SelectedRow.Cells[3].Text;
            TxtFtchdStudSect.Text = GrdCollabStudDet.SelectedRow.Cells[4].Text;
            TxtFtchdRoll.Text = GrdCollabStudDet.SelectedRow.Cells[5].Text;

            //If a row is selected the row turns to light gray colour
            GrdCollabStudDet.SelectedRow.BackColor = Color.LightGray;

            clsobj.Class = TxtFtchdStudClass.Text;
            DataSet ds = dataobj.fetch_subjects_class(clsobj, Session["SchoolName"].ToString());
            DdlSubjectList.DataSource = ds;
            DdlSubjectList.DataTextField = "Subject";
            DdlSubjectList.DataValueField = "Subject";
            DdlSubjectList.DataBind();
            DdlSubjectList.Items.Insert(0, new ListItem("--Select Subject--", "0"));

            HiddenField hdn = new HiddenField();
            hdn = (HiddenField)GrdCollabStudDet.SelectedRow.FindControl("hdnstudentid");
            Session["Student_id"] = hdn.Value.ToString();

            pnlStudentDetails.Visible = true;
            lblstuparsubj.Visible = true;
            DdlSubjectList.Visible = true;

            DebriefData dataobj1 = new DebriefData();
            DataSet ds1 = dataobj1.fetch_year(Session["SchoolName"].ToString());
            ddlyear.DataSource = ds1;
            ddlyear.DataTextField = "year_no";
            ddlyear.DataValueField = "year_no";
            ddlyear.DataBind();
            ddlyear.Items.Insert(0, new ListItem("--Select--", "0"));
        }


        public DataSet access_dataset(CollabStudDetails clsobj, CollabrationData dataobj)
        {
            Label LblParentEmail = (Label)Master.FindControl("lblparentemail");
            clsobj.parent_email = LblParentEmail.Text.ToString();
            ds = dataobj.CollabDataSchool(clsobj, Session["SchoolName"].ToString());
            return ds;
        }

        protected void DdlSubjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
                    DebriefData dataobj1 = new DebriefData();
                    DataSet ds1 = dataobj1.fetch_year(Session["SchoolName"].ToString());
                    ddlyear.DataSource = ds1;
                    ddlyear.DataTextField = "year_no";
                    ddlyear.DataValueField = "year_no";
                    ddlyear.DataBind();
                    ddlyear.Items.Insert(0, new ListItem("--Select--", "0"));

                    lblyear.Visible = true;
                    ddlyear.Visible = true;

                    
        }

        protected void grdshowroster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int i = 2;
                string ControlName = "chk";
                int ControlNumber = 1;
                CultureInfo gbCulture = new CultureInfo("en-GB");

                Label lbldate = (Label)e.Row.FindControl("lbldate");
                DateTime today = DateTime.Today;

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
                                              
                        CheckBox ddl = (CheckBox)e.Row.Cells[i].FindControl(ControlName + ControlNumber);
                        Label lblday = (Label)e.Row.FindControl("lblday");

                        TableCell cell = e.Row.Cells[i];
                        TableCell cell1 = e.Row.Cells[1];
                        //Changing colour by day
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
                            cell1.BackColor = Color.LightYellow;
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
                            //If a cell cant accept collaboration we turn it maroon
                            cell.BackColor = Color.Maroon;
                            if (ddl.Checked == true)
                            {
                                //If a slot is already booked it turns orange
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

        protected void grdshowroster_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string check = "chk1";
            int count = 0;
            int rindex = 0;
            int j = 0;
            int q = 0;
            double starttime = 0, endtime = 0;
            int error = 0;
            foreach (GridViewRow row in grdshowroster.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    int i = 1;
                    for (j = 540; j < 1080; j = j + 15)
                    {

                        for (; i <= 36; )
                        {
                            check = "chk" + i;
                            CheckBox c = (CheckBox)row.FindControl(check);
                            Label labdate = (Label)row.FindControl("lbldate");
          
                            double k = (double)j / 60;
                            double a = k;
                            a = Math.Floor(a) + ((a - Math.Floor(a)) * 60 / 100);
                
                            double ct = a;


                            if (c.Checked == true && count == 0 && c.Enabled == true)
                            {

                                starttime = ct;
                                ct = Convert.ToDouble(ct) + 0.15;
                                double c1 = ct - Math.Floor(ct);
                                c1 = Math.Round(c1, 0, MidpointRounding.AwayFromZero);
                                if (c1 == 1)
                                {
                                    ct = Math.Floor(ct) + 1;
                                    endtime = ct;
                                }
                                rindex = row.RowIndex;
                                q = 1;
                                count++;
                                Session["Start_Time"] = starttime;
                                Session["End_Time"] = endtime;
                                Session["Date"] = labdate.Text;
                            }
                            else if (c.Checked == false)
                            {
                                q = 0;
                                //q becomes 0 when a cell is not checked
                            }
                                //Checking if we have selected consequetive time slots(q is 0 or not) or not
                            else if (c.Checked == true && count == 1 && row.RowIndex == rindex && q == 0 && c.Enabled == true)
                            {
                                string message ="You have to select consecutive time slots";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                            }
                                //Checking if we have already selected one and we choose the next slot(q is 1)
                            else if (c.Checked == true && count == 1 && row.RowIndex == rindex && q == 1 && c.Enabled == true)
                            {
                                ct = Convert.ToDouble(ct) + 0.15;
                                double c1 = ct - Math.Floor(ct);
                                c1 = Math.Round(c1, 0, MidpointRounding.AwayFromZero);
                                if (c1 == 1)
                                {
                                    ct = Math.Floor(ct) + 1;
                                    endtime = ct;
                                }
                                endtime = ct;
                                count++;
                                q = 0;
                                Session["Start_Time"] = starttime;
                                Session["End_Time"] = endtime;
                                
                            }
                                //For selecting more than 2 time slots(count==2 and c.checked=true)
                            else if (c.Checked == true && count == 2 && c.Enabled == true)
                            {
                               string message ="You can only select 2 time slots";
                               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                error = 1;
                            }
                                //For checking whether the appoinment is in the same day or not(row.rowIndex!= rindex)
                            else if (c.Checked == true && count == 1 && row.RowIndex != rindex && c.Enabled == true)
                            {
                                string message ="You cannot book appointment in two different days";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                error = 1;

                            }
                            Session["Error"] = error.ToString();
                            i++;
                            break;
                        }
                        check = "chk1";
                    }
                    //index++;
                }


            }
            //For checking whether we have selected a time slot or not
            if (count == 0)
            {
                string message ="You need to select a time slot";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
            else
            {
                collab_request clsobj = new collab_request();
                Label LblParentEmail = (Label)Master.FindControl("lblparentemail");
                clsobj.parent_id = LblParentEmail.Text.ToString();
                clsobj.collab_type = RadioCollabType.SelectedValue.ToString();
                clsobj.teacher_id = Convert.ToInt32(Session["teacher_id"]);
                clsobj.class_no = TxtFtchdStudClass.Text.ToString();
                clsobj.section = TxtFtchdStudSect.Text.ToString();
                clsobj.subject = DdlSubjectList.SelectedValue.ToString();
                clsobj.requestor = LblParentEmail.Text.ToString();
                clsobj.student_id = Convert.ToInt32(Session["Student_id"]);
                clsobj.start_time = Convert.ToDecimal(string.Format("{0:0.00}", Session["Start_Time"]));
                clsobj.end_time = Convert.ToDecimal(string.Format("{0:0.00}", Session["End_Time"]));
                Session["Start_Time"] = clsobj.start_time;
                Session["End_Time"] = clsobj.end_time;
                clsobj.date = Session["Date"].ToString();
                Session["Type_of_collab"] = clsobj.collab_type.ToString();
                clsobj.teacher_mail = Session["teacher_mail"].ToString();

                update_roster(clsobj);
                


                string st1 = starttime.ToString("0.00");
                string st2 = endtime.ToString("0.00");



        

                BindGridView(Convert.ToInt32(Session["teacher_id"]));

                string Message = "Your Collaboration request with teacher " + Session["teacher_name"] + " is confirmed for " + Session["Date"].ToString() + " It will start at " + st1.ToString() + " & end at " + st2.ToString() + " ";
                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + Message + "');", true);
            }

        }

        protected void grdshowroster_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdshowroster_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                for (int i = 0; i < grdshowroster.Columns.Count -1; i++)
                {
                    e.Row.Cells.RemoveAt(1);
                }

                e.Row.Cells[0].ColumnSpan = grdshowroster.Columns.Count;
            }
        }

        public void update_roster(collab_request clsobj)
        {
            DataSet ds = null;
            CollabrationData dataobj = new CollabrationData();
            if (Convert.ToInt32(Session["Error"]) == 0)
            {
                ds = dataobj.insert_update_collab_request(clsobj, Session["SchoolName"].ToString());
            }
            else
            {
            }
            BindGridView(Convert.ToInt32(Session["teacher_id"]));

            Session["Parent_name"].ToString();
            string url = Request.Url.AbsoluteUri;
            Label LblParentEmail = (Label)Master.FindControl("lblparentemail");
            if(txtmobileno.Text.ToString()=="")
            {
                txtmobileno.Text= "0";
            }
            MailCollab obj = new MailCollab(Session["teacher_name"].ToString(), Session["Start_Time"].ToString(), Session["End_Time"].ToString(), "teacher.unommer@gmail.com", Session["Parent_name"].ToString(), "parent.unommer@gmail.com", Session["Date"].ToString(), Session["Type_of_collab"].ToString(), txtmobileno.Text.ToString());
            bool succ = obj.sendcollabmail();
        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmonth.Visible = true;
            roster_info_fetch obj = new roster_info_fetch();
            obj.year = ddlyear.SelectedValue.ToString();
            ddlmonth.Visible = true;
            DebriefData dataobj1 = new DebriefData();
            DataSet ds2 = dataobj1.fetch_month(obj, Session["SchoolName"].ToString());
            ddlmonth.DataSource = ds2;
            ddlmonth.DataTextField = "month_name";
            ddlmonth.DataValueField = "month_name";
            ddlmonth.DataBind();
            ddlmonth.Items.Insert(0, new ListItem("--Select--", "0"));

            //lblstuparsubj.Visible = true;
            //DdlSubjectList.Visible = true;
        }

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblstuparsubj.Visible = true;
            //DdlSubjectList.Visible = true;
            pnltypecollab.Visible = true;
            pnllgend.Visible = true;

            CollabTeacherDetails clsobj = new CollabTeacherDetails();
            CollabrationData dataobj = new CollabrationData();
            ds = null;
            clsobj.Class = TxtFtchdStudClass.Text.Trim();
            clsobj.Section = TxtFtchdStudSect.Text.Trim();
            clsobj.Teacher_Subject = DdlSubjectList.SelectedValue;
            ds = dataobj.CollabTeachDetails(clsobj, Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int a = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                    GrdCollabTeacherSubject.DataSource = ds;
                    GrdCollabTeacherSubject.DataBind();


                    Session["teacher_id"] = Convert.ToInt32(ds.Tables[0].Rows[0]["teacher_id"]);
                    Session["teacher_name"] = ds.Tables[0].Rows[0]["teacher_name1"];
                    Session["teacher_mail"] = ds.Tables[0].Rows[0]["teacher_mail"];

                    pnltypecollab.Visible = true;


                    BindGridView(a);
                }

                else
                {
                    //For checking whether the teacher is in the database or not
                   string message ="Teacher does not exist in the database. Select a different teacher";
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);

                }
            }
            else
            {
                string message ="Teacher does not exist in the database. Select a different teacher";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }

        protected void RadioCollabType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlmonth.SelectedValue==null)
            {
                string message = "Please select the month";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
            else
            {
                if (RadioCollabType.SelectedValue.ToString() == "Meeting")
                {
                    pnlmobile.Visible = true;
                }
                else if (RadioCollabType.SelectedValue.ToString() == "Chat")
                {
                    pnlmobile.Visible = false;
                }
            }
            
        }

    }
}