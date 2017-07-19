using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public class ExtremumCreator
    {
        public Extremum Create(Task _task)
        {
            if (_task == Task.eSearchTone || _task == Task.eSearch37)
                return new ExtremumClicks(_task);
            else if (_task == Task.eDefineTone || _task == Task.eSequence2 || _task == Task.eSequence4 || _task == Task.eDefine37 || _task == Task.eSequence2N37T)
               return new ExtremumAttempts(_task);
            else
                return new Extremum(_task);
        }
    }


    public class Extremum
    {
        protected Task task;
        protected DataChunk bestChunk;
        protected DataChunk worstChunk;

        public Extremum(Task _task)
        {
            task = _task;
            bestChunk = new UpDownData();
            worstChunk = new UpDownData();
        }

        public virtual void AppendData(DataChunk data)
        {
            if (data.successful > bestChunk.successful)
                bestChunk = data;
            if (data.failed > worstChunk.failed)
                worstChunk = data;
        }

        public virtual String ShowAsString()
        {
            String result = "<b>" + TaskConverter.AsString(task) + "</b>";
            result += "<br>Best result:";
            result += "<br>Success: " + bestChunk.successful + " / " + bestChunk.totalTasks;
            result += "<br>Happened on " + bestChunk.date.ToLongDateString() + " with " + bestChunk.repeats + " repeats and took " + bestChunk.duration.ToString();
            result += "<br>Worst result:";
            result += "<br>Failed: " + worstChunk.failed + " / " + worstChunk.totalTasks;
            result += "<br>Happened on " + worstChunk.date.ToLongDateString() + " with " + worstChunk.repeats + " repeats and took " + worstChunk.duration.ToString();
            result += "<br>";
            return result;
        }
    }

    public class ExtremumAttempts : Extremum
    {
        public ExtremumAttempts(Task _task)
            : base(_task)
        {
            bestChunk = new DefineToneData();
            worstChunk = new DefineToneData();
            ((DefineToneData)worstChunk).first = 1000;      // big number to allow the seek mechanism
            bestChunk.totalTasks = 1;                       // to prevent divide by zero
            worstChunk.totalTasks = 1;
        }

        public override void AppendData(DataChunk chunk)
        {
            DefineToneData localChunk = (DefineToneData) chunk;
            double attemptRatio = (double) localChunk.first / localChunk.totalTasks;

            if (attemptRatio > (double)((DefineToneData)bestChunk).first / bestChunk.totalTasks)
                bestChunk = localChunk;
            if (attemptRatio < (double)((DefineToneData)worstChunk).first / worstChunk.totalTasks)
                worstChunk = localChunk;
        }
        public override String ShowAsString()
        {
            String result = "<b>" + TaskConverter.AsString(task) + "</b>";
            result += "<br>Best result:";
            result += "<br>First attempt: " + ((DefineToneData)bestChunk).first + " / " + bestChunk.totalTasks + " tasks";
            result += "<br>Happened on " + bestChunk.date.ToLongDateString() + " with " + bestChunk.repeats + " repeats and took " + bestChunk.duration.ToString();
            result += "<br>Worst result:";
            result += "<br>First attempt: " + ((DefineToneData)worstChunk).first + " / " + worstChunk.totalTasks + " tasks";
            result += "<br>Happened on " + worstChunk.date.ToLongDateString() + " with " + worstChunk.repeats + " repeats  and took " + worstChunk.duration.ToString();
            result += "<br>";
            return result;
        }
    }

    public class ExtremumClicks : ExtremumAttempts
    {
        public ExtremumClicks(Task _task)
            : base(_task)
        {
            bestChunk = new SearchToneData();
            worstChunk = new SearchToneData();
            ((SearchToneData)bestChunk).clicks = 1000;      // big number to allow the seek mechanism
            bestChunk.totalTasks = 1;                       // to prevent divide by zero
            worstChunk.totalTasks = 1;
        }

        public override void AppendData(DataChunk chunk)
        {
            SearchToneData localChunk = (SearchToneData) chunk;
            double clicksRatio = (double) localChunk.clicks / localChunk.totalTasks;

            if (clicksRatio < (double)((SearchToneData)bestChunk).clicks / bestChunk.totalTasks)
                bestChunk = localChunk;
            if (clicksRatio > (double)((SearchToneData)worstChunk).clicks / worstChunk.totalTasks)
                worstChunk = localChunk;
        }

        public override string ShowAsString()
        {
            String result = "<b>" + TaskConverter.AsString(task) + "</b>";
            result += "<br>Best result:";
            result += "<br>Clicks: " + ((SearchToneData)bestChunk).clicks + " per " + bestChunk.totalTasks + " tasks";
            result += "<br>Happened on " + bestChunk.date.ToLongDateString() + " with " + bestChunk.repeats + " repeats and took " + bestChunk.duration.ToString();
            result += "<br>Worst result:";
            result += "<br>Clicks: " + ((SearchToneData)worstChunk).clicks + " per " + worstChunk.totalTasks + " tasks";
            result += "<br>Happened on " + worstChunk.date.ToLongDateString() + " with " + worstChunk.repeats + " repeats and took " + worstChunk.duration.ToString();
            result += "<br>";
            return result;
        }
    }
}