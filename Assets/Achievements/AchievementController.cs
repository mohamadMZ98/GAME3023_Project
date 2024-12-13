using System.Collections;
using System.Collections.Generic;
//using System.Xml;
using UnityEngine;
//using Newtonsoft.Json;
using Unity.VisualScripting;
using System;

public class AchievementController : MonoBehaviour
{
    private List<string> unlockeAchievements = new List<string>();

    private const string ACHIEVEMENT_KEY = "Achievements";

    private static AchievementController achievementController;

    private void Awake()
    {
        if (achievementController == null)
        {
            achievementController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void Start()
    {
       
        RegisterToevents();
    }

    void RegisterToevents()
    {
        EventManager.OnAchievementUnlocked += OnUnlockAchievement;
        EventManager.IsAchievementUnlocked += IsAchievementUnlocked;
    }

    private bool IsAchievementUnlocked(AchievementSO achievement)
    {
        return unlockeAchievements.Contains(achievement.achievement_ID);
    }


    public void OnUnlockAchievement(AchievementSO achievementSO)
    {
        if(!IsAchievementUnlocked(achievementSO))
        {
            unlockeAchievements.Add(achievementSO.achievement_ID);

          

            EventManager.DoFireShowNotification(achievementSO.achievemntName);
        }
        else
        {
            Debug.Log("Achievemnts Already Unlocked!");
        }
    }
}
