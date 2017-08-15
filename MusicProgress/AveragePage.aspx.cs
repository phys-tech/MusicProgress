using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicProgress.Backend;

namespace MusicProgress
{
    public partial class AveragePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalPath.GlobalShit = Server.MapPath(GlobalPath.RelativePath);
            int files = MySingleton.GetMe().collector.filesCounter;
            int chunks = MySingleton.GetMe().collector.data.Count;
            lAveragePacks.Text = "В среднем заданий в файле: " + ((float)chunks / files).ToString("F2");

            Aggregator aggregator = MySingleton.GetMe().aggregator;

            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                Label newLabel = new Label();
                newLabel.Text = aggregator.mapAverage[task].ShowAsString();
                pAverageData.Controls.AddAt((int)task, newLabel);
            }
        }
    }
}