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
            GlobalPath.GlobalShit = Server.MapPath(GlobalPath.RelativePath);
            var localData = MySingleton.GetMe().collector.data;

            lTotalFilesNum.Text = "Всего файлов прочитано: " + MySingleton.GetMe().collector.filesCounter.ToString();
            lTotalChunks.Text = "Всего собрано:  " + localData.Count.ToString() + " пачек";

            localData.Sort(CompareDataChunks);
            DateTime prevDate = DateTime.MinValue;
            foreach (DataChunk chunk in localData)
            {
                if (prevDate.Month != chunk.date.Month)
                {
                    Label monthLabel = new Label();
                    monthLabel.Text = "<h2 text-align=center>" + chunk.date.ToString("MMMM yyyy") + "</h2><br><br>";
                    monthLabel.BorderStyle = BorderStyle.Solid;
                    //monthLabel.styCssClass = ".centered_label";
                    pRawData.Controls.Add(monthLabel);
                    prevDate = chunk.date;
                }

                Label newLabel = new Label();
                newLabel.Text = chunk.ShowData();
                pRawData.Controls.Add(newLabel);
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