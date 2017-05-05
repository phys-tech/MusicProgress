using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicProgress.Backend;

using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace MusicProgress
{
    public partial class AveragePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aggregator aggregator = new Aggregator();

            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                Label lab = new Label();
                lab.Text = aggregator.mapAverage[task].ShowAsString();
                Panel1.Controls.AddAt((int)task, lab);
            }
        }

    }
}