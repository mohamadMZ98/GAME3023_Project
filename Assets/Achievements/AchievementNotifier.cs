using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementNotifier : MonoBehaviour
{
    private AchievementSO achievement;

    public void Init(AchievementSO achievement)
    {
        this.achievement = achievement; 
    }

    public void Unlock()
    {
        if (achievement != null)
        {
            EventManager.DoFireAchievementUnlock(achievement);
        }
    }

}
