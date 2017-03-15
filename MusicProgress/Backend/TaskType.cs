using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    /*
     * Тип задания: Поступление в ДМШ (проверка музыкального слуха) -> Уровень 3: Малые секунды и примы
     * Тип задания: Мелодии в пределах 13 клавиш -> Поиск прозвучавшего тона
     * Тип задания: Мелодии в пределах 13 клавиш -> Определение прозвучавшего тона
     */
    public class TaskType
    {
        public string nameInFile;
        public string name;

        public TaskType(string _name, string _nameInFile) 
        {
            name = _name;
            nameInFile = _nameInFile;
        }

    }

    public class TypesAggregator
    {
        Dictionary<string, TaskType> dict;

        public TypesAggregator()
        {
            LoadTypes();
        }

        private  void LoadTypes()
        {
            dict = new Dictionary<string, TaskType>();
            dict.Clear();
            dict.Add("Тип задания: Поступление в ДМШ (проверка музыкального слуха) -> Уровень 3: Малые секунды и примы",
                new TaskType("Выше-ниже", "Тип задания: Поступление в ДМШ (проверка музыкального слуха) -> Уровень 3: Малые секунды и примы"));
            dict.Add("Тип задания: Мелодии в пределах 13 клавиш -> Поиск прозвучавшего тона", 
                new TaskType("Поиск ноты", "Тип задания: Мелодии в пределах 13 клавиш -> Поиск прозвучавшего тона"));
            dict.Add("Тип задания: Мелодии в пределах 13 клавиш -> Определение прозвучавшего тона", 
                new TaskType("Определение ноты", "Тип задания: Мелодии в пределах 13 клавиш -> Определение прозвучавшего тона"));
        }

        public TaskType GetTaskType(string nameInFile)
        {
            if (dict.ContainsKey(nameInFile))
                return dict[nameInFile];
            else
                return new TaskType("error", "bug");
        }
    }

}