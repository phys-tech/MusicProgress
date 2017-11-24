using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public class MonthlyReport
    {
        protected int total;
        protected int success;
        protected int failed;
        protected int count;
               
        private Task task;
        private float averageTotal;
        private float averageSuccess;
        private float averageFailed;

        public MonthlyReport()
        {
            total = 0;
            success = 0;
            failed = 0;
        }

        public virtual void AppendData(DataChunk chunk)
        {
            total += chunk.totalTasks;
            success += chunk.successful;
            failed += chunk.failed;
            count++;        
        }

        public virtual void CalcAverage()
        {
            averageTotal = (float) total / count;
            averageSuccess = (float) success / count;
            averageFailed = (float) failed / count;
        }

        public virtual String ShowAsString()
        {
            String result = "" + count.ToString() + " тренировок; ";
            result += "<br> Всего занятий: " + total.ToString() + "&nbsp";
            result += "( " + success.ToString() + " /&nbsp";
            result += failed.ToString() + " )";
            result += "<br>В среднем за 1 раз: " + averageTotal.ToString("F2") + "&nbsp";
            result += "( " + averageSuccess.ToString("F2") + " /&nbsp";
            result += averageFailed.ToString("F2") + " )";
            return result;
        }

    }

    public class MonthManager
    {
        private Dictionary<string, MonthlyReport> reports;

        public MonthManager()
        {
            reports = new Dictionary<string, MonthlyReport>();
        }

        private string GetKey(DateTime date)
        {
            return date.ToString("MMMM yyyy");
        }

        private void CheckKeyExistense(DateTime date)
        {
            string key = GetKey(date);
            if (!reports.ContainsKey(key))
                reports.Add(key, new MonthlyReport());
        }

        public void AppendData(DataChunk data)
        {
            CheckKeyExistense(data.date);
            string key = GetKey(data.date);
            reports[key].AppendData(data);
        }

        public void CalcAverage()
        {
            foreach (string key in reports.Keys)
                reports[key].CalcAverage();
        }

        public string GetDataForMonth(DateTime date)
        {
            string key = GetKey(date);
            string result = reports[key].ShowAsString();
            return result;
        }
    }
}