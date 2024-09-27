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

namespace Unommer
{
    public partial class Availability_Template : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        //Insert template for each day
        protected void BtnSubmitAvail_Click(object sender, EventArgs e)
        {
            avail_temp clsobj = new avail_temp();
            clsobj.Template_Name = TxtTempName.Text.ToString();
            clsobj.Template_Status = lblstatus.Text.ToString();
            clsobj.StartTimeMonMorng = ddlmonmorstar.SelectedValue;
            clsobj.EndTimeMonMorng = ddlmonmorend.SelectedValue;
            clsobj.StartTimeMonAfter = ddlmonaftstar.SelectedValue;
            clsobj.EndTimeMonAfter = ddlmonaftend.SelectedValue;
            clsobj.Day="Monday";
            
            clsobj = AvailData.InsertAvailTemp(clsobj, Session["SchoolName"].ToString());

            clsobj.Template_Name = TxtTempName.Text.ToString();
            clsobj.Template_Status = lblstatus.Text.ToString();
            clsobj.StartTimeMonMorng =  ddltuemorstar.SelectedValue;
            clsobj.EndTimeMonMorng = ddltuemorend.SelectedValue;
            clsobj.StartTimeMonAfter = ddltueaftstar.SelectedValue;
            clsobj.EndTimeMonAfter = ddltueaftend.SelectedValue;
              clsobj.Day="Tuesday";
              clsobj = AvailData.InsertAvailTemp(clsobj, Session["SchoolName"].ToString());

            clsobj.Template_Name = TxtTempName.Text.ToString();
            clsobj.Template_Status = lblstatus.Text.ToString();
            clsobj.StartTimeMonMorng = ddlwedmorstar.SelectedValue;
            clsobj.EndTimeMonMorng = ddlwedmorend.SelectedValue;
            clsobj.StartTimeMonAfter = ddlwedaftstar.SelectedValue;
            clsobj.EndTimeMonAfter = ddlwedaftend.SelectedValue;
            clsobj.Day = "Wednesday";
            clsobj = AvailData.InsertAvailTemp(clsobj, Session["SchoolName"].ToString());

            clsobj.Template_Name = TxtTempName.Text.ToString();
            clsobj.Template_Status = lblstatus.Text.ToString();
            clsobj.StartTimeMonMorng = ddlthurmorstar.SelectedValue;
            clsobj.EndTimeMonMorng = ddlthurmorend.SelectedValue;
            clsobj.StartTimeMonAfter = ddlthuraftstar.SelectedValue;
            clsobj.EndTimeMonAfter = ddlthuraftend.SelectedValue;
            clsobj.Day = "Thursday";
            clsobj = AvailData.InsertAvailTemp(clsobj, Session["SchoolName"].ToString());

            clsobj.Template_Name = TxtTempName.Text.ToString();
            clsobj.Template_Status = lblstatus.Text.ToString();
            clsobj.StartTimeMonMorng = ddlfrimorstar.SelectedValue;
            clsobj.EndTimeMonMorng = ddlfrimorend.SelectedValue;
            clsobj.StartTimeMonAfter = ddlfriaftstar.SelectedValue;
            clsobj.EndTimeMonAfter = ddlfriaftend.SelectedValue;
            clsobj.Day = "Friday";
            clsobj = AvailData.InsertAvailTemp(clsobj, Session["SchoolName"].ToString());

            clsobj.Template_Name = TxtTempName.Text.ToString();
            clsobj.Template_Status = lblstatus.Text.ToString();
            clsobj.StartTimeMonMorng = ddlsatmorstar.SelectedValue;
            clsobj.EndTimeMonMorng = ddlsatmorend.SelectedValue;
            clsobj.StartTimeMonAfter = ddlsataftstar.SelectedValue;
            clsobj.EndTimeMonAfter = ddlsataftend.SelectedValue;
            clsobj.Day = "Saturday";
            clsobj = AvailData.InsertAvailTemp(clsobj, Session["SchoolName"].ToString());

        }
    }
}