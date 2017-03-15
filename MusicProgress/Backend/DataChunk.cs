using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{

    public abstract class DataChunk
    {
        public TaskType type;
        public int totalTasks;
        public int successful;
        public int failed;
        public int repeats;
        public TimeSpan duration;
        public DateTime date;

        public DataChunk()
        {
            totalTasks = 0;
            successful = 0;
            failed = 0;
            repeats = 0;
        }
        /*
        public DataChunk(int _total, int _success, int _failed)
        {
            totalTasks = _total;
            successful = _success;
            failed = _failed;
        }*/

        public DataChunk(DateTime _date)
        {
            date = _date;
        }

        public abstract string TryMe();
        public abstract bool ReadData(string[] _stringArray);

    }

    public class UpDownData : DataChunk
    {
        public UpDownData() : base (){}
        public UpDownData(DateTime _date) : base (_date) {}

        public override string TryMe()
        {
            return "UpD";
        }

        public override bool ReadData(string[] _stringArray)
        {
            /*
             * Количество полученных заданий этого типа = 50
                Успешно выполнено = 46
                Не выполнено заданий этого типа = 4
                Использовано повторных прослушиваний = 0
                Использовано времени 02:44
             * 
            */
            string[] rawData = _stringArray;
            int i = 0;
            while (!rawData[i].StartsWith("Количество полученных заданий этого типа"))
                i++;

            totalTasks = int.Parse(rawData[i].Substring(rawData[i].IndexOf("=") + 1));
            successful = int.Parse(rawData[i + 1].Substring(rawData[i + 1].IndexOf("=") + 1));
            failed = int.Parse(rawData[i + 2].Substring(rawData[i + 2].IndexOf("=") + 1));
            repeats = int.Parse(rawData[i + 3].Substring(rawData[i + 3].IndexOf("=") + 1));
            return true;
        }
    }

    public class SearchToneData : DataChunk
    { 
        public int first;
        public int second;
        public int third;
        public int clicks;

        public SearchToneData() : base() { }
        public SearchToneData(DateTime _date) : base(_date) { }

        public override string TryMe()
        {
            return "Search";
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


            int start = rawData[i].IndexOf("=") + 1;
            int end = rawData[i].LastIndexOf("/");
            int length = end - start;
            totalTasks = int.Parse(rawData[i].Substring(start, length));
            successful = int.Parse(rawData[i].Substring(end + 1));
            //first = int.Parse(rawData[i + 1]);
            failed = int.Parse(rawData[i + 2].Substring((rawData[i + 2].IndexOf("=") + 1)));
            repeats = int.Parse(rawData[i + 3].Substring((rawData[i + 3].IndexOf("=") + 1)));
            clicks = int.Parse(rawData[i + 4].Substring((rawData[i + 4].IndexOf("=") + 1)));

            return true;
        }

    }

    public class DefineToneData : DataChunk
    {
        public int first;
        public int second;
        public int third;

        public DefineToneData() : base() { }
        public DefineToneData(DateTime _date) : base(_date) { }

        public override string TryMe()
        {
            return "Define";
        }

        public override bool ReadData(string[] _stringArray)
        {
            string[] rawData = _stringArray;
            int i = 0;
            while (!rawData[i].StartsWith("Количество полученных / выполненных заданий этого типа"))
                i++;


            int start = rawData[i].IndexOf("=") + 1;
            int end = rawData[i].LastIndexOf("/");
            int length = end - start;
            totalTasks = int.Parse(rawData[i].Substring(start, length));
            successful = int.Parse(rawData[i].Substring(end + 1));
            //first = int.Parse(rawData[i + 1]);
            failed = int.Parse(rawData[i + 2].Substring((rawData[i + 2].IndexOf("=") + 1)));
            repeats = int.Parse(rawData[i + 3].Substring((rawData[i + 3].IndexOf("=") + 1)));

            return true;
        }

    }

}