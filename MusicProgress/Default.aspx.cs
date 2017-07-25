using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicProgress.Backend;

namespace MusicProgress
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lFilenames.Text = dataCollector.allfiles;

            lTotalFilesNum.Text = "HttpContext.Current.Request.Path = " + HttpContext.Current.Request.Path + Environment.NewLine;
            lTotalFilesNum.Text += "HttpContext.Current.Request.ApplicationPath = " + HttpContext.Current.Request.ApplicationPath + Environment.NewLine;
            lTotalFilesNum.Text += "HttpContext.Current.Request.Url.AbsolutePath = " + HttpContext.Current.Request.Url.AbsolutePath + Environment.NewLine;
            lTotalFilesNum.Text += "MapPath: " + Server.MapPath("\\App_Data\\") + Environment.NewLine;
            lTotalFilesNum.Text += "Environmnet.CurrentDirectory: " + Environment.CurrentDirectory;
        }

        protected void bUpload_Click(object sender, EventArgs e)
        {            
            // Verify that the user selected a file
            var file = MyFileUpload.PostedFile;
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                file.SaveAs(path);

                lFilenames.Text = "Stored succesfully at " + (MyFileUpload.PostedFile.FileName);
            }
        }
    }
}