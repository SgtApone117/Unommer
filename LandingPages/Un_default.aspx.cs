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
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Net.Mail;
using System.Net;

namespace Unommer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnsubmit_Click(object sender, EventArgs e)
        {
            Demo clsobj = new Demo();

            try
            {
                clsobj.Name = name.Text.Trim();
                clsobj.Email = email.Text.Trim();
                clsobj.NameofSchool = nameofschool.Text.Trim();
                clsobj.PhoneNumber = phonenumber.Text.Trim();
                clsobj.dateofdemo = Request.Form[dateofdemo.UniqueID];
                clsobj.timeofdemo = Request.Form[timeofdemo.UniqueID];

                if (!string.IsNullOrEmpty(email.Text))
                {
                    SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                    sc.Host = "smtp.gmail.com";
                    sc.Credentials = new NetworkCredential("unikulaws@gmail.com", "unikulaws@123");
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.EnableSsl = true;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("unikulaws@gmail.com");
                    MailAddress copy = new MailAddress("unikulaws@gmail.com");
                    mailMessage.CC.Add(copy);
                    mailMessage.Subject = "Request for Unommer Demo";
                    mailMessage.Body = "Your Request for Unommer free trial has been registered we will contact you shortly" + name.Text + "!!!";
                    mailMessage.IsBodyHtml = true;
                    string mailBox = email.Text.Trim();
                    mailMessage.To.Add(mailBox);
                    sc.Send(mailMessage);
                }

                clsobj = Demo_User_Data.InsertDemoDetails(clsobj, Session["SchoolName"].ToString());

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert();", true);

                clearfield();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void clearfield()
        {
            name.Text = string.Empty;
            email.Text = string.Empty;
            nameofschool.Text = string.Empty;
            phonenumber.Text = string.Empty;
            dateofdemo.Text = string.Empty;
            timeofdemo.Text = string.Empty;
        }
    }
}