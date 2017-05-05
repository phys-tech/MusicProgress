using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    using ListOfChunks = List<DataChunk>;

    public class Aggregator
    {
        public Dictionary<Task, Average> mapAverage;

        public Aggregator()
        {
            mapAverage = new Dictionary<Task, Average>();
            AverageCreator creator = new AverageCreator();
            foreach (Task task in Enum.GetValues(typeof(Task)))
                mapAverage.Add(task, creator.Create(task));

            CalcStats(MySingleton.GetMe().collector.data);
        }

        private void CalcStats(ListOfChunks data)
        {
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