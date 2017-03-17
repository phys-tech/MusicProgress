using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicProgress.Backend;

namespace MusicProgress
{
    public partial class Contact : Page
    {
        DataCollector dataCollector;

        protected void Page_Load(object sender, EventArgs e)
        {
            dataCollector = new DataCollector();
            var localData = dataCollector.data;

            lRawData.Text = "";
            lTotalChunks.Text = "( " + localData.Count.ToString() + " пачек )";
            foreach (DataChunk chunk in localData)
            {
                string date = chunk.date.ToLongDateString();
                string type = TaskConverter.AsString(chunk.task);
                string total = chunk.totalTasks.ToString();
                string success = chunk.successful.ToString();
                string fail = chunk.failed.ToString();
                string repeats = chunk.repeats.ToString();
                string time = chunk.duration.ToString();
                lRawData.Text += date + " - " + type +" - " + total + " (  " + success + " / " + fail + " ) " + "[" + repeats + "] " + "\t\t t = " + time +"<br>";
            }
        }
    }
}