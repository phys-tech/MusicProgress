using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public class Aggregator
    {
        private DataCollector dataCollector;

        public float averageSuccess;
        public float averageFailed;
        public float averageRepeats;
        public float averageDuration;

        public Aggregator(DataCollector collector)
        {
            dataCollector = collector;
            CalcStats();
        }

        public void CalcStats()
        {
            var data = dataCollector.data;

            // C++ style 
            int total = 0;
            int success = 0;
            int failed = 0;
            int repeats = 0;
            TimeSpan duration = new TimeSpan(0);

            foreach (DataChunk chunk in data)
            {
                total += chunk.totalTasks;
                success += chunk.successful;
                failed += chunk.failed;
                repeats += chunk.repeats;
                duration += chunk.duration;
            }

            averageSuccess = (float) success * 100 / total;
            averageFailed = (float) failed * 100 / total;
            averageRepeats = (float) repeats * 100 / total;
            averageDuration = (float) duration.TotalSeconds / data.Count;
        }
    }
}