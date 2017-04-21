using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
     
    public class Aggregator
    {
        private DataCollector dataCollector;

        public Dictionary<Task, Average> mapAverage;

        public Aggregator(DataCollector collector)
        {
            dataCollector = collector;
            mapAverage = new Dictionary<Task, Average>();
            AverageCreator creator = new AverageCreator();
            foreach (Task task in Enum.GetValues(typeof(Task)))
                mapAverage.Add(task, creator.Create(task));

            CalcStats();
        }

        public void CalcStats()
        {
            var data = dataCollector.data;

            // C++ style             
            foreach (DataChunk chunk in data)
            {
                Task task = chunk.task;
                mapAverage[task].CollectData(chunk);
            }

            foreach (Average av in mapAverage.Values)
                av.CalcAverage();
        }
    }
}