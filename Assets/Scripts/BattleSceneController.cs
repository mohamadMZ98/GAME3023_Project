using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{
    public EnemyInfoDisplay enemyInfoDisplay;  // Reference to the EnemyInfoDisplay script
    //public Animator enemyAnimator;  // Reference to the enemy's Animator


    void Start()
    {
        string enemyDetails = GameManager.instance.enemyDetails;  // Retrieve the stored enemy details
        enemyInfoDisplay.DisplayEnemyInfo(enemyDetails);  // Display enemy info in the battle scene
        //enemyAnimator.SetBool("LightBandit_CombatIdle", true);
    }
}
