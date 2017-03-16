﻿using System;
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
            lFilenames.Text = dataCollector.allfiles;
            TotalFilesNum.Text = dataCollector.filesCounter.ToString();

            lRawData.Text = "";
            var localData = dataCollector.data;
            lTotalChunks.Text = "( " + localData.Count.ToString() + " пачек )";
            foreach (DataChunk chunk in localData)
            {
                string date = chunk.date.ToLongDateString();
                string type = chunk.type.name;
                string total = chunk.totalTasks.ToString();
                string success = chunk.successful.ToString();
                string fail = chunk.failed.ToString();
                string repeats = chunk.repeats.ToString();
                lRawData.Text += date + " - " + type +" - " + total + " (  " + success + " / " + fail + ") " + "[" + repeats + "] " + "<br>";
            }
        }
    }
}