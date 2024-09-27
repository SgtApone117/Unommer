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
using System.IO;

namespace Unommer
{
    public partial class Portal_Admin_Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] == null)
            {
                Response.Redirect("log_out.aspx");
            }
        }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            Debrief_Parent obj = new Debrief_Parent();
            Student_Data dataobj = new Student_Data();
            Label parent_email = (Label)Master.FindControl("lblparentemail");
            parent_email.Text = Session["LoginID"].ToString();
            obj.parent_mail = parent_email.Text.ToString();
            obj.password = txtconfirmpass.Text.ToString();
            obj = dataobj.updatepasswordparent(obj, Session["SchoolName"].ToString());

            if (obj.result == 0)
            {
                string message = "Updation Done";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);

            }
            else
            {
                string message = "Error in updation";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
        }
    }
}