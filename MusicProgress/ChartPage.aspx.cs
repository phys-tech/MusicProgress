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

            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                Chart chart1 = new Chart();
                chart1.Series.Add("Series1");
                chart1.Series.Add("Series2");
                chart1.Height = 670;
                chart1.Width = 1300;
                chart1.Series[0].YValueMembers = "Y1";
                chart1.Series[1].YValueMembers = "Y2";
                chart1.Series[0].XValueMember = "Date";
                chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
                chart1.Series[1].ChartType = SeriesChartType.StackedColumn;
                chart1.ChartAreas.Add("chartarea");
                chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chart1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Rotated90;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                chart1.Titles.Add(TaskConverter.AsString(task));
                chart1.Titles[0].Font = new System.Drawing.Font("Arial", 14);
                chart1.DataSource = PrepareData(task);
                chart1.DataBind();
                Panel1.Controls.Add(chart1);
            }
        }

        private DataTable PrepareData(Task _task)
        {
            DataTable table = new DataTable();

            //Add three columns to the DataTable
            table.Columns.Add("Date");
            table.Columns.Add("Y1");
            table.Columns.Add("Y2");

            List<DataChunk> filterTask = data.Where(u => u.task == _task).ToList();
            var sorted = filterTask.OrderBy(ch => ch.date);

            foreach (DataChunk chunk in sorted)
            {
                DataRow dr;
                //Add row to the table which contains real data
                dr = table.NewRow();
                
                dr["Date"] = chunk.date.ToShortDateString();
                dr["Y1"] = chunk.successful;
                dr["Y2"] = chunk.failed;                
                table.Rows.Add(dr);                
            }
            return table;
        }

        /*
    <asp:Chart ID="MyChart" runat="server" Height="675px" Width="1357px">
        <Series>
            <asp:Series Name="Series1" ChartType="StackedColumn" LabelAngle="45"></asp:Series>
            <asp:Series Name="Series2" ChartArea="ChartArea1" ChartType="StackedColumn" LabelToolTip="e56yrt" LegendText="4w57yrtyety" LegendToolTip="6w456"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX IntervalAutoMode="VariableCount" IsLabelAutoFit="False" TextOrientation="Rotated90">
                    <LabelStyle Angle="90" />
                </AxisX>
                <AxisX2 TextOrientation="Rotated90">
                </AxisX2>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>         
         */

    }
}