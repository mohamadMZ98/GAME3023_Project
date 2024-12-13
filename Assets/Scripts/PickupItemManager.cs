using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class PickupItemManager : MonoBehaviour
{
    [System.Serializable]
    public class PickupItem
    {
        public string itemName;
        public Sprite itemSprite;
        public AchievementSO achievement;
    }

    public PickupItem[] pickupItems;  // Array of items with names and sprites
    public GameObject pickupPrefab;  // Reference to a prefab for each pickup
    public TMP_Text pickupTextPrefab;  // Reference to a TMP text prefab for "Press to Pickup"
    public ItemInfoTextDisplay infoTextDisplay;
    public GameObject itemInfoDisplayPrefab;


    void Start()
    {
        if (infoTextDisplay == null)
        {
            Debug.LogError("Info Text Display reference is missing!");
            return;
        }
        SpawnItems();
    }

    public void SpawnItems()
    {
        foreach (PickupItem item in pickupItems)
        {
            GameObject newItem = Instantiate(pickupPrefab, GetRandomPosition(), Quaternion.identity);
            newItem.GetComponent<SpriteRenderer>().sprite = item.itemSprite;


            // Set up the text object for pickup
            TMP_Text pickupText = Instantiate(pickupTextPrefab, newItem.transform);
            pickupText.text = "Press E to Pickup";
            pickupText.gameObject.SetActive(false);  // Hide initially

            // Set up item name in the pickup script
            ItemPickup itemPickupScript = newItem.GetComponent<ItemPickup>();
            itemPickupScript.pickupText = pickupText;
            itemPickupScript.itemName = item.itemName;  // Assign name for potential use
            itemPickupScript.infoTextDisplay = infoTextDisplay;

            if(item.achievement != null)
            {
                newItem.GetComponent<AchievementNotifier>().Init(item.achievement);
            }
            
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Generate a random position within a certain range; adjust as needed
        return new Vector3(Random.Range(-13, 13), Random.Range(-13, 13), 0);
    }
}
