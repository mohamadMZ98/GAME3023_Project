using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class EventManager
{

    public static event Action<AchievementSO> OnAchievementUnlocked;

    public static void DoFireAchievementUnlock(AchievementSO achievement)
    {
        OnAchievementUnlocked?.Invoke(achievement);
    }


    public static event Func<AchievementSO , bool> IsAchievementUnlocked;

    public static bool DoFireIsAchievementUnlocked(AchievementSO achievementSO)
    {
        return (bool)IsAchievementUnlocked?.Invoke(achievementSO);
    }

    public static event Action<string> OnShowNotification;

    public static void DoFireShowNotification(string achievementName)
    {
        OnShowNotification?.Invoke(achievementName);
    }

}
