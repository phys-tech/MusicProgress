using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MusicProgress.Backend
{
    public class DataCollector
    {
        private const string pathToFiles = "F:\\MyStuff\\Temp\\MusicResults\\";
        private const string extension = "*.txt";
        private TypesAggregator typesAggr;

        public string allfiles;
        public int filesCounter;

        public List<DataChunk> data;

        private Dictionary<string, DataCreator> factoryMap;

        public DataCollector()
        {
            typesAggr = new TypesAggregator();
            factoryMap = new Dictionary<string, DataCreator>();
            factoryMap.Add("Выше-ниже", new UpDownCreator());
            factoryMap.Add("Поиск ноты", new SearchToneCreator());
            factoryMap.Add("Определение ноты", new DefineToneCreator());
            LoadData();
        }

        public void LoadData()
        {
            allfiles = "";
            filesCounter = 0;
            data = new List<DataChunk>();
            IEnumerable<string> filelist = Directory.EnumerateFiles(pathToFiles, extension, SearchOption.TopDirectoryOnly);
            foreach (string file in filelist)
            {
                allfiles += Path.GetFileName(file) + "<br>";
                filesCounter++;
                ReadOneFile(file);
            }
        }

        private void ReadOneFile(string path)
        {
            DataChunk tempData;
            DateTime localdate;
            TaskType task;
            string[] board = File.ReadAllLines(path);
            if (!board[0].StartsWith("Дата и время старта журнала"))
                return;
            if (!board[2].StartsWith("Тип задания:"))
                return;

            localdate = DateTime.Parse(board[0].Substring(28));

            int lineNumber = 2;
            while (!board[lineNumber].StartsWith("Дата и время остановки журнала"))
            {
                task = typesAggr.GetTaskType(board[lineNumber]);

                if (task.name == "error")
                {
                    while (!board[lineNumber].StartsWith("————————————————"))
                        lineNumber++;
                    lineNumber++;
                    continue;
                }

                tempData = factoryMap[task.name].FactoryMethod_2(localdate);
                tempData.type = task;

                lineNumber++;
                int a = 0;
                string[] tempStringArray = new string[15];
                while (!board[lineNumber].StartsWith("————————————————"))
                {
                    tempStringArray[a] = board[lineNumber];
                    lineNumber++;
                    a++;
                }
                if (tempData.ReadData(tempStringArray))
                    data.Add(tempData);

                lineNumber++;
            }
        }
    }
}