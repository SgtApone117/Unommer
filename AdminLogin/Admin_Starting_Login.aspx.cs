using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Unommer;
using Unommer.Models;
using Unommer.DAL;

namespace Unommer
{
    public partial class Admin_Starting_Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Admin_Update obj = new Admin_Update();
            RegistrationData dataobj = new RegistrationData();
            DataSet ds = null;
            //If the user agter logout enters the portal again he will we logged-out
            if (Session["LoginID"] == null)
            {
                Response.Redirect("log_out.aspx");
            }
            obj.AdminEmail = Session["LoginID"].ToString();
            if (IsPostBack)
            {
                obj.NewPass = txt_npassword.Text.ToString();
                //Updating new password for admin
                ds = dataobj.UpdateAdmin(obj, Session["SchoolName"].ToString());
                string message ="Updation done";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {


        }
    }
}
