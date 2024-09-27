using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unommer
{
    public partial class log_out : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //on logout all sessions are cleared
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}