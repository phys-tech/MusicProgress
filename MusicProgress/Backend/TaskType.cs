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

    /*
    public class TaskType
    {
        public string nameInFile;
        public string name;

        public TaskType(string _name, string _nameInFile) 
        {
            name = _name;
            nameInFile = _nameInFile;
        }

    }*/
    /*
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
    }*/

public enum newTask { eUpDown = 0, eSearchTone, eDefineTone, eUnknown};

public static class TestClass
{
    static Dictionary<newTask, string> realName;
    static Dictionary<string, newTask> filename;

    public static void Init()
    {
        realName = new Dictionary<newTask, string>();
        realName.Add(newTask.eUpDown, "Выше-ниже");
        realName.Add(newTask.eSearchTone, "Поиск ноты");
        realName.Add(newTask.eDefineTone, "Определение ноты");
        realName.Add(newTask.eUnknown, "unknown Shit");

        filename = new Dictionary<string, newTask>();
        filename.Add("Тип задания: Поступление в ДМШ (проверка музыкального слуха) -> Уровень 3: Малые секунды и примы", newTask.eUpDown);
        filename.Add("Тип задания: Мелодии в пределах 13 клавиш -> Поиск прозвучавшего тона", newTask.eSearchTone);
        filename.Add("Тип задания: Мелодии в пределах 13 клавиш -> Определение прозвучавшего тона", newTask.eDefineTone);
    }

    public static string AsString(newTask value)
    {
        return realName[value];
    }

    public static newTask AsEnum(string longname)
    { 
        if (filename.ContainsKey(longname))
            return filename[longname];
        else
            return newTask.eUnknown;
    }
}


}