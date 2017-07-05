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
        public Dictionary<Task, Extremum> mapExtremum;

        public Aggregator()
        {
            mapAverage = new Dictionary<Task, Average>();
            AverageCreator creator = new AverageCreator();

            mapExtremum = new Dictionary<Task, Extremum>();
            ExtremumCreator extCreator = new ExtremumCreator();

            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                mapAverage.Add(task, creator.Create(task));
                mapExtremum.Add(task, extCreator.Create(task));
            }

            CalcStats(MySingleton.GetMe().collector.data);
        }

        private void CalcStats(ListOfChunks data)
        {
            foreach (DataChunk chunk in data)
            {
                Task task = chunk.task;
                mapAverage[task].CollectData(chunk);
                mapExtremum[task].AppendData(chunk);
            }

            foreach (Average av in mapAverage.Values)
                av.CalcAverage();
        }
    }
}