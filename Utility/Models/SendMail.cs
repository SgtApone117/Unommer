using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Mail;

namespace Unommer.Models
{
    public class Mail
    {
        private string tomail;
        private string subject;
        private string mailbody;

        public Mail(string tomail, string subject, string mailbody)
        {
            // TODO: Complete member initialization
            this.tomail = tomail;
            this.subject = subject;
            this.mailbody = mailbody;
        }

        internal Boolean sendmail()
        {
            Boolean success = false;
            try
            {
                // Gmail Address from where you send the mail
                var fromAddress = "unikulaws@gmail.com";
                // any address where the email will be sending
                var toAddress = tomail;
                //Password of your gmail address
                const string fromPassword = "unikulaws@123";
                // Passing the values and make a email formate to display
                string subject = this.subject;
                string body = mailbody;
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                }
                // Passing values to smtp object
                smtp.Send(fromAddress, toAddress, subject, body);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

        //internal Boolean senddebriefmail()
        //{
        //    Boolean success = false;
        //    try{

        //    }
        //}
    }
}