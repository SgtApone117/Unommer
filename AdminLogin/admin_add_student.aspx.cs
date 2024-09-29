using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Unommer;
using Unommer.Models;
using Unommer.DAL;
using System.Data.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace Unommer
{
    public partial class admin_add_student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Student_Record();
            if(!IsPostBack)
            {
               
                RegistrationData dataobj = new RegistrationData();
                //Bind the class to the drop down list
                DataSet ds = dataobj.fetch_class(Session["SchoolName"].ToString());
                DropDownStudentClass.DataSource = ds;
                DropDownStudentClass.DataTextField = "class";
                DropDownStudentClass.DataValueField = "class";
                DropDownStudentClass.DataBind();

                //Bind the section to the drop down list
                DataSet ds1 = dataobj.fetch_section(Session["SchoolName"].ToString());
                DropDownStudentSection.DataSource = ds1;
                DropDownStudentSection.DataTextField = "section";
                DropDownStudentSection.DataValueField = "section";
                DropDownStudentSection.DataBind();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            StudentDetails clsobj = new StudentDetails();

            try
            {
                clsobj.Student_FirstName = TxtStudentFirstName.Text.Trim();
                clsobj.Student_LastName = TxtStudentLastName.Text.Trim();
                clsobj.Class = DropDownStudentClass.SelectedItem.Value;
                clsobj.Section = DropDownStudentSection.SelectedItem.Value;
                clsobj.RollNo = Convert.ToInt32(TxtStudentRollNo.Text);
                clsobj.FatherMail = TxtStudentFatherEmail.Text.Trim();
                clsobj.MotherMail = TxtStudentMotherEmail.Text.Trim();
                clsobj.GuardianMail = TxtStudentGuardianEmail.Text.Trim();
                clsobj.Status = StatusCheckBox.SelectedValue;
                //Function to insert student data
                clsobj = Student_Data.InsertStudentDetails(clsobj, Session["SchoolName"].ToString());
                if (clsobj.result == 1)
                {

                    string message = "Failed to add student! Student already exists!!";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "failurealert('" + message + "');", true);
                }
                else if (clsobj.result == 0)
                {
                    string message = "Student Added Successfully";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "popup", "successalert('"+message+"');", true);
                }
            }
            catch (Exception ex)
            {
            }
        }



    }
}