using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUIItem : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI shortDescription;
    public TextMeshProUGUI achievementName;
    public Image statusImage;
    private AchievementSO achievement;



    public void InitAchievementUI(AchievementSO achievementSO)
    {
        this.achievement = achievementSO;
    }

    public void UpdatAchievement()
    {
        icon.sprite = achievement.achievementSprite;
        shortDescription.text = achievement.shortDescription;
        achievementName.text = achievement.achievemntName;
        statusImage.enabled = EventManager.DoFireIsAchievementUnlocked(achievement);
    }
}
