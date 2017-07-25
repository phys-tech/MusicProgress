using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MusicProgress.Backend
{
    using ListOfChunks = List<DataChunk>;

    public class DataCollector
    {
        private const string pathToFiles = "F:\\MyStuff\\Temp\\MusicResults\\";
        private string alterPath = "..\\repository\\MusicProgress\\App_Data\\";
        private const string extension = "*.txt";

        public string allfiles;
        public int filesCounter;

        public ListOfChunks data;

        private Dictionary<Task, DataCreator> factoryMap;

        public DataCollector()
        {
            factoryMap = new Dictionary<Task, DataCreator>();
            factoryMap.Add(Task.eUpDown, new UpDownCreator());
            factoryMap.Add(Task.eSearchTone, new SearchToneCreator());
            factoryMap.Add(Task.eDefineTone, new DefineToneCreator());
            factoryMap.Add(Task.eSequence2, new Sequence2NotesCreator());
            factoryMap.Add(Task.eSequence4, new Sequence4NotesCreator());
            factoryMap.Add(Task.eSearch37, new Search37Creator());
            factoryMap.Add(Task.eDefine37, new Define37NotesCreator());
            factoryMap.Add(Task.eSequence2N37T, new Sequence2N37TCreator());
            factoryMap.Add(Task.eUnknown, new UnknownCreator());

            LoadData();
        }

        public void LoadData()
        {
            allfiles = "";
            filesCounter = 0;
            data = new ListOfChunks();

            //alterPath = HttpContext.Current.Request.ApplicationPath + alterPath;

            string path = (Directory.Exists(pathToFiles)) ? (pathToFiles) : (alterPath);
            IEnumerable<string> filelist = Directory.EnumerateFiles(path, extension, SearchOption.TopDirectoryOnly);
            foreach (string file in filelist)
            {
                allfiles += Path.GetFileName(file) + "<br>";
                filesCounter++;
                ReadOneFile(file);
            }
        }

        private void ReadOneFile(string path)
        {
            string[] board = File.ReadAllLines(path);
            if (!board[0].StartsWith("Дата и время старта журнала"))
                return;
            if (!board[2].StartsWith("Тип задания:"))
                return;

            DateTime localdate = DateTime.Parse(board[0].Substring(28));

            int lineNumber = 2;
            while (!board[lineNumber].StartsWith("Дата и время остановки журнала"))
            {
                Task task = TaskConverter.AsEnum(board[lineNumber]);

                DataChunk tempData = factoryMap[task].FactoryMethod_2(localdate);

                lineNumber++;
                int a = 0;
                string[] tempStringArray = new string[15];
                while (!board[lineNumber].StartsWith("————————————————"))
                    tempStringArray[a++] = board[lineNumber++];

                if (tempData.ReadData(tempStringArray))
                    data.Add(tempData);

                lineNumber++;
            }
        }
    }
}