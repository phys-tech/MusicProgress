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
            if (_task == Task.eDefineTone || _task == Task.eSequence2 || _task == Task.eDefine37)
                return new AverageAttempts(_task);
            else if (_task == Task.eSearchTone || _task == Task.eSearch37)
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
        private float averageTotal;
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
            averageTotal = (float) total / count;
            averageSuccess = (float) success / count;
            averageFailed = (float) failed / count;
            averageRepeats = (float) repeats / count;
            float averageSeconds = (float)duration.TotalSeconds / count;
            averageDuration = new TimeSpan(0, 0, (int)averageSeconds);
        }

        public virtual String ShowAsString()
        {
            String result;
            result = "<b>" + TaskConverter.AsString(task) + "</b>";
            result += " (" + count.ToString() + " пачек)";
            result += "<br>Total: " + averageTotal.ToString("F2");
            result += "<br>Success: " + averageSuccess.ToString("F2");
            result += "<br>Failed: " + averageFailed.ToString("F2");
            result += "<br>Repeats: " + averageRepeats.ToString("F2");
            result += "<br>Duration: " + averageDuration.ToString();
            result += "<br>";
            return result;
        }
    }

    public class AverageAttempts : Average
    {
        public int first;
        public int second;
        public int third;

        private float averageFirst;
        private float averageSecond;
        private float averageThird;

        public AverageAttempts(Task _task) : base(_task)
        {
            first = 0;
            second = 0;
            third = 0;
        }

        public override void CollectData(DataChunk chunk)
        {
            base.CollectData(chunk);
            first += ((DefineToneData)chunk).first;
            second += ((DefineToneData)chunk).second;
            third += ((DefineToneData)chunk).third;
        }

        public override void CalcAverage()
        {
            base.CalcAverage();
            averageFirst = (float) first / count;
            averageSecond = (float) second / count;
            averageThird = (float) third / count;
        }

        public override string ShowAsString()
        {
            String result = base.ShowAsString();
            result += "[1] attempt: " + averageFirst.ToString("F2");
            result += "<br>[2] attempt: " + averageSecond.ToString("F2");
            result += "<br>[3] attempt: " + averageThird.ToString("F2");
            result += "<br>";
            return result;
        }
    }

    public class AverageClicks : AverageAttempts
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
            averageClicks = (float) clicks / count;
        }

        public override string ShowAsString()
        {
            String result = base.ShowAsString();
            result += "<i>Clicks: " + averageClicks.ToString("F2") + "</i>";
            result += "<br>";
            return result;
        }
    }

}