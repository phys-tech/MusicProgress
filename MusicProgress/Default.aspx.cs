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
            DataCollector dataCollector = MySingleton.GetMe().collector;
            lFilenames.Text = dataCollector.allfiles;
            lTotalFilesNum.Text = dataCollector.filesCounter.ToString();
        }
    }
}