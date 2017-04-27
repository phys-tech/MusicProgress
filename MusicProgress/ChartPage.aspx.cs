using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

using MusicProgress.Backend;

namespace MusicProgress
{
    public partial class ChartPage : System.Web.UI.Page
    {
        private DataCollector collector;
        private List<DataChunk> data;

        protected void Page_Load(object sender, EventArgs e)
        {
            collector = new DataCollector();
            data = collector.data;

            //Set the DataSource property of the Chart control to the DataTabel
            MyChart.DataSource = PrepareData(Task.eSearchTone);

            //Give two columns of data to Y-axle
            MyChart.Series[0].YValueMembers = "Volume1";
            MyChart.Series[1].YValueMembers = "Volume2";

            //Set the X-axle as date value
            MyChart.Series[0].XValueMember = "Date";

            //Bind the Chart control with the setting above
            MyChart.DataBind();
            MyChart.Series[0].ToolTip = "tooltip1";
            MyChart.Series[1].ToolTip = "tooltip--";
            
        }

        private DataTable PrepareData(Task _task)
        {
            DataTable table = new DataTable();

            //Add three columns to the DataTable
            table.Columns.Add("Date");
            table.Columns.Add("Volume1");
            table.Columns.Add("Volume2");

            List<DataChunk> filterTask = data.Where(u => u.task == _task).ToList();
            var sorted = filterTask.OrderBy(ch => ch.date);

            foreach (DataChunk chunk in sorted)
            {
                DataRow dr;
                //Add row to the table which contains real data
                dr = table.NewRow();
                
                dr["Date"] = chunk.date.ToShortDateString();
                dr["Volume1"] = chunk.successful;
                dr["Volume2"] = chunk.failed;                
                table.Rows.Add(dr);                
            }
            return table;
        }

    }
}