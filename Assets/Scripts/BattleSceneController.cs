using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleSceneController : MonoBehaviour
{
    //public EnemyInfoDisplay enemyInfoDisplay;  // Reference to the EnemyInfoDisplay script
                                               //public Animator enemyAnimator;  // Reference to the enemy's Animator

    public Image enemyImage;
    public TMP_Text enemyInfoText;
    public float typingSpeed = 0.05f;

    void Start()
    {
        EnemyData currentEnemy = GameManager.instance.GetCurrentEnemy();
        if (currentEnemy != null)
        {
            // Display Enemy Image, info
            if(enemyImage!=null)
                enemyImage.sprite = currentEnemy.enemySprite;
            // enemyNameText.text = currentEnemy.enemyName;
            //enemyStatsText.text = $"Health: {currentEnemy.health}\nAttack: {currentEnemy.attackPower}";
            string fullText = $"Enemy: {currentEnemy.enemyName}\nHealth: {currentEnemy.health}\nAttack: {currentEnemy.attackPower}";

            StartCoroutine(TypeText(fullText));
        }
    }

    private IEnumerator TypeText(string fullText)
    {
        enemyInfoText.text = "";  // Clear the text initially

        foreach (char letter in fullText)
        {
            enemyInfoText.text += letter;  // Add one character at a time
            yield return new WaitForSeconds(typingSpeed);  // Wait for the typing speed
        }
    }
}
