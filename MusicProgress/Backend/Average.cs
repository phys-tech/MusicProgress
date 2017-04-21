using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public class AverageCreator
    {
        public Average Create(Task _task)
        {
            if (_task == Task.eSearchTone || _task == Task.eSearch37)
                return new AverageClicks(_task);
            else
                return new Average(_task);
        }
    }


    public class Average
    {
        public int total;
        public int success;
        public int failed;
        public int repeats;
        public TimeSpan duration;
        public int count;

        private Task task;
        private float averageSuccess;
        private float averageFailed;
        private float averageRepeats;
        private TimeSpan averageDuration;

        public Average(Task _task)
        {
            task = _task;
            total = 0;
            success = 0;
            failed = 0;
            repeats = 0;
            duration = new TimeSpan(0);
        }

        public virtual void CollectData(DataChunk chunk)
        {
            total += chunk.totalTasks;
            success += chunk.successful;
            failed += chunk.failed;
            repeats += chunk.repeats;
            duration += chunk.duration;
            count++;        
        }

        public virtual void CalcAverage()
        {
            averageSuccess = (float)success * 100 / total;
            averageFailed = (float)failed * 100 / total;
            averageRepeats = (float)repeats * 100 / total;
            float averageSeconds = (float)duration.TotalSeconds / count;
            averageDuration = new TimeSpan(0, 0, (int)averageSeconds);
        }

        public virtual String ShowAsString()
        {
            String result;
            result = "<b>" + TaskConverter.AsString(task) + "</b>";
            result += "<br>Success: " + averageSuccess.ToString("F2") + " %";
            result += "<br>Failed: " + averageFailed.ToString("F2") + " %";
            result += "<br>Repeats: " + averageRepeats.ToString("F2") + " %";
            result += "<br>Duration: " + averageDuration.ToString();
            result += "<br>";
            return result;
        }
    }

    public class AverageClicks : Average
    {
        public int clicks;

        private float averageClicks;

        public AverageClicks(Task _task) : base(_task)
        {
            clicks = 0;
        }

        public override void CollectData(DataChunk chunk)
        {
            base.CollectData(chunk);
            clicks += ((SearchToneData) chunk).clicks;
        }

        public override void CalcAverage() 
        {
            base.CalcAverage();
            averageClicks = clicks * 100 / total;
        }

        public override string ShowAsString()
        {
            String result = base.ShowAsString();
            result += "Clicks: " + averageClicks.ToString("F2") + " %";
            result += "<br>";
            return result;
        }
    }

}