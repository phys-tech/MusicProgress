using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusicProgress.Backend;

namespace MusicProgress
{
    public partial class DataPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var localData = MySingleton.GetMe().collector.data;

            lTotalFilesNum.Text = "Всего файлов прочитано: " + MySingleton.GetMe().collector.filesCounter.ToString();
            lTotalChunks.Text = "Всего собрано:  " + localData.Count.ToString() + " пачек";
            lRawData.Text = "";

            localData.Sort(CompareDataChunks);
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