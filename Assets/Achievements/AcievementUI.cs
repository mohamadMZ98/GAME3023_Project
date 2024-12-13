using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcievementUI : MonoBehaviour
{
    [SerializeField]private AchievementDataSO AchievementDataSO;

    [SerializeField]private AchievementUIItem achievementPrefab;

    [SerializeField] private Transform rect;

    private List<AchievementUIItem> allUIITems = new List<AchievementUIItem>();

    public Button closeButton;

    public void Start()
    {
        for (int i = 0; i < AchievementDataSO.allAchievemets.Count; i++) 
        {
            var achievementUI = Instantiate(achievementPrefab, rect);

            allUIITems.Add(achievementUI);

            achievementUI.InitAchievementUI(AchievementDataSO.allAchievemets[i]);

            achievementUI.UpdatAchievement();
        }

        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }



}
