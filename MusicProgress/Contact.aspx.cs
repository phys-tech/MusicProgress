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

            localData.Sort(CompareDataChunks);
            lRawData.Text = "";
            lTotalChunks.Text = "( " + localData.Count.ToString() + " пачек )";
            foreach (DataChunk chunk in localData)
            {
                string text = chunk.ShowData();
                lRawData.Text += text;
            }
        }

        private int CompareDataChunks(DataChunk chunk1, DataChunk chunk2)
        {
            if (chunk1.date < chunk2.date)
                return -1;
            else if (chunk1.date > chunk2.date)
                return 1;
            else
                return 0;
        }
    }
}