using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemInfoTextDisplay : MonoBehaviour
{
    public TMP_Text floatingTextPrefab;
    public GameObject itemInfoTextPrefab;

    public void ShowText(string message, Vector3 position, float duration)
    {
        TMP_Text floatingText = Instantiate(floatingTextPrefab, position, Quaternion.identity, transform);
        floatingText.text = message;
        floatingText.gameObject.SetActive(true);
        StartCoroutine(HideAfterDelay(floatingText, duration));
    }

    private IEnumerator HideAfterDelay(TMP_Text text, float delay)
    {
        yield return new WaitForSeconds(delay);
        //floatingText.gameObject.SetActive(false);
        Destroy(text.gameObject);
    }
}
