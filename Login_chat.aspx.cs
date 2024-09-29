using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unommer;
using Unommer.Chat_Unommer;

namespace Unommer.Chat_Unommer
{
    public partial class Login_chat : System.Web.UI.Page
    {
        ConnClass ConnC = new ConnClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string Query = "select * from UMR_Users where user_mail='" + txtEmail.Value + "' and user_password='" + txtPassword.Value + "'";
            // string Query = "select * from tbl_Users where Email='" + txtEmail.Value + "' and Password='" + txtPassword.Value + "'";
            if (ConnC.IsExist(Query))
            {
                string UserName = ConnC.GetColumnVal(Query, "u_name");
                string ID = ConnC.GetColumnVal(Query, "ID");
                Session["UserName"] = UserName;
                Session["ID"] = ID;
                Session["Email"] = txtEmail.Value;
                Response.Redirect("Chat.aspx");
            }
            else
                txtEmail.Value = "Invalid Email or Password!!";
        }
    }
}