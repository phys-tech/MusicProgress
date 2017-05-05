using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{

    public class Aggregator
    {
        public Dictionary<Task, Average> mapAverage;

        public Aggregator()
        {
            DataCollector dataCollector = MySingleton.GetMe().collector;
            mapAverage = new Dictionary<Task, Average>();
            AverageCreator creator = new AverageCreator();
            foreach (Task task in Enum.GetValues(typeof(Task)))
                mapAverage.Add(task, creator.Create(task));

            CalcStats(dataCollector);
        }

        private void CalcStats(DataCollector collector)
        {
            var data = collector.data;

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