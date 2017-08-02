using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicProgress.Backend;

namespace MusicProgress
{
    public partial class ExtremePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalPath.GlobalShit = Server.MapPath(GlobalPath.RelativePath);
            Aggregator aggregator = MySingleton.GetMe().aggregator;

            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                Label newLabel = new Label();
                newLabel.Text = aggregator.mapExtremum[task].ShowAsString();
                pExtremeLabels.Controls.AddAt((int)task, newLabel);
            }
        }
    }
}