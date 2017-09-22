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

        public Aggregator(ListOfChunks allData)
        {
            mapAverage = new Dictionary<Task, Average>();
            AverageCreator avCreator = new AverageCreator();

            mapExtremum = new Dictionary<Task, Extremum>();
            ExtremumCreator extCreator = new ExtremumCreator();

            foreach (Task task in Enum.GetValues(typeof(Task)))
            {
                mapAverage.Add(task, avCreator.Create(task));
                mapExtremum.Add(task, extCreator.Create(task));
            }

            CalcStats(allData);
            CalcDates();
        }

        private void CalcStats(ListOfChunks data)
        {
            foreach (DataChunk chunk in data)
            {
                Task task = chunk.task;
                mapAverage[task].AppendData(chunk);
                mapExtremum[task].AppendData(chunk);
            }

            foreach (Average av in mapAverage.Values)
                av.CalcAverage();
        }

        private void CalcDates()
        {
            DateTime bestNearest = DateTime.MinValue;
            DateTime worstNearest = DateTime.MinValue;

            foreach (Extremum ext in mapExtremum.Values)
            {
                if (ext.bestChunk.date > bestNearest)
                    bestNearest = ext.bestChunk.date;
                if (ext.worstChunk.date > worstNearest)
                    worstNearest = ext.worstChunk.date;
            }

            foreach (Extremum ext in mapExtremum.Values)
            {
                ext.BestNearestDate = bestNearest;
                ext.WorstNearestDate = worstNearest;
            }
            
        }
    }
}