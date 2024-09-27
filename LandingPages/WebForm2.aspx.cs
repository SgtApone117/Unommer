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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //string pass= GeneratePassword();
            if(!IsPostBack)
            {
                RegistrationData dataobj = new RegistrationData();
                DataSet ds = dataobj.fetch_school_name("Default");
                ddlschool.DataSource = ds;
                ddlschool.DataTextField = "name";
                ddlschool.DataValueField = "name";
                ddlschool.DataBind();
                ddlschool.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }


        public void schoolclear()
        {
            txtSchoolName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlBoard.SelectedIndex = -1;
            txtCity.Text = string.Empty;
            txtTeleNum.Text= string.Empty;
            txtMobileNum.Text = string.Empty;
            txtAffiliationNum.Text = string.Empty;
            txtAdminName.Text = string.Empty;
            txtAdminEmail.Text = string.Empty;
            txtAdminContactNum.Text = string.Empty;
        }


        public void parentclear()
        {

            TxtParentName.Text = string.Empty;
            TxtParEmail.Text = string.Empty;
            droppartype.SelectedIndex = -1;
            GrdStudent.DataSource = null;
            GrdStudent.DataBind();
        }

        public string GeneratePassword()
        {
            string PasswordLength = "8";
            string NewPassword = "";
            string AllowedChars = "";
            AllowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            AllowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            AllowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = {','};
            string[] arr = AllowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
                NewPassword = passwordString;
            }
            return NewPassword;
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SchoolRegistration clsobj = new SchoolRegistration();

            try
            {
                clsobj.Pass = GeneratePassword();
                clsobj.SchoolName = txtSchoolName.Text.Trim();
                clsobj.Address = txtAddress.Text.Trim();
                clsobj.SchoolBoard = ddlBoard.SelectedValue;
                clsobj.City = txtCity.Text.Trim();
                clsobj.TelphoneNumber = txtTeleNum.Text.Trim();
                clsobj.MobileNumber = txtMobileNum.Text.Trim();
                clsobj.AffiliationNumber = txtAffiliationNum.Text.Trim();
                clsobj.AdministratorName = txtAdminName.Text.Trim();
                clsobj.AdministratorEmail = txtAdminEmail.Text.Trim();
                clsobj.AdministratorContactNum = txtAdminContactNum.Text.Trim();
            
                clsobj.Guid = Guid.NewGuid().ToString();
                clsobj = RegistrationData.InsertSchoolRegistration(clsobj, Session["SchoolName"].ToString());
                //If user is already present
                if (clsobj.Result == 1)
                {
                    string message = "You are already registered. You can login to use the application";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
                    //If user is not present
                else if (clsobj.Result == 0)
                {
                    string message ="Registration Successful";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                    string url = Request.Url.AbsoluteUri;
                    Mailverification obj = new Mailverification(clsobj.AdministratorName, clsobj.AdministratorEmail, clsobj.Guid, url,clsobj.Pass);
                    bool success = obj.sendactivationmail();
                }
                    //Some problem in registering user
                else
                {
                    string message = "Registration Failed";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }
            catch (Exception ex)
            {
            }
            finally {
                schoolclear();
            }
        }


        protected void btnParenSubmit_Click(object sender, EventArgs e)
        {
            ParentRegistration clsobjPar = new ParentRegistration();

            try
            {
                
                clsobjPar.Parent_Name = TxtParentName.Text.Trim();
                clsobjPar.Parent_mail = TxtParEmail.Text.Trim();
                clsobjPar.Guid = Guid.NewGuid().ToString();
                clsobjPar.Pass = GeneratePassword();
                clsobjPar.Parent_type=droppartype.SelectedItem.Value;
                if(GrdStudent.Visible==true)
                {
                    clsobjPar = RegistrationData.InsertParentRegistration(clsobjPar, Session["SchoolName"].ToString());

                    if (clsobjPar.Result == 1)
                    {
                        string message = "You are already registered. You can login to use the application";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    }
                    else
                        if (clsobjPar.Result == 0)
                        {
                            string message = "Registration is Successful";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                            string url = Request.Url.AbsoluteUri;
                            Mailverification obj = new Mailverification(clsobjPar.Parent_Name, "parent.unommer@gmail.com", clsobjPar.Guid, url, clsobjPar.Pass);
                            bool success = obj.sendactivationmail();
                            switch (success)
                            {
                                case true:
                                    break;
                                case false:
                                    break;

                            }

                        }
                }
                else
                {
                    string message = "You cannot register as your ward(s) not in the school databse. Please contact the administrator and ensure your ward(s) is added to the database.";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }
            catch (Exception ex)
            {

            }
            finally {
                parentclear();
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserType.SelectedValue == "School")
            {
                upanelSchool.Visible = true;
                upanelParent.Visible = false;
                DataSet ds = null;
                RegistrationData dataobj = new RegistrationData();
                ds = dataobj.FetchSchoolBoard("Default");
                ddlBoard.DataSource = ds;
                ddlBoard.DataTextField = "board_name";
                ddlBoard.DataValueField = "board_name";
                ddlBoard.DataBind();
                ddlBoard.Items.Insert(0, new ListItem("--Select Board--", "0"));
            }
            else if (ddlUserType.SelectedValue == "Parent")
            {
                upanelParent.Visible = true;
                upanelSchool.Visible = false;
            }
            else if (ddlUserType.SelectedValue == "0")
            {

                string message ="Please select the correct Option";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                upanelParent.Visible = false;
                upanelSchool.Visible = false;
            }
            else
            {
                string message ="Invalid Option";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }

        protected void droppartype_SelectedIndexChanged(object sender, EventArgs e)
        {
        
       
        }

        protected void ddlschool_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentRegistration clsobj = new ParentRegistration();
            RegistrationData dataobj = new RegistrationData();
            clsobj.Parent_type = droppartype.SelectedValue.ToString();
            clsobj.Parent_mail = TxtParEmail.Text.ToString();
            Session["SchoolName"] = ddlschool.SelectedValue.ToString();
            clsobj = dataobj.GetStudentInfo(clsobj, Session["SchoolName"].ToString());
            if (clsobj.StudentList.Count > 0)
            {
                GrdStudent.Visible = true;
                GrdStudent.DataSource = clsobj.StudentList.ToList();
                GrdStudent.DataBind();
            }
            else
            {
                GrdStudent.Visible = false;

            }
        }   
    }
}