using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unommer
{
    public partial class Portal_Admin_Landing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["LoginID"] == null)
                {
                    Response.Redirect("log_out.aspx");
                }
                Session["LoginID"].ToString();
                Session["SchoolName"].ToString();
            }
        }
    }
}