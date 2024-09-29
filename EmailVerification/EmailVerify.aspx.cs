using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unommer.DAL;
using Unommer.Models;

namespace Unommer
{
    public partial class EmailVerify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                String id = Request.QueryString["id"];
                String connetionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    //For checking whether the mail given is correct or not
                    Verifyall obj = new Verifyall();
                     obj.Guid = id;
                     obj = WebData.verifyformail(obj, Session["SchoolName"].ToString());

                    if (obj.result == 0)
                    {
                    }

                    else
                    {
                    }

                }
                catch (Exception sq)
                {

                }

            }
            else
            {

                Response.Redirect("Default.aspx");
            }
            Response.Redirect("Login.aspx");
        }
    }
}