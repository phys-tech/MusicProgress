using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MusicProgress.Backend
{

    public abstract class DataChunk
    {
        public Task task;
        public int totalTasks;
        public int successful;
        public int failed;
        public int repeats;
        public TimeSpan duration;
        public DateTime date;

        protected string durationFormat;

        public DataChunk()
        {
            totalTasks = 0;
            successful = 0;
            failed = 0;
            repeats = 0;
            durationFormat = @"mm\:ss";
        }

        public DataChunk(DateTime _date)
        {
            date = _date;
            durationFormat = @"mm\:ss";
        }

        public abstract bool ReadData(string[] _stringArray);
        public abstract string ShowData();

        public virtual void PrepareDataForChart(ref DataRow row)
        {
            row["Date"] = date.ToString("dd.MM.yyyy");
            row["Repeats"] = repeats;
            row["Failed"] = failed;
            row["Duration"] = duration;
        }

    }

    public class UpDownData : DataChunk
    {
        public UpDownData() : base (){}
        public UpDownData(DateTime _date) : base (_date) 
        {
            task = Task.eUpDown;
        }


        public override bool ReadData(string[] _stringArray)
        {
            /*
                Количество полученных заданий этого типа = 50
                Успешно выполнено = 46
                Не выполнено заданий этого типа = 4
                Использовано повторных прослушиваний = 0
                Использовано времени 02:44
            */
            string[] rawData = _stringArray;
            int i = 0;
            while (!rawData[i].StartsWith("Количество полученных заданий этого типа"))
                i++;

            totalTasks = int.Parse(rawData[i].Substring(rawData[i].IndexOf("=") + 1));
            successful = int.Parse(rawData[i + 1].Substring(rawData[i + 1].IndexOf("=") + 1));
            failed = int.Parse(rawData[i + 2].Substring(rawData[i + 2].IndexOf("=") + 1));
            repeats = int.Parse(rawData[i + 3].Substring(rawData[i + 3].IndexOf("=") + 1));            
            string time = rawData[i + 4].Substring(21);
            duration = TimeSpan.ParseExact(time, durationFormat, null);
            
            return totalTasks != 0;
        }

        public override string ShowData()
        {
            string sDate = date.ToString("dd MMMM yyyy");
            string sType = TaskConverter.AsString(task);
            string sTotal = totalTasks.ToString() + " заданий";
            string sSuccess = successful.ToString();
            string sFail = failed.ToString();
            string sRepeats = repeats.ToString() + " повторов";
            string sTime = duration.ToString();
            string output = sDate + " - " + sType + ": " + sTotal + " (  " + sSuccess + " / " + sFail + " ) " + "[" + sRepeats + "] " + "\t\t продолжительность " + sTime + "<br>";
            return output;
        }

        public override void PrepareDataForChart(ref DataRow row)
        {
            base.PrepareDataForChart(ref row);
            row["Y1"] = successful;
        }
    }

    public class DefineToneData : DataChunk
    {
        public int first;
        public int second;
        public int third;

        public DefineToneData() : base() { }
        public DefineToneData(DateTime _date)
            : base(_date)
        {
            task = Task.eDefineTone;
        }

        public override bool ReadData(string[] _stringArray)
        {
            string[] rawData = _stringArray;
            int i = 0;
            while (!rawData[i].StartsWith("Количество полученных / выполненных заданий этого типа"))
                i++;

            StringParser.TwoNumbers(rawData[i], out totalTasks, out successful);
            StringParser.ThreeNumbers(rawData[i + 1], out first, out second, out third);
            failed = int.Parse(rawData[i + 2].Substring((rawData[i + 2].IndexOf("=") + 1)));
            repeats = int.Parse(rawData[i + 3].Substring((rawData[i + 3].IndexOf("=") + 1)));
            string time = rawData[i + 4].Substring(21);
            duration = TimeSpan.ParseExact(time, durationFormat, null);

            return totalTasks != 0;
        }

        public override string ShowData()
        {
            string sDate = date.ToString("dd MMMM yyyy");
            string sType = TaskConverter.AsString(task);
            string sTotal = totalTasks.ToString() + " заданий";
            string sSuccess = successful.ToString();
            string sFail = failed.ToString();
            string sFirst = first.ToString();
            string sSecond = second.ToString();
            string sThird = third.ToString();
            string sRepeats = repeats.ToString() + " повторов";
            string sTime = duration.ToString();
            string attempts = " <u>Попытки: " + sFirst + "|" + sSecond + "|" + sThird + "</u> ";
            string output = sDate + " - " + sType + ": " + sTotal + " (  " + sSuccess + " / " + sFail + " ) " + "[" + sRepeats + "] " + attempts + "\t\t продолжительность " + sTime + "<br>";
            return output;
        }

        public override void PrepareDataForChart(ref DataRow row)
        {
            base.PrepareDataForChart(ref row);
            row["Y1"] = first;
            row["Y2"] = second;
            row["Y3"] = third;
        }
    }

    public class SearchToneData : DefineToneData
    { 
        public int clicks;

        public SearchToneData() : base() { }
        public SearchToneData(DateTime _date) : base(_date) 
        {
            task = Task.eSearchTone;
        }

        public override bool ReadData(string[] _stringArray)
        {
            /*
                Количество полученных / выполненных заданий этого типа = 50 / 50
                Успешно выполнено с 1-й / 2-й / 3-й попытки = 49 / 1 / 0
                Не выполнено заданий этого типа = 0
                Использовано повторных прослушиваний = 0
                Использовано нажатий на клавиши пианино = 72
                Использовано времени 03:42* 
            */ 
            string[] rawData = _stringArray;
            int i = 0;
            while (!rawData[i].StartsWith("Количество полученных / выполненных заданий этого типа"))
                i++;

            StringParser.TwoNumbers(rawData[i], out totalTasks, out successful);
            StringParser.ThreeNumbers(rawData[i + 1], out first, out second, out third);
            failed = int.Parse(rawData[i + 2].Substring((rawData[i + 2].IndexOf("=") + 1)));
            repeats = int.Parse(rawData[i + 3].Substring((rawData[i + 3].IndexOf("=") + 1)));
            clicks = int.Parse(rawData[i + 4].Substring((rawData[i + 4].IndexOf("=") + 1)));
            string time = rawData[i + 5].Substring(21);
            duration = TimeSpan.ParseExact(time, durationFormat, null);

            return totalTasks != 0;
        }

        public override string ShowData()
        {
            string sDate = date.ToString("dd MMMM yyyy");
            string sType = TaskConverter.AsString(task);
            string sTotal = totalTasks.ToString() + " заданий";
            string sSuccess = successful.ToString();
            string sFirst = first.ToString();
            string sSecond = second.ToString();
            string sThird = third.ToString();
            string sFail = failed.ToString();
            string sClicks = clicks.ToString() + " кликов";
            string sRepeats = repeats.ToString() + " повторов";
            string sTime = duration.ToString();
            string attempts = " <u>Попытки: " + sFirst + "|" + sSecond + "|" + sThird + "</u> ";
            string output = sDate + " - " + sType + ": " + sTotal + " (  " + sSuccess + " / " + sFail + " ) [" + sRepeats + "] " + attempts + " <b>" + sClicks + "</b>" + "\t\t продолжительность " + sTime + "<br>";
            return output;
        }

        public override void PrepareDataForChart(ref DataRow row)
        {
            base.PrepareDataForChart(ref row);
            row["Clicks"] = clicks;
        }

    }

    public class UnknownData : DataChunk
    {
        public string Wtf;

        public UnknownData() : base() { }
        public UnknownData(DateTime _date) : base(_date)
        {
            task = Task.eUnknown;
        }

        public override bool ReadData(string[] _stringArray)
        {
            Wtf = "";
            int num = _stringArray.Count();
            for (int i = 0; i < num; i++)
                Wtf += _stringArray[i];
            return true;
        }

        public override string ShowData()
        {
            string sDate = date.ToString("dd MMMM yyyy");
            string sTask = TaskConverter.AsString(task);
            string output = "<b>" + sDate + " - " + sTask +  "</b><br>";
            return output;
        }
    }

    public class Sequence2Notes : DefineToneData
    {
        public Sequence2Notes() : base() { }
        public Sequence2Notes(DateTime _date)
            : base(_date)
        {
            task = Task.eSequence2;
        }
    }

    public class Sequence4Notes : DefineToneData
    {
        public Sequence4Notes() : base() { }
        public Sequence4Notes(DateTime _date)
            : base(_date)
        {
            task = Task.eSequence4;
        }
    }

    public class Search37Tone : SearchToneData
    {
        public Search37Tone() : base() { }
        public Search37Tone(DateTime _date) : base(_date)
        {
            task = Task.eSearch37;
        }
    }

    public class Define37Tone : DefineToneData
    {
        public Define37Tone() : base() { }
        public Define37Tone(DateTime _date) : base(_date)
        {
            task = Task.eDefine37;
        }
    }

    public class Sequence2N37Tones : DefineToneData
    {
        public Sequence2N37Tones() : base() { }
        public Sequence2N37Tones(DateTime _date) : base(_date)        
        {
            task = Task.eSequence2N37T;
        }
    }

}