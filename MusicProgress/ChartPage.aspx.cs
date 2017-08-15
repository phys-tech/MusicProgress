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
    using ListOfChunks = List<DataChunk>;

    public partial class ChartPage : System.Web.UI.Page
    {
        private ListOfChunks data;
        private DateTime startDate;
        private DateTime endDate;
        private bool useStart = false;
        private bool useEnd = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalPath.GlobalShit = Server.MapPath(GlobalPath.RelativePath);
            data = MySingleton.GetMe().collector.data;
            System.Web.UI.DataVisualization.Charting.ChartHttpHandler.Settings.StorageType = ChartHttpHandlerStorageType.InProcess;
            System.Web.UI.DataVisualization.Charting.ChartHttpHandler.Settings.FolderName = "~\\App_Data\\";
            System.Web.UI.DataVisualization.Charting.ChartHttpHandler.Settings.Directory = "~\\App_Data\\uploads";

            pCharts.Controls.Clear();
            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                Chart chart1 = new Chart();
                chart1.ImageStorageMode = ImageStorageMode.UseHttpHandler;
                chart1.Height = 670;
                chart1.Width = 960;
                chart1.Series.Add("Series1");
                chart1.Series.Add("Series2");
                chart1.Series.Add("Series3");
                chart1.Series.Add("Failed");
                chart1.Series.Add("Clicks");
                chart1.Series.Add("Repeats");
                chart1.Series.Add("Duration");
                chart1.Series[0].XValueMember = "Date";
                //chart1.Series[0].XValueType = ChartValueType.DateTimeOffset;
                chart1.Series[0].YValueMembers = "Y1";
                chart1.Series[1].YValueMembers = "Y2";
                chart1.Series[2].YValueMembers = "Y3";
                chart1.Series[3].YValueMembers = "Failed";
                chart1.Series[4].YValueMembers = "Clicks";
                chart1.Series[5].YValueMembers = "Repeats";
                chart1.Series[6].YValueMembers = "Duration";
                chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
                chart1.Series[1].ChartType = SeriesChartType.StackedColumn;
                chart1.Series[2].ChartType = SeriesChartType.StackedColumn;
                chart1.Series[3].ChartType = SeriesChartType.StackedColumn;
                chart1.Series[4].ChartType = SeriesChartType.Line;
                chart1.Series[5].ChartType = SeriesChartType.Line;
                chart1.Series[6].ChartType = SeriesChartType.Line;
                chart1.Series[4].BorderWidth = 2;
                chart1.Series[5].BorderWidth = 2;
                chart1.Series[6].BorderWidth = 2;
                //chart1.Series[4].Color = System.Drawing.Color.Red;
                chart1.ChartAreas.Add("chartarea");
                chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chart1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Rotated90;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

                chart1.Series[6].YValueType = ChartValueType.Time;
                chart1.Series[6].YAxisType = AxisType.Secondary;
                chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "mm:ss";

                chart1.Titles.Add(TaskConverter.AsString(task));
                chart1.Titles[0].Font = new System.Drawing.Font("Arial", 14);

                chart1.Legends.Add("MyLegend");
                chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                chart1.Legends[0].Docking = Docking.Top;
                chart1.Legends[0].LegendItemOrder = LegendItemOrder.ReversedSeriesOrder;
                chart1.DataSource = PrepareData(task);
                chart1.DataBind();
                pCharts.Controls.Add(chart1);
            }
        }

        private DataTable PrepareData(Task _task)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Date");
            table.Columns.Add("Y1");
            table.Columns.Add("Y2");
            table.Columns.Add("Y3");
            table.Columns.Add("Clicks");
            table.Columns.Add("Repeats");
            table.Columns.Add("Failed");
            table.Columns.Add("Duration");

            var filterTask = data.Where(u => u.task == _task);
            var filterDate = filterTask;
            if (useStart)
                filterDate = filterDate.Where(h => h.date >= startDate);
            if (useEnd)
                filterDate = filterDate.Where(f => f.date <= endDate);
            var sorted = filterDate.OrderBy(ch => ch.date);

            foreach (DataChunk chunk in sorted)
            {
                DataRow dataRow;
                dataRow = table.NewRow();
                chunk.PrepareDataForChart(ref dataRow);
                table.Rows.Add(dataRow);
            }
            return table;
        }

        protected void cdStartDate_SelectionChanged(object sender, EventArgs e)
        {
            useStart = true;
            startDate = cdStartDate.SelectedDate;
            Page_Load(sender, e);
        }

        protected void cdEndDate_SelectionChanged(object sender, EventArgs e)
        {
            useEnd = true;
            endDate = cdEndDate.SelectedDate;
            Page_Load(sender, e);
        }

    }
}