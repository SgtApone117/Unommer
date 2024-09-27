using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;


namespace Unommer.Models
{
    public class Mailverification
    {
        String name;
        String email;
        String guid;
        String url;
        String pass;
        
        public Mailverification(string name, string email, string guid, string url, string pass)
        {
            // TODO: Complete member initialization
            this.name = name;
            this.email = email;
            this.guid = guid;
            this.url = url;
            this.pass = pass;
        }
        internal Boolean sendactivationmail()
        {
            Boolean success = false;
            try
            {
                // Gmail Address from where you send the mail
                var fromAddress = "unikulaws@gmail.com";
                // any address where the email will be sending
                var toAddress = email;
                //Password of your gmail address
                const string fromPassword = "unikulaws@123";
                // Passing the values and make a email formate to display
                string subject = "Unommer: Your Login Password";
                // String body = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'><meta name='viewport' content='width=device-width'><title>My email message created with BeeFree</title><meta http-equiv='Content-Type' content='text/html; charset=utf-8'>  <meta name='viewport' content='width=device-width, initial-scale=1.0'>  <meta http-equiv='X-UA-Compatible' content='IE=edge'>  <meta name='format-detection' content='telephone=no'>  <style type='text/css'>  /* RESET */  #outlook a {padding:0;} body {width:100% !important; -webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; margin:0; padding:0; mso-line-height-rule:exactly;}  table td { border-collapse: collapse; }  .ExternalClass {width:100%;}  .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {line-height: 100%;}  table td {border-collapse: collapse;}  /* IMG */  img {outline:none; text-decoration:none; -ms-interpolation-mode: bicubic;}  a img {border:none;}  /* Becoming responsive */  @media only screen and (max-device-width: 480px) {  table[id='container_div'] {max-width: 480px !important;}  table[id='container_table'], table[class='image_container'], table[class='image-group-contenitor'] {width: 100% !important; min-width: 320px !important;}  table[class='image-group-contenitor'] td, table[class='mixed'] td, td[class='mix_image'], td[class='mix_text'], td[class='table-separator'], td[class='section_block'] {display: block !important;width:100% !important;}  table[class='image_container'] img, td[class='mix_image'] img, table[class='image-group-contenitor'] img {width: 100% !important;}  table[class='image_container'] img[class='natural-width'], td[class='mix_image'] img[class='natural-width'], table[class='image-group-contenitor'] img[class='natural-width'] {width: auto !important;}  a[class='button-link justify'] {display: block !important;width:auto !important;}  td[class='table-separator'] br {display: none;}  td[class='cloned_td']  table[class='image_container'] {width: 100% !important; min-width: 0 !important;} } table[class='social_wrapp'] {width: auto;} </style></head><body bgcolor='#d5e4ed'><table id='container_div' style='text-align:center; background-color:#d5e4ed; border-collapse: collapse' align='center' bgcolor='#d5e4ed' width='100%' cellpadding='0' cellspacing='0' border='0'>  <tr><td align='center'><br><table id='container_wrapper' cellpadding='0' cellspacing='0' border='0'><tbody><tr><td><table id='container_table' cellpadding='0' cellspacing='0' border='0' bgcolor='#ffffff' style='border-collapse: collapse; min-width: 480px;' width='480'><tbody><tr><td valign='top' bgcolor='#ffffff'><table cellpadding='8' cellspacing='0' border='0' style='border-collapse: collapse; background-color: #ffffff' bgcolor='#ffffff' width='100%'><tbody><tr><td><table width='100%' cellpadding='0' cellspacing='0' border='0' style='border-collapse: collapse'><tbody><tr valign='top'><td valign='top' class='mix_image' align='center' width='228'><img data-embeded='auto' src='img/logo2.png' alt='UNOMMER' class='' style='height: auto; vertical-align: top; border: 0px none transparent; border-radius: 0px; width: 228px;' width='228'></td><td class='table-separator' width='8' height='8'><b></b></td><td valign='top' class='mix_text' width='228' style='line-height: 130%;'><br></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td valign='top' bgcolor='#ffffff'><table cellpadding='10' cellspacing='0' border='0' width='100%' style='border-collapse: collapse; background-color: rgb(255, 255, 255);' bgcolor='#ffffff'><tbody><tr valign='top'><td valign='top' style='line-height: 130%; color: rgb(0, 0, 0);'><span style='font-size: 14px; font-family: Arial, Helvetica, sans-serif; color: rgb(102, 102, 102); line-height: 130%;'>You are just one step away from using Unommer.Verify your account by clicking the button below</span></td></tr></tbody></table><table cellpadding='10' cellspacing='0' border='0' width='100%' style='border-collapse: collapse; background-color: rgb(255, 255, 255);' bgcolor='#ffffff'><tbody><tr><td valign='top' align='center'><table cellpadding='0' cellspacing='0' border='0' align='center'><tbody><tr><td align='center'><!--[if mso]><v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='http://localhost:24343/EmailVerify.aspx?id=ea83bb95-8780-4c28-9ec1-53a89b409e82' style='height:42px;v-text-anchor:middle;width:66px; display: block;' arcsize='11.904761904761905%' stroke='f' fillcolor='rgb(0, 154, 181)'><w:anchorlock></w:anchorlock><center><![endif]--><a class='button-link ' href='http://localhost:24343/EmailVerify.aspx?id=" + guid+"' target='_blank' style='background-color:rgb(0, 154, 181);border-radius:5px;color:#ffffff;display:inline-block;text-align:center;text-decoration:none;width:auto;-webkit-text-size-adjust:none; box-sizing: border-box'><span class='button_content' style='padding: 10px; display: block;'><span style='display: block; font-family: Arial, Helvetica, sans-serif; color: #ffffff;  font-size: 16px; text-decoration: none;'>Verify</span></span></a><!--[if mso]></center></v:roundrect><![endif]--></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><br></td></tr></table></body></html>";
                string body = "Final Step....\nconfirm your email to complete your unommer account. it's easy- just click the link.\n" + "http://localhost:24343/EmailVerify.aspx?id=" + guid;
                body += "\nYour Username is:- " + email;
                body += "\nYour Password is:- " + pass;
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                    //smtp.UseDefaultCredentials = true;
                }
                // Passing values to smtp object
                smtp.Send(fromAddress, toAddress, subject, body);
                success = true;
            }
            catch (Exception es)
            {
                success = false;
            }
            return success;
        }
    }

    public class ForgotPassword
    {
        String email;
        String url;
        String pass;

        public ForgotPassword(string email,string pass)
        {
            this.email = email;
            this.pass= pass;
        }
        internal Boolean sendnewmail()
        {

            Boolean success = false;
            try
            {
                var fromAddress = "unikulaws@gmail.com";
                // any address where the email will be sending
                var toAddress = email;
                //Password of your gmail address
                const string fromPassword = "unikulaws@123";
                // Passing the values and make a email formate to display
                string subject = "Unommer: Your Login Password";
                // String body = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'><meta name='viewport' content='width=device-width'><title>My email message created with BeeFree</title><meta http-equiv='Content-Type' content='text/html; charset=utf-8'>  <meta name='viewport' content='width=device-width, initial-scale=1.0'>  <meta http-equiv='X-UA-Compatible' content='IE=edge'>  <meta name='format-detection' content='telephone=no'>  <style type='text/css'>  /* RESET */  #outlook a {padding:0;} body {width:100% !important; -webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; margin:0; padding:0; mso-line-height-rule:exactly;}  table td { border-collapse: collapse; }  .ExternalClass {width:100%;}  .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {line-height: 100%;}  table td {border-collapse: collapse;}  /* IMG */  img {outline:none; text-decoration:none; -ms-interpolation-mode: bicubic;}  a img {border:none;}  /* Becoming responsive */  @media only screen and (max-device-width: 480px) {  table[id='container_div'] {max-width: 480px !important;}  table[id='container_table'], table[class='image_container'], table[class='image-group-contenitor'] {width: 100% !important; min-width: 320px !important;}  table[class='image-group-contenitor'] td, table[class='mixed'] td, td[class='mix_image'], td[class='mix_text'], td[class='table-separator'], td[class='section_block'] {display: block !important;width:100% !important;}  table[class='image_container'] img, td[class='mix_image'] img, table[class='image-group-contenitor'] img {width: 100% !important;}  table[class='image_container'] img[class='natural-width'], td[class='mix_image'] img[class='natural-width'], table[class='image-group-contenitor'] img[class='natural-width'] {width: auto !important;}  a[class='button-link justify'] {display: block !important;width:auto !important;}  td[class='table-separator'] br {display: none;}  td[class='cloned_td']  table[class='image_container'] {width: 100% !important; min-width: 0 !important;} } table[class='social_wrapp'] {width: auto;} </style></head><body bgcolor='#d5e4ed'><table id='container_div' style='text-align:center; background-color:#d5e4ed; border-collapse: collapse' align='center' bgcolor='#d5e4ed' width='100%' cellpadding='0' cellspacing='0' border='0'>  <tr><td align='center'><br><table id='container_wrapper' cellpadding='0' cellspacing='0' border='0'><tbody><tr><td><table id='container_table' cellpadding='0' cellspacing='0' border='0' bgcolor='#ffffff' style='border-collapse: collapse; min-width: 480px;' width='480'><tbody><tr><td valign='top' bgcolor='#ffffff'><table cellpadding='8' cellspacing='0' border='0' style='border-collapse: collapse; background-color: #ffffff' bgcolor='#ffffff' width='100%'><tbody><tr><td><table width='100%' cellpadding='0' cellspacing='0' border='0' style='border-collapse: collapse'><tbody><tr valign='top'><td valign='top' class='mix_image' align='center' width='228'><img data-embeded='auto' src='img/logo2.png' alt='UNOMMER' class='' style='height: auto; vertical-align: top; border: 0px none transparent; border-radius: 0px; width: 228px;' width='228'></td><td class='table-separator' width='8' height='8'><b></b></td><td valign='top' class='mix_text' width='228' style='line-height: 130%;'><br></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td valign='top' bgcolor='#ffffff'><table cellpadding='10' cellspacing='0' border='0' width='100%' style='border-collapse: collapse; background-color: rgb(255, 255, 255);' bgcolor='#ffffff'><tbody><tr valign='top'><td valign='top' style='line-height: 130%; color: rgb(0, 0, 0);'><span style='font-size: 14px; font-family: Arial, Helvetica, sans-serif; color: rgb(102, 102, 102); line-height: 130%;'>You are just one step away from using Unommer.Verify your account by clicking the button below</span></td></tr></tbody></table><table cellpadding='10' cellspacing='0' border='0' width='100%' style='border-collapse: collapse; background-color: rgb(255, 255, 255);' bgcolor='#ffffff'><tbody><tr><td valign='top' align='center'><table cellpadding='0' cellspacing='0' border='0' align='center'><tbody><tr><td align='center'><!--[if mso]><v:roundrect xmlns:v='urn:schemas-microsoft-com:vml' xmlns:w='urn:schemas-microsoft-com:office:word' href='http://localhost:24343/EmailVerify.aspx?id=ea83bb95-8780-4c28-9ec1-53a89b409e82' style='height:42px;v-text-anchor:middle;width:66px; display: block;' arcsize='11.904761904761905%' stroke='f' fillcolor='rgb(0, 154, 181)'><w:anchorlock></w:anchorlock><center><![endif]--><a class='button-link ' href='http://localhost:24343/EmailVerify.aspx?id=" + guid+"' target='_blank' style='background-color:rgb(0, 154, 181);border-radius:5px;color:#ffffff;display:inline-block;text-align:center;text-decoration:none;width:auto;-webkit-text-size-adjust:none; box-sizing: border-box'><span class='button_content' style='padding: 10px; display: block;'><span style='display: block; font-family: Arial, Helvetica, sans-serif; color: #ffffff;  font-size: 16px; text-decoration: none;'>Verify</span></span></a><!--[if mso]></center></v:roundrect><![endif]--></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><br></td></tr></table></body></html>";
                string body = "\nYour New Password is:- " + pass;
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                    //smtp.UseDefaultCredentials = true;
                }
                // Passing values to smtp object
                smtp.Send(fromAddress, toAddress, subject, body);
                success = true;
            }
            catch{
                success= false;
            }
            return success;
        }

    }

    public class MailCollab
    {
        String recieve_name;
        String start_time;
        String end_time;
        String recieve_mail;
        String request_name;
        String request_mail;
        String date;
        String type_of_collab;
        String mobile_no;

        public MailCollab(string recieve_name, string start_time, string end_time, string recieve_mail, string request_name, string request_mail,string date,string type_of_collab,string mobile_no)
        {
            this.recieve_name = recieve_name;
            this.start_time = start_time;
            this.end_time = end_time;
            this.recieve_mail = recieve_mail;
            this.request_name = request_name;
            this.request_mail = request_mail;
            this.date = date;
            this.type_of_collab = type_of_collab;
            this.mobile_no = mobile_no;
        }

        internal Boolean sendcollabmail()
        {
            Boolean success= false;
            try
            {
                var fromAddress = "unikulaws@gmail.com";
                const string fromPassword = "unikulaws@123";
                var toAddressrequest = request_mail;
                var toAddressrecieve = recieve_mail;
                string subject="Collabration Request";



                string body_request= "A collabration request has been requested successfully\n";
                //body_request+="Name of Requestor is 
                body_request += "Requested by " + request_name+"\n";
                body_request += "Requested to " + recieve_name + "\n";
                body_request+= "The Collaboration will be on "+date+"\n";
                body_request += "The Collaboration will start from " + start_time + "\n";
                body_request += "The Collaboration will end at" + end_time + "\n";
                if(string.Compare(type_of_collab,"Chat")==0)
                {
                body_request+= "The chat link is http://localhost:24343/Login.aspx?fromemail=true";
                }
                
                
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                    //smtp.UseDefaultCredentials = true;
                }


                // Passing values to smtp object
                smtp.Send(fromAddress, toAddressrequest, subject, body_request);
                success = true;

                string body_recieve = "A collabration has been received by you \n";
                body_recieve += "Requested by " + request_name + "\n";
                body_recieve += "Requested to " + recieve_name + "\n";
                body_recieve += "The Collaboration will be on " + date + "\n";
                body_recieve += "The Collaboration will start from " + start_time + "\n";
                body_recieve += "The Collaboration will end at" + end_time + "\n";
                if (string.Compare(type_of_collab, "Chat") == 0)
                {
                    body_recieve += "The chat link is http://localhost:24343/Login.aspx?fromemail=true"; ;
                }
                else
                {
                    body_recieve += "You can connect to "+request_name+" via the mobile no:- " + mobile_no;
                }
                var smtp1 = new System.Net.Mail.SmtpClient();
                {
                    smtp1.Host = "smtp.gmail.com";
                    smtp1.Port = 587;
                    smtp1.EnableSsl = true;
                    smtp1.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp1.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp1.Timeout = 20000;
                    //smtp.UseDefaultCredentials = true;
                }
                // Passing values to smtp object
                smtp1.Send(fromAddress, toAddressrecieve, subject,body_recieve);
                success = true;

            }
            catch {
                success = false;
            }
            return success;
        }
    }

   


    public class MailDebrief
    {

        String sendtoteacher;
        String sendtoparent;
        String file;
        String body;

        public MailDebrief(string sendtoteacher,string sendtoparent,string file,string body)
        {
            this.sendtoteacher = "teacher.unommer@gmail.com";
            this.sendtoparent = "parent.unommer@gmail.com";
            this.file =  file;
            this.body = body;
        }





        internal Boolean senddebriefmail()
        {
            Boolean success = false;
            
            try
            {
                string sendfrom = "unikulaws@gmail.com";
                MailMessage messageparent= new MailMessage(sendfrom,sendtoparent);
                string subject="Debrief details of collaboration";
                if(file!=null)
                {
                    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                    messageparent.Attachments.Add(data);
                }
                
                messageparent.Subject = subject;
                messageparent.Body = "Your subject of debrief is:- "+body;
                
                

                messageparent.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(sendfrom, "unikulaws@123");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(messageparent);

                MailMessage messageteacher = new MailMessage(sendfrom, sendtoteacher);
                messageteacher.Subject = subject;
                messageteacher.Body = "Your subject of debrief is:- " + body;
                if (file != null)
                {
                    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                    messageteacher.Attachments.Add(data);
                }
                messageteacher.IsBodyHtml = false;
                SmtpClient smtp1 = new SmtpClient();
                smtp1.Host = "smtp.gmail.com";
                smtp1.EnableSsl = true;
                NetworkCredential networkCredential1 = new NetworkCredential(sendfrom, "unikulaws@123");
                smtp1.UseDefaultCredentials = true;
                smtp1.Credentials = networkCredential1;
                smtp1.Port = 587;
                smtp1.Send(messageteacher);

                success = true;
            }
            catch {
                success = false;
            }
            return success;
        }
    }
}
