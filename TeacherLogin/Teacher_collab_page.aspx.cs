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
    public partial class Teacher_collab_page : System.Web.UI.Page
    {
        DataSet ds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(pnlcollab.Visible==true)
                {
                    if(grdshowroster.Visible==false)
                    {
                        btnemail.Visible = true;
                    }
                    else if(grdshowroster.Visible==true)
                    {
                        btnemail.Visible = false;
                    }
                    
                }
                else
                {
                    btnemail.Visible = false;
                }
                
                TeacherInfo clsobj = new TeacherInfo();
                CollabrationData dataobj = new CollabrationData();
                Label LblTeacherEmail = (Label)Master.FindControl("lblteachemail");
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                LblTeacherEmail.Text = Session["LoginID"].ToString();
                clsobj.teacher_email = LblTeacherEmail.Text;
                DataSet ds = null;
                //Fetch the data related to the teacher
                ds = dataobj.FetchTeachData(clsobj, Session["SchoolName"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Teacher_Id"] = ds.Tables[0].Rows[0]["teacher_id"];
                        Session["Teacher_Name"] = ds.Tables[0].Rows[0]["teacher_name"];
                        GrdTeachDet.DataSource = ds;
                        GrdTeachDet.DataBind();
                    }
                    else
                    {
                       string message ="Error in finding data";
                       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    }
                }
                else
                {
                    string message ="Error in finding data";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }

                TeacherInfo obj = new TeacherInfo();
                LblTeacherEmail.Text = Session["LoginID"].ToString();
                DataSet das = null;
                obj.teacher_email = LblTeacherEmail.Text.ToString();
                LblTeacherEmail.Visible = false;
                das = dataobj.FetchTeachData(obj, Session["SchoolName"].ToString());
                if (das.Tables.Count > 0)
                {
                    if (das.Tables[0].Rows.Count > 0)
                    {
                        LblTeacherEmail.Text = das.Tables[0].Rows[0]["teacher_name"].ToString();
                    }
                }
                DebriefData dataobj1 = new DebriefData();
                DataSet ds1 = dataobj1.fetch_year(Session["SchoolName"].ToString());
                ddlcollabyear.DataSource = ds1;
                ddlcollabyear.DataTextField = "year_no";
                ddlcollabyear.DataValueField = "year_no";
                ddlcollabyear.DataBind();
                ddlcollabyear.Items.Insert(0, new ListItem("--Select--", "0"));

            }
        }

        protected void BindGridView(int a)
        {


            RosterDetails clsobj1 = new RosterDetails();
            RegistrationData dataobj1 = new RegistrationData();
            ds = null;
            clsobj1.Teacher_id = a;
            clsobj1.month = ddlcollabmonth.SelectedValue.ToString();
            clsobj1.year = ddlcollabyear.SelectedValue.ToString();
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
                   string message ="No data present";
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }
            else
            {

                string message ="No data present";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }

        protected void GrdTeachDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdStudDet.Visible = true;
            int tot = 0;
            DataSet ds = null;
            CollabrationData dataobj = new CollabrationData();
            StudentInfo clsobj = new StudentInfo();
            clsobj.class_name = GrdTeachDet.SelectedRow.Cells[1].Text;
            clsobj.section = GrdTeachDet.SelectedRow.Cells[2].Text;
            Session["Subject"] = GrdTeachDet.SelectedRow.Cells[3].Text;
            Session["Class"] = clsobj.class_name.ToString();
            Session["Section"] = clsobj.section.ToString();
            ds = dataobj.FetchStudData(clsobj, Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tot = ds.Tables[0].Rows.Count;

                    GrdStudDet.DataSource = ds;
                    GrdStudDet.DataBind();
                }
                else
                {
                    string message ="Error in finding data";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }
            else
            {
                string message = "Error in finding data";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }

        protected void GrdStudDet_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnltxttopic.Visible = true;
            pnlallemail.Visible = true;
            pnlddl2.Visible = true;
            pnlcollab.Visible = true;
            btnemail.Visible = true;

            HiddenField hdn1 = (HiddenField)GrdStudDet.SelectedRow.FindControl("hdnstudentid");
            HiddenField hdn2 = (HiddenField)GrdStudDet.SelectedRow.FindControl("hdnstudentfname");
            HiddenField hdn3 = (HiddenField)GrdStudDet.SelectedRow.FindControl("hdnstudentlname");
            Session["Student_ID"] = hdn1.Value.ToString();
            Session["Student_fname"] = hdn2.Value.ToString();
            Session["Student_lname"] = hdn3.Value.ToString();

            if (GrdStudDet.SelectedRow.Cells[6].Text == "&nbsp;")
            {
                rdofather.Enabled = false;
            }
            else
            {
                Session["Father_mail"] = GrdStudDet.SelectedRow.Cells[6].Text;
            }

            if (GrdStudDet.SelectedRow.Cells[7].Text == "&nbsp;")
            {
                rdomother.Enabled = false;
            }
            else
            {
                Session["Mother_mail"] = GrdStudDet.SelectedRow.Cells[7].Text;
            }

            if (GrdStudDet.SelectedRow.Cells[8].Text == "&nbsp;")
            {
                rdoguardian.Enabled = false;
            }
            else
            {
                Session["Guardian_mail"] = GrdStudDet.SelectedRow.Cells[8].Text;
            }


        }

        protected void btnemail_Click(object sender, EventArgs e)
        {
            int ch = 0;
            DataSet ds1 = null;
            CollabrationData dataobj = new CollabrationData();
            CollabParentData clsobj2 = new CollabParentData();
            pnllgend.Visible = true;
            if (ddlcollabyear.SelectedValue=="0")
            {
                string message = "Please select year";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
            else if(ddlcollabmonth.SelectedValue=="0")
            {
                string message = "Please select month";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
            else
            {
                if (rdofather.Checked == true)
                {
                    grdshowroster.Visible = true;
                    Session["receive_mail"] = Session["Father_mail"];
                    clsobj2.parent_mail = Session["receive_mail"].ToString();

                }

                else if (rdomother.Checked == true)
                {
                    grdshowroster.Visible = true;
                    Session["receive_mail"] = Session["Mother_mail"];
                    clsobj2.parent_mail = Session["receive_mail"].ToString();
                }

                else if (rdoguardian.Checked == true)
                {
                    grdshowroster.Visible = true;
                    Session["receive_mail"] = Session["Guardian_mail"];
                    clsobj2.parent_mail = Session["receive_mail"].ToString();
                }
                else
                {
                    string message = "Please select an option";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    ch = 1;
                }
                if (ch == 0)
                {
                    ds1 = dataobj.CollabParentData(clsobj2, Session["SchoolName"].ToString());
                    if (ds1.Tables.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            Session["Parent_mail"] = ds1.Tables[0].Rows[0]["user_mail"];
                            Session["Parent_name"] = ds1.Tables[0].Rows[0]["u_name"];
                            btnemail.Visible = false;
                            RosterDetails clsobj1 = new RosterDetails();
                            RegistrationData dataobj1 = new RegistrationData();
                            DataSet ds = null;
                            clsobj1.Teacher_id = Convert.ToInt32(Session["Teacher_Id"]);
                            clsobj1.month = ddlcollabmonth.SelectedValue.ToString();
                            clsobj1.year = ddlcollabyear.SelectedValue.ToString();

                            ds = dataobj1.GetRosterDetails(clsobj1, Session["SchoolName"].ToString());
                            if (ds.Tables.Count > 0)
                            {
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
                                        string message = "Record not found";
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                    }
                                }
                                else
                                {
                                    string message = "Record not found";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                }
                            }
                            else
                            {
                                string message = "Record not found";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                            }
                        }
                        else
                        {
                            string message = "Parent Data is not available";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                        }

                    }
                    else
                    {
                        string message = "Parent Data is not available";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    }

                }
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
                            }
                            else if (c.Checked == true && count == 1 && row.RowIndex == rindex && q == 0 && c.Enabled == true)
                            {
                                string message ="You have to select consecutive time slots";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                            }
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
                            else if (c.Checked == true && count == 2 && c.Enabled == true)
                            {
                                string message ="You can only select 2 time slots";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                error = 1;
                            }
                            else if (c.Checked == true && count == 1 && row.RowIndex != rindex && c.Enabled == true)
                            {
                                string message= "You cannot book appointment in two different days";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                error = 1;

                            }
                            Session["Error"] = error.ToString();
                            i++;
                            break;
                        }
                        check = "chk1";
                    }
                }


            }
            if (count == 0)
            {
                string message ="You need to select a time slot";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
            else
            {
                Teacher_fetch_Roster clsobj = new Teacher_fetch_Roster();
                CollabrationData dataobj = new CollabrationData();

                


                Label LblTeacherEmail = (Label)Master.FindControl("lblteachemail");

                clsobj.topic = Txttopiccollab.Text.ToString() + " Of Student " + Session["Student_fname"];
                clsobj.start_time = Convert.ToDecimal(Session["Start_Time"]);
                clsobj.end_time = Convert.ToDecimal(Session["End_Time"]);
                clsobj.teacher_id = Convert.ToInt32(Session["Teacher_Id"]);
                clsobj.requestor = LblTeacherEmail.Text.ToString();
                clsobj.date = Session["Date"].ToString();
                clsobj.student_id = Convert.ToInt32(Session["Student_ID"]);
                clsobj.collab_type = rdocollabtype.SelectedValue.ToString();
                clsobj.parent_id = Session["Parent_mail"].ToString();
                clsobj.subject = Session["Subject"].ToString();
                clsobj.class_no = Session["Class"].ToString();
                clsobj.section = Session["Section"].ToString();
                clsobj.teacher_mail = Session["LoginID"].ToString();
                DataSet ds = dataobj.insert_update_collab_teach_reuqest(clsobj, Session["SchoolName"].ToString());


                string st1 = starttime.ToString("0.00");
                string st2= endtime.ToString("0.00");
               


                string url = Request.Url.AbsoluteUri;
            

                if(txtmobileno.Text.ToString()=="")
                {
                    txtmobileno.Text = "0";
                }
                MailCollab obj = new MailCollab(Session["Parent_name"].ToString(), Session["Start_Time"].ToString(), Session["End_Time"].ToString(), "parent.unommer@gmail.com", Session["Teacher_Name"].ToString(), "teacher.unommer@gmail.com", Session["Date"].ToString(), rdocollabtype.SelectedValue.ToString(), txtmobileno.Text.ToString());
                bool succ = obj.sendcollabmail();
                if (succ == true)
                {
                    string Message = "Your Collaboration request with parent " + Session["Parent_name"] + " regarding student " + Session["Student_fname"] + " " + Session["Student_lname"] + " is confirmed for " + Session["Date"].ToString() + " It will start at  " + st1 + " & end at " + st2 + " ";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + Message + "');", true);
                }
                else
                {
                    string message ="Mail not sent successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }

                BindGridView(Convert.ToInt32(Session["Teacher_Id"]));

            }
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

        protected void ddlcollabyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlddl1.Visible = true;

            lblcollabmonth.Visible = true;
            roster_info_fetch obj = new roster_info_fetch();
            obj.year = ddlcollabyear.SelectedValue.ToString();
            ddlcollabmonth.Visible = true;
            DebriefData dataobj1 = new DebriefData();
            DataSet ds2 = dataobj1.fetch_month(obj, Session["SchoolName"].ToString());
            ddlcollabmonth.DataSource = ds2;
            ddlcollabmonth.DataTextField = "month_name";
            ddlcollabmonth.DataValueField = "month_name";
            ddlcollabmonth.DataBind();
            ddlcollabmonth.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void GrdStudDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdStudDet.PageIndex = e.NewPageIndex;
            
            //GrdStudDet.Visible = true;
            int tot = 0;
            DataSet ds = null;
            CollabrationData dataobj = new CollabrationData();
            StudentInfo clsobj = new StudentInfo();
            clsobj.class_name = GrdTeachDet.SelectedRow.Cells[1].Text;
            clsobj.section = GrdTeachDet.SelectedRow.Cells[2].Text;
            Session["Subject"] = GrdTeachDet.SelectedRow.Cells[3].Text;
            Session["Class"] = clsobj.class_name.ToString();
            Session["Section"] = clsobj.section.ToString();
            ds = dataobj.FetchStudData(clsobj, Session["SchoolName"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tot = ds.Tables[0].Rows.Count;

                    GrdStudDet.DataSource = ds;
                    GrdStudDet.DataBind();
                }
                else
                {
                    string message ="Error in finding data";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }
            else
            {
                string message = "Error in finding data";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }

        protected void rdocollabtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcollabmonth.SelectedValue == null)
            {
                string message = "Please select the month";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
            else
            {
                if (rdocollabtype.SelectedValue.ToString() == "Chat")
                {

                    pnlmobile.Visible = false;
                }
                else
                {
                    pnlmobile.Visible = true;
                }
            }
        }

    }
}