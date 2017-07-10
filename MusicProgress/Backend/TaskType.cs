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
     * Тип задания: Мелодии в пределах 37 клавиш -> Поиск прозвучавшего тона
     * Тип задания: Мелодии в пределах 13 клавиш -> Определение последовательности из 2-х звуков
     * Тип задания: Мелодии в пределах 37 клавиш -> Определение прозвучавшего тона
     * Тип задания: Мелодии в пределах 37 клавиш -> Определение последовательности из 2-х звуков
     */

    public enum Task { eUpDown = 0, eSearchTone, eDefineTone, eSequence2, eSequence4, eSearch37, eDefine37, eSequence2N37T, eUnknown };

public static class TaskConverter
{
    private static Dictionary<Task, string> taskShortName;
    private static Dictionary<string, Task> taskLongName;

    static TaskConverter()
    {
        Init();
    }

    private static void Init()
    {
        taskShortName = new Dictionary<Task, string>();
        taskShortName.Add(Task.eUpDown, "Выше-ниже");
        taskShortName.Add(Task.eSearchTone, "Поиск ноты");
        taskShortName.Add(Task.eDefineTone, "Определение ноты");
        taskShortName.Add(Task.eSequence2, "Последовательность из 2 звуков"); 
        taskShortName.Add(Task.eSequence4, "Последовательность из 4 звуков");
        taskShortName.Add(Task.eSearch37, "Поиск 37 тонов");
        taskShortName.Add(Task.eDefine37, "Определение ноты из 37 тонов");
        taskShortName.Add(Task.eSequence2N37T, "Последовательность 2 звуков 37 тонов");
        taskShortName.Add(Task.eUnknown, "Unknown Shit");


        taskLongName = new Dictionary<string, Task>();
        taskLongName.Add("Тип задания: Поступление в ДМШ (проверка музыкального слуха) -> Уровень 3: Малые секунды и примы", Task.eUpDown);
        taskLongName.Add("Тип задания: Мелодии в пределах 13 клавиш -> Поиск прозвучавшего тона", Task.eSearchTone);
        taskLongName.Add("Тип задания: Мелодии в пределах 13 клавиш -> Определение прозвучавшего тона", Task.eDefineTone);
        taskLongName.Add("Тип задания: Мелодии в пределах 13 клавиш -> Определение последовательности из 2-х звуков", Task.eSequence2);
        taskLongName.Add("Тип задания: Мелодии в пределах 13 клавиш -> Определение последовательности из 4-х звуков", Task.eSequence4);
        taskLongName.Add("Тип задания: Мелодии в пределах 37 клавиш -> Поиск прозвучавшего тона", Task.eSearch37);
        taskLongName.Add("Тип задания: Мелодии в пределах 37 клавиш -> Определение прозвучавшего тона", Task.eDefine37);
        taskLongName.Add("Тип задания: Мелодии в пределах 37 клавиш -> Определение последовательности из 2-х звуков", Task.eSequence2N37T);
    }

    public static string AsString(Task eValue)
    {
        return taskShortName[eValue];
    }

    public static Task AsEnum(string sName)
    { 
        if (taskLongName.ContainsKey(sName))
            return taskLongName[sName];
        else
            return Task.eUnknown;
    }
}


}