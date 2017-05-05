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

        private MySingleton()
        {
            collector = new DataCollector();
        }

        public static MySingleton GetMe()
        {
            //if (instance == null)
            //    instance = new MySingleton();
            return instance;
        }
    }
}