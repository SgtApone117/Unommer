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
    public partial class Admin_Add_Teachers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Used to bind data to the drop down lists
            if(!IsPostBack)
            {
                RegistrationData dataobj = new RegistrationData();
                DataSet ds = dataobj.fetch_teacher_subjects(Session["SchoolName"].ToString());
                ListBoxTeacherSubjects.DataSource=ds;
                ListBoxTeacherSubjects.DataTextField = "Subject";
                ListBoxTeacherSubjects.DataValueField = "Subject";
                ListBoxTeacherSubjects.DataBind();

                DataSet ds1 = dataobj.fetch_class(Session["SchoolName"].ToString());
                ddlTeacherClass.DataSource = ds1;
                ddlTeacherClass.DataTextField = "Class";
                ddlTeacherClass.DataValueField = "Class";
                ddlTeacherClass.DataBind();

                DataSet ds2 = dataobj.fetch_section(Session["SchoolName"].ToString());
                ddlTeacherSection.DataSource = ds2;
                ddlTeacherSection.DataTextField = "section";
                ddlTeacherSection.DataValueField = "section";
                ddlTeacherSection.DataBind();
            }
        }

        //Used to generate a random password for the user and returns it
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
        

        protected void BtnAddTeacher_Click(object sender, EventArgs e)
        {
            Teachers clsobj = new Teachers();
            string selectedItem = string.Empty;
            string AllSubjects = string.Empty;
            try
            {
                clsobj.Subjects = ListBoxTeacherSubjects.SelectedValue.ToString();
                clsobj.FirstName = TxtTeacherFirstName.Text.Trim();
                clsobj.Email = TxtTeacherEmail.Text.Trim();
                clsobj.Subjects = AllSubjects;
                clsobj.Designation = DropDownListTeacherDesignation.SelectedItem.Value;
                clsobj.Class = ddlTeacherClass.SelectedValue;
                clsobj.Status = CheckBoxListTeacherStatus.SelectedValue;
                clsobj.Section = ddlTeacherSection.SelectedValue;
                clsobj.Pass = GeneratePassword();
                clsobj.Guid = Guid.NewGuid().ToString();

                //Insert the teacher data to the database(Only one subject can be added here). Later on we can add subjects
                clsobj = TeacherData.InsertTeacherDetails(clsobj, Session["SchoolName"].ToString());

                if (clsobj.Result == 1)
                {
                    string message = "Error Recording Data";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);

                    
                }
                else if (clsobj.Result == 0)
                {
                    

                    string url = Request.Url.AbsoluteUri;
                    Mailverification obj = new Mailverification(clsobj.FirstName, "teacher.unommer@gmail.com", clsobj.Guid, url, clsobj.Pass);
                    bool success = obj.sendactivationmail();
                    if (success == true)
                    {
                        String message = "Record Successful";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                    }
                    else if (success == false)
                    {
                        string message = "Error Recording Data";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}