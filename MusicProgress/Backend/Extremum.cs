using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public class ExtremumCreator
    {
        public Extremum CreateExtremum(Task _task)
        {
            if (_task == Task.eSearchTone || _task == Task.eSearch37)
                return new ExtremumClicks(_task);
            else if (_task == Task.eDefineTone || _task == Task.eDefine37 || _task == Task.eSequence2 || _task == Task.eSequence2N37T)
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
            //bestChunk = DataChunk();
            //worstChunk = DataChunk();
            //successPercentBest = 0.0F;
            //failedPercentWorst = 100.0F;
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
            result += "Success: " + bestChunk.successful + " / " + bestChunk.totalTasks;
            result += "Happened on " + bestChunk.date.ToLongDateString() + " with " + bestChunk.repeats + " repeats";
            result += "<br>Worst result:";
            result += "Failed: " + worstChunk.failed + " / " + worstChunk.totalTasks;
            result += "Happened on " + worstChunk.date.ToLongDateString() + " with " + worstChunk.repeats + " repeats";
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
        }

        public override void AppendData(DataChunk chunk)
        {
            DefineToneData localChunk = (DefineToneData) chunk;

            if (localChunk.first > ((DefineToneData)bestChunk).first)
                bestChunk = localChunk;
            if (localChunk.first < ((DefineToneData)worstChunk).first)
                worstChunk = localChunk;
        }
        public override String ShowAsString()
        {
            String result = "<b>" + TaskConverter.AsString(task) + "</b>";
            result += "<br>Best result:";
            result += "Success: " + ((DefineToneData)bestChunk).first + " / " + bestChunk.totalTasks;
            result += "Happened on " + bestChunk.date.ToLongDateString() + " with " + bestChunk.repeats + " repeats";
            result += "<br>Worst result:";
            result += "Failed: " + ((DefineToneData)worstChunk).first + " / " + worstChunk.totalTasks;
            result += "Happened on " + worstChunk.date.ToLongDateString() + " with " + worstChunk.repeats + " repeats";
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
        }

        public override void AppendData(DataChunk chunk)
        {
            SearchToneData localChunk = (SearchToneData) chunk;

            if (localChunk.clicks < ((SearchToneData)bestChunk).clicks)
                bestChunk = localChunk;
            if (localChunk.clicks > ((SearchToneData)worstChunk).clicks)
                worstChunk = localChunk;
        }

        public override string ShowAsString()
        {
            String result = "<b>" + TaskConverter.AsString(task) + "</b>";
            result += "<br>Best result:";
            result += "Success: " + ((SearchToneData)bestChunk).clicks + " / " + bestChunk.totalTasks;
            result += "Happened on " + bestChunk.date.ToLongDateString() + " with " + bestChunk.repeats + " repeats";
            result += "<br>Worst result:";
            result += "Failed: " + ((SearchToneData)worstChunk).clicks + " / " + worstChunk.totalTasks;
            result += "Happened on " + worstChunk.date.ToLongDateString() + " with " + worstChunk.repeats + " repeats";
            return result;
        }
    }
}