using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EnemyInfoDisplay : MonoBehaviour
{
    public TextMeshProUGUI enemyInfoText;  // Reference to the UI Text component
    public float typingSpeed = 0.05f;  // Time delay between each character

    private Coroutine typingCoroutine;

    // Call this method to start the typewriter effect with the desired text
    public void DisplayEnemyInfo(string enemyInfo)
    {
        Debug.Log("Displaying enemy info: " + enemyInfo);  // Add this line to verify if the function runs

        // Stop any existing typing coroutine to prevent overlap
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start the coroutine to display the text
        typingCoroutine = StartCoroutine(TypeText(enemyInfo));
    }

    // Coroutine that types out the text one character at a time
    private IEnumerator TypeText(string textToDisplay)
    {
        enemyInfoText.text = "";  // Clear the text initially

        foreach (char letter in textToDisplay.ToCharArray())
        {
            enemyInfoText.text += letter;  // Add each letter one by one
            yield return new WaitForSeconds(typingSpeed);  // Wait before adding the next character
        }
    }
}
