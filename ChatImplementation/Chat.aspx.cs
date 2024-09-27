

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
using Unommer.Chat_Unommer;
using System.Data.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using AjaxControlToolkit;
using SD = System.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Unommer
{
    public partial class Chat : System.Web.UI.Page
    {
        public string UserName = "admin";
        public string UserImage = "/Images/DP/dummy.png";
        public int Userid;
        protected string UploadFolderPath = "~/Uploads/";
        ConnClass ConnC = new ConnClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Txtemail.Text = Session["Mail"].ToString();
                Login_User obj = new Login_User();
                obj.Username = Txtemail.Text.ToString();
                ChatLogin dataobj = new ChatLogin();
                DataSet ds= dataobj.FetchChatData(obj);
                UserName = ds.Tables[0].Rows[0]["u_name"].ToString();
                Userid = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                Session["ID"] = Userid.ToString();
                Session["UserName"] = UserName;
                Userid = Convert.ToInt32(Session["ID"].ToString());
                //Fetching user images
                GetUserImage();
                this.Header.DataBind();
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("log_out.aspx");
          
        }


        public void GetUserImage()
        {
            Userid = Convert.ToInt32(Session["ID"].ToString());

            string query = "select Photo from UMR_Users where ID='" + Userid + "'";
            string ImageName = ConnC.GetColumnVal(query, "Photo");
            if (ImageName != "")
                UserImage = "Images/DP/" + ImageName;
        }


        //On change of profile pic
        protected void btnChangePicModel_Click(object sender, EventArgs e)
        {
            Userid = Convert.ToInt32(Session["ID"].ToString());
            string serverPath = HttpContext.Current.Server.MapPath("~/");
            //path = serverPath + path;
            if (FileUpload1.HasFile)
            {
                string FileWithPat = serverPath + @"Images/DP/" + Userid + FileUpload1.FileName;

                FileUpload1.SaveAs(FileWithPat);
                SD.Image img = SD.Image.FromFile(FileWithPat);
                SD.Image img1 = RezizeImage(img, 151, 150);
                img1.Save(FileWithPat);
                if (File.Exists(FileWithPat))
                {
                    FileInfo fi = new FileInfo(FileWithPat);
                    string ImageName = fi.Name;
                    string query = "update UMR_Users set Photo='" + ImageName + "' where ID='" + Userid + "'";
                    if (ConnC.ExecuteQuery(query))
                        UserImage = "Images/DP/" + ImageName;
                }
            }
        }


        #region Resize Image With Best Qaulity
        

        //Resizing the image if its bigger than size 151*150
        private SD.Image RezizeImage(SD.Image img, int maxWidth, int maxHeight)
        {
            if (img.Height <= maxHeight && img.Width <= maxWidth)
            {
                using (img)
                {
                    int nnx = img.Width;
                    int nny = img.Height;
                    Bitmap cpy = new Bitmap(nnx, nny, SD.Imaging.PixelFormat.Format32bppArgb);
                    using (Graphics gr = Graphics.FromImage(cpy))
                    {
                        gr.Clear(Color.Transparent);

                        // This is said to give best quality when resizing images
                        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        gr.DrawImage(img,
                            new Rectangle(0, 0, nnx, nny),
                            new Rectangle(0, 0, img.Width, img.Height),
                            GraphicsUnit.Pixel);
                    }
                    return cpy;
                }
            }
            else
            {
                using (img)
                {
                    Double xRatio = (double)img.Width / maxWidth;
                    Double yRatio = (double)img.Height / maxHeight;
                    Double ratio = Math.Max(xRatio, yRatio);
                    int nnx = (int)Math.Floor(img.Width / ratio);
                    int nny = (int)Math.Floor(img.Height / ratio);
                    Bitmap cpy = new Bitmap(nnx, nny, SD.Imaging.PixelFormat.Format32bppArgb);
                    using (Graphics gr = Graphics.FromImage(cpy))
                    {
                        gr.Clear(Color.Transparent);

                        // This is said to give best quality when resizing images
                        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        gr.DrawImage(img,
                            new Rectangle(0, 0, nnx, nny),
                            new Rectangle(0, 0, img.Width, img.Height),
                            GraphicsUnit.Pixel);
                    }
                    return cpy;
                }
            }
            

        }

        private MemoryStream BytearrayToStream(byte[] arr)
        {
            return new MemoryStream(arr, 0, arr.Length);
        }


        #endregion

        protected void FileUploadComplete(object sender, EventArgs e)
        {
            string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);
        }

    }
}