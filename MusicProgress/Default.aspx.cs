using System;
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

            lTotalFilesNum.Text = "HttpContext.Current.Request.Path = " + HttpContext.Current.Request.Path;
            lTotalFilesNum.Text += "\nHttpContext.Current.Request.ApplicationPath = " + HttpContext.Current.Request.ApplicationPath;
            lTotalFilesNum.Text += "\nHttpContext.Current.Request.Url.AbsolutePath = " + HttpContext.Current.Request.Url.AbsolutePath;
            lTotalFilesNum.Text += "MapPath: " + Server.MapPath("\\App_Data\\");
            
            System.Console.WriteLine("********************************************************");
            System.Console.WriteLine(HttpContext.Current.Request.Path);
            System.Console.WriteLine(HttpContext.Current.Request.ApplicationPath);
            System.Console.WriteLine(HttpContext.Current.Request.Url.AbsolutePath);

        }
    }
}