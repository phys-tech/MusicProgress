using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace MusicProgress
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = default(DataTable);
            dt = CreateDataTable();

            //Set the DataSource property of the Chart control to the DataTabel
            MyChart.DataSource = dt;

            //Give two columns of data to Y-axle
            MyChart.Series[0].YValueMembers = "Volume1";
            MyChart.Series[1].YValueMembers = "Volume2";

            //Set the X-axle as date value
            MyChart.Series[0].XValueMember = "Date";

            //Bind the Chart control with the setting above
            MyChart.DataBind();
        }


        private DataTable CreateDataTable()
        {
            //Create a DataTable as the data source of the Chart control
            DataTable dt = new DataTable();

            //Add three columns to the DataTable
            dt.Columns.Add("Date");
            dt.Columns.Add("Volume1");
            dt.Columns.Add("Volume2");

            DataRow dr;

            //Add rows to the table which contains some random data for demonstration
            dr = dt.NewRow();
            dr["Date"] = "Jan";
            dr["Volume1"] = 3731;
            dr["Volume2"] = 4101;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Feb";
            dr["Volume1"] = 6024;
            dr["Volume2"] = 4324;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Mar";
            dr["Volume1"] = 4935;
            dr["Volume2"] = 2935;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Apr";
            dr["Volume1"] = 4466;
            dr["Volume2"] = 5644;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "May";
            dr["Volume1"] = 5117;
            dr["Volume2"] = 5671;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "Jun";
            dr["Volume1"] = 3546;
            dr["Volume2"] = 4646;
            dt.Rows.Add(dr);

            return dt;
        }
    }
}