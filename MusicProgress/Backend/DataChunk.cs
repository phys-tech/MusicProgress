﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            durationFormat = @"m\:ss";
        }

        public DataChunk(DateTime _date)
        {
            date = _date;
            durationFormat = @"m\:ss";
        }

        public abstract bool ReadData(string[] _stringArray);
        public abstract string ShowData();

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
            string time = rawData[i + 4].Substring(22);
            duration = TimeSpan.ParseExact(time, durationFormat, null);
            
            return totalTasks != 0;
        }

        public override string ShowData()
        {
            string sDate = date.ToLongDateString();
            string sType = TaskConverter.AsString(task);
            string sTotal = totalTasks.ToString();
            string sSuccess = successful.ToString();
            string sFail = failed.ToString();
            string sRepeats = repeats.ToString();
            string sTime = duration.ToString();
            string output = sDate + " - " + sType + " - " + sTotal + " (  " + sSuccess + " / " + sFail + " ) " + "[" + sRepeats + "] " + "\t\t t = " + sTime + "<br>";
            return output;
        }
    }

    public class SearchToneData : DataChunk
    { 
        public int first;
        public int second;
        public int third;
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
            string time = rawData[i + 5].Substring(22);
            duration = TimeSpan.ParseExact(time, durationFormat, null);

            return totalTasks != 0;
        }

        public override string ShowData()
        {
            string sDate = date.ToLongDateString();
            string sType = TaskConverter.AsString(task);
            string sTotal = totalTasks.ToString();
            string sSuccess = successful.ToString();
            string sFirst = first.ToString();
            string sSecond = second.ToString();
            string sThird = third.ToString();
            string sFail = failed.ToString();
            string sClicks = clicks.ToString();
            string sRepeats = repeats.ToString();
            string sTime = duration.ToString();
            string attempts = " <u>|" + sFirst + "|" + sSecond + "|" + sThird + "</u> ";
            string output = sDate + " - " + sType + " - " + sTotal + " (  " + sSuccess + " / " + sFail + " ) " + attempts + "* <b>"+ sClicks + "</b> [" + sRepeats + "] " + "\t\t t = " + sTime + "<br>";
            return output;
        }


    }

    public class DefineToneData : DataChunk
    {
        public int first;
        public int second;
        public int third;

        public DefineToneData() : base() { }
        public DefineToneData(DateTime _date) : base(_date) 
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
            string time = rawData[i + 4].Substring(22);
            duration = TimeSpan.ParseExact(time, durationFormat, null);

            return totalTasks != 0;
        }

        public override string ShowData()
        {
            string sDate = date.ToLongDateString();
            string sType = TaskConverter.AsString(task);
            string sTotal = totalTasks.ToString();
            string sSuccess = successful.ToString();
            string sFail = failed.ToString();
            string sFirst = first.ToString();
            string sSecond = second.ToString();
            string sThird = third.ToString();
            string sRepeats = repeats.ToString();
            string sTime = duration.ToString();
            string attempts = " <u>|" + sFirst + "|" + sSecond + "|" + sThird + "</u> ";
            string output = sDate + " - " + sType + " - " + sTotal + " (  " + sSuccess + " / " + sFail + " ) " + attempts  + "[" + sRepeats + "] " + "\t\t t = " + sTime + "<br>";
            return output;
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
            string sDate = date.ToLongDateString();
            string sTask = TaskConverter.AsString(task);
            string output = "<b>" + sDate + " - " + sTask + "</b><br>";
            return output;
        }
    }

}