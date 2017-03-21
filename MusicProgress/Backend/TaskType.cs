﻿using System;
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

public enum Task { eUpDown = 0, eSearchTone, eDefineTone, eSearch37, eUnknown};

public static class TaskConverter
{
    private static Dictionary<Task, string> taskShortName;
    private static Dictionary<string, Task> taskLongName;

    public static void Init()
    {
        taskShortName = new Dictionary<Task, string>();
        taskShortName.Add(Task.eUpDown, "Выше-ниже");
        taskShortName.Add(Task.eSearchTone, "Поиск ноты");
        taskShortName.Add(Task.eDefineTone, "Определение ноты");
        taskShortName.Add(Task.eSearch37, "Поиск 37 тонов");
        taskShortName.Add(Task.eUnknown, "Unknown Shit");

        taskLongName = new Dictionary<string, Task>();
        taskLongName.Add("Тип задания: Поступление в ДМШ (проверка музыкального слуха) -> Уровень 3: Малые секунды и примы", Task.eUpDown);
        taskLongName.Add("Тип задания: Мелодии в пределах 13 клавиш -> Поиск прозвучавшего тона", Task.eSearchTone);
        taskLongName.Add("Тип задания: Мелодии в пределах 13 клавиш -> Определение прозвучавшего тона", Task.eDefineTone);
        taskLongName.Add("Тип задания: Мелодии в пределах 37 клавиш -> Поиск прозвучавшего тона", Task.eSearch37);
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