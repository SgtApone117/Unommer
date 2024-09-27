using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unommer;
using Unommer.Models;
using Unommer.DAL;
using System.Data;

namespace Unommer
{
    public partial class parentlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ParentRegistration obj= new ParentRegistration();
            if (Session["LoginID"] == null)
            {
                Response.Redirect("log_out.aspx");
            }
            obj.Parent_mail = Session["LoginID"].ToString();
            if(IsPostBack)
            { 
            obj.Pass = TxtParCurPas.Text.ToString();
            obj.NewPass = TxtParPassUp.Text.ToString();
            DataSet ds=null;
            ds = UpdateParentData.GetParentInfo(obj, Session["SchoolName"].ToString());
            TxtParEmail.Text = obj.Parent_mail;

            if (obj.Result == 0)
            {
               string message ="Password changed successfully";
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('" + message + "');", true);
                    string url = Request.Url.AbsoluteUri;
                    Mailverification objm = new Mailverification(obj.Parent_Name, obj.Parent_mail, obj.Guid, url, obj.NewPass);
                    bool success = objm.sendactivationmail();
                    switch (success)
                    {
                        case true:
                            break;
                        case false:
                            break;

                    }
                }
                   

            }

            else if (obj.Result == 1)
            {
                string message ="Updation cant be done";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
            }
            else
            {

            }
        }
    }
}