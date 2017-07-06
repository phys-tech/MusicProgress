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
            Aggregator aggregator = MySingleton.GetMe().aggregator;

            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                Label lab = new Label();
                lab.Text = aggregator.mapAverage[task].ShowAsString();
                Panel1.Controls.AddAt((int)task, lab);
            }
        }
    }
}