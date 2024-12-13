using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievmentUINotification : MonoBehaviour
{
    private static AchievmentUINotification notification;

    public GameObject notificationUI;


    public void Awake()
    {
        if (notification == null) 
        {
            notification = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        RegisterToEvents();
    }

    void RegisterToEvents()
    {
        EventManager.OnShowNotification += EventManager_OnShowNotification;
    }

    private void EventManager_OnShowNotification(string achievementName)
    {
        StopCoroutine(TurnOf());
        notificationUI.SetActive(true);
        notificationUI.GetComponentInChildren<TextMeshProUGUI>().text = $"New Achievement Unlocked '{achievementName}' .";
        StartCoroutine(TurnOf());
    }

    IEnumerator TurnOf()
    {
        yield return new WaitForSeconds(3);
        notificationUI.SetActive(false);
    }
}
