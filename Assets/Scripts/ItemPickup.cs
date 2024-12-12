using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    public TMP_Text pickupText;  // Reference to the "Press to Pickup" text object
    public string itemName;  // Name for this specific item
    //public string itemInfo;

    public ItemInfoTextDisplay infoTextDisplay;

    public AudioSource pickupSound;

    private void Start()
    {
        // Find the Text component in the child named "PickupText"
        pickupText = GetComponentInChildren<TMP_Text>(true);  // 'true' to find inactive children
        //infoTextDisplay = FindObjectOfType<ItemInfoTextDisplay>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in range of item: " + itemName);
            pickupText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player out of range of item: " + itemName);
            pickupText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (pickupText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    public void PickUp()
    {

        Debug.Log($"Picked up {itemName}");

        // Play the pickup sound if it's assigned
        if (pickupSound != null)
        {
            pickupSound.Play();
        }
        else
        {
            Debug.LogWarning("Pickup sound is not assigned.");
        }

        // Instantiate item info text at the item's position
        GameObject itemInfoText = Instantiate(infoTextDisplay.itemInfoTextPrefab, transform.position, Quaternion.identity);
        TMP_Text textComponent = itemInfoText.GetComponent<TMP_Text>();
        textComponent.text = $"{itemName} picked up!";
        itemInfoText.SetActive(true);

        
        StartCoroutine(HideAfterDelay(itemInfoText, 2.0f));

        Destroy(gameObject, pickupSound.clip.length);
    }

    private IEnumerator HideAfterDelay(GameObject textObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(textObject);  // Destroy the floating text after showing it
    }
}
