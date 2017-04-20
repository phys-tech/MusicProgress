using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public class Average
    {
        public int total;
        public int success;
        public int failed;
        public int repeats;
        public TimeSpan duration;
        public int count;

        public float averageSuccess;
        public float averageFailed;
        public float averageRepeats;
        public float averageDuration;

        public Average()
        {
            total = 0;
            success = 0;
            failed = 0;
            repeats = 0;
            duration = new TimeSpan(0);
        }

        public void CalcAverage()
        {
            averageSuccess = (float)success * 100 / total;
            averageFailed = (float)failed * 100 / total;
            averageRepeats = (float)repeats * 100 / total;
            averageDuration = (float)duration.TotalSeconds / count;
        }
    }

     
    public class Aggregator
    {
        private DataCollector dataCollector;

        public Dictionary<Task, Average> mapAverage;

        public Aggregator(DataCollector collector)
        {
            dataCollector = collector;
            mapAverage = new Dictionary<Task, Average>();
            foreach (Task task in Enum.GetValues(typeof(Task)))
                mapAverage.Add(task, new Average());

            CalcStats();
        }

        public void CalcStats()
        {
            var data = dataCollector.data;

            // C++ style             
            foreach (DataChunk chunk in data)
            {
                Task task = chunk.task;
                
                mapAverage[task].total += chunk.totalTasks;
                mapAverage[task].success += chunk.successful;
                mapAverage[task].failed += chunk.failed;
                mapAverage[task].repeats += chunk.repeats;
                mapAverage[task].duration += chunk.duration;
                mapAverage[task].count++;
            }

            foreach (Average av in mapAverage.Values)
                av.CalcAverage();

        }
    }
}