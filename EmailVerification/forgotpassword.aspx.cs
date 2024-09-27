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
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ParentRegistration obj = new ParentRegistration();
            RegistrationData dataobj = new RegistrationData();
            if(txtemail.Text==null)
            {
                string message = "Please enter your email";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);

            }
            else
            {
                obj.Parent_mail = txtemail.Text.ToString();
                obj.Pass = GeneratePassword();
                DataSet ds = dataobj.ChangePassword("Default", obj);
                if (ds.Tables[0].Rows[0]["Checkforerror"].ToString() == "0")
                {
                    //ForgotPassword clsobj = new ForgotPassword(obj.Parent_mail, obj.Pass);
                    ForgotPassword clsobj = new ForgotPassword("parent.unommer@gmail.com", obj.Pass);
                    bool success = clsobj.sendnewmail();
                    if (success == true)
                    {
                        string message = "User found! Password is updated";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                    }
                    else
                    {
                        string message = "Error in sending mail! Please try again!";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                    }

                }
                else
                {
                    string message = "User not found! Please check your email address";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
            }
            
        }

        public string GeneratePassword()
        {
            string PasswordLength = "8";
            string NewPassword = "";
            string AllowedChars = "";
            AllowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            AllowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            AllowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = { ',' };
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
    }
}