using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public class MySingleton
    {
        private static readonly MySingleton instance = new MySingleton();

        public DataCollector collector;
        public Aggregator aggregator;

        private MySingleton()
        {
            //collector = new DataCollector();
            //aggregator = new Aggregator(collector.data);
            ReloadData();
        }

        public static MySingleton GetMe()
        {
            //if (instance == null)
            //    instance = new MySingleton();
            return instance;
        }

        public void ReloadData()
        {
            collector = new DataCollector();
            aggregator = new Aggregator(collector.data);        
        }
    }
}