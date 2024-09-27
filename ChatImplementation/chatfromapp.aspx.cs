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
    public partial class chatfromapp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login_User clsobj = new Login_User();
            if (Session["LoginID"] == null)
            {
                Response.Redirect("log_out.aspx");
            }
            clsobj.Username = Session["LoginID"].ToString();
            LoginData dataobj = new LoginData();
        DataSet ds=dataobj.Check_Collaboration_Chat(clsobj,Session["SchoolName"].ToString());
            //Checking if it has a collaboration within 15 mins or not
             if (String.Compare(ds.Tables[0].Rows[0]["chck"].ToString(),"1")==0)
            {
            Session["Mail"] = Session["LoginID"];
            Response.Redirect("Chat.aspx");
            }
             else
            {
               

                string message = "No collaboration requests are scheduled for you in the next 15 minutes.Hence, you cannot join chat now";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);

                //ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
                //if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
                ////contains Previous page URL
                //{
                //    Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 

                //}
                
            }
          
        }
    }
}