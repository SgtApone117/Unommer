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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public string fromemail = "false";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RegistrationData dataobj = new RegistrationData();
                DataSet ds = dataobj.fetch_school_name("Default");
                ddlSchool.DataSource = ds;
                ddlSchool.DataTextField = "name";
                ddlSchool.DataValueField = "name";
                ddlSchool.DataBind();
                ddlSchool.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            if (Request.QueryString["fromemail"] != null)
            {
                //For checking whether we are logging in through email
                Session["FromEmail"] = Request.QueryString["fromemail"];
                fromemail = Session["FromEmail"].ToString();
            }
        }
        Login_User clsobj = new Login_User();

        protected void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LoginData dataobj = new LoginData();
                Session["LoginID"]  = TxtLoginUsername.Text;
                Session["SchoolName"] = ddlSchool.SelectedValue.ToString();
                clsobj.Username = TxtLoginUsername.Text.Trim();
                clsobj.Pass = TxtLoginPass.Text.Trim();
                clsobj.SchoolName = ddlSchool.SelectedValue.ToString();
                if (TxtLoginUsername.Text == "" && TxtLoginPass.Text == "")
                {
                    string message = "Please enter your username and password";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
                else if(TxtLoginUsername.Text=="")
                {
                    string message = "Please enter your username";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
                else if(TxtLoginPass.Text== "")
                {
                    string message = "Please enter your password";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
                else
                {
                    if (TxtLoginUsername.Text == ConfigurationManager.AppSettings["Admin"].ToString())
                    {
                        clsobj = dataobj.CheckLogin(clsobj, ConfigurationManager.AppSettings["DefaultSchool"].ToString());
                        if (clsobj.Result == 1)
                        {
                            //If we are coming from email move directly to chat page and checking for collaboration is done there
                            if (string.Compare(fromemail, "true") == 0)
                            {

                                DataSet ds = dataobj.Check_Collaboration_Chat(clsobj, Session["SchoolName"].ToString());
                                if (string.Compare(ds.Tables[0].Rows[0]["chck"].ToString(), "1") == 0)
                                {
                                    Session["Mail"] = clsobj.Username;
                                    Response.Redirect("Chat.aspx");
                                }
                                else
                                {
                                    string message = "No collaboration requests are scheduled For you in the next 15 minutes.Hence, you cannot login now!!";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                }
                            }
                            else
                            {
                                Response.Redirect("Parent_Landing_Page.aspx");
                            }

                        }
                        else if (clsobj.Result == 2)
                        {
                            Response.Redirect("Admin_Landing_Page.aspx");

                        }
                        else if (clsobj.Result == 3)
                        {
                            //If we are coming from email move directly to chat page and checking for collaboration is done there
                            if (string.Compare(fromemail, "true") == 0)
                            {
                                DataSet ds = dataobj.Check_Collaboration_Chat(clsobj, Session["SchoolName"].ToString());
                                if (string.Compare(ds.Tables[0].Rows[0]["chck"].ToString(), "1") == 0)
                                {
                                    Session["Mail"] = clsobj.Username;
                                    Response.Redirect("Chat.aspx");
                                }
                                else
                                {
                                    string message = "No collaboration requests are scheduled For you in the next 15 minutes.Hence, you cannot login now!!";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                }
                            }
                            else
                            {
                                Response.Redirect("Teacher_Landing_Page.aspx");
                            }
                        }
                        else if (clsobj.Result == 4)
                        {
                            Response.Redirect("Portal_Admin_Landing.aspx");
                        }

                        else if (clsobj.Result == 0)
                        {
                            string message = "Login Failed change username and password";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                        }
                        else
                        {
                            string message = "Error";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                        }
                    }
                    else
                    {
                        if (ddlSchool.SelectedIndex != 0)
                        {
                            if (Session["SchoolName"] != null && Session["SchoolName"].ToString() != "".ToString())
                            {
                                clsobj = dataobj.CheckLogin(clsobj, Session["SchoolName"].ToString());
                                if (clsobj.Result == 1)
                                {
                                    if (string.Compare(fromemail, "true") == 0)
                                    {
                                        DataSet ds = dataobj.Check_Collaboration_Chat(clsobj, Session["SchoolName"].ToString());
                                        if (string.Compare(ds.Tables[0].Rows[0]["chck"].ToString(), "1") == 0)
                                        {
                                            Session["Mail"] = clsobj.Username;
                                            Response.Redirect("Chat.aspx");
                                        }
                                        else
                                        {
                                            string message = "No collaboration requests are scheduled For you in the next 15 minutes.Hence, you cannot login now!!";
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                        }
                                    }
                                    else
                                    {
                                        Response.Redirect("Parent_Landing_Page.aspx");
                                    }

                                }
                                else if (clsobj.Result == 2)
                                {
                                    Response.Redirect("Admin_Landing_Page.aspx");

                                }
                                else if (clsobj.Result == 3)
                                {
                                    if (string.Compare(fromemail, "true") == 0)
                                    {
                                        DataSet ds = dataobj.Check_Collaboration_Chat(clsobj, Session["SchoolName"].ToString());
                                        if (string.Compare(ds.Tables[0].Rows[0]["chck"].ToString(), "1") == 0)
                                        {
                                            Session["Mail"] = clsobj.Username;
                                            Response.Redirect("Chat.aspx");
                                        }
                                        else
                                        {
                                            string message = "No collaboration requests are scheduled For you in the next 15 minutes.Hence, you cannot login now!!";
                                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                        }
                                    }
                                    else
                                    {
                                        Response.Redirect("Teacher_Landing_Page.aspx");
                                    }
                                }
                                else if (clsobj.Result == 0)
                                {
                                    string message = "Login Failed change username and password";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                }
                                else
                                {
                                    string message = "Error";
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                                }
                            }
                            else
                            {
                                string message = "Login Failed! Please try after sometime";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                            }

                        }
                        else
                        {
                            string message = "Please Select School";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                        }
                    }
                }
         
            }
            catch (Exception ex)
            {
            }
            finally { }
        }

        protected void TxtLoginUsername_TextChanged(object sender, EventArgs e)
        {
            ddlSchool.ClearSelection();

            if (TxtLoginUsername.Text == ConfigurationManager.AppSettings["Admin"].ToString())
            {
                ddlSchool.Items.FindByValue("Default").Selected = true;
            }
        }
    }


}