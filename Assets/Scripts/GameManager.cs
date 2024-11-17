using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private EnemyData currentEnemy;

    // public string enemyDetails;  // To store the enemy details

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keeps the GameManager alive between scenes
        }
        else
        {
            Destroy(gameObject);  // Ensure there's only one instance
        }
    }



    // Function to set the enemy details
    public void SetEnemyData(EnemyData enemy)
    {
        currentEnemy = enemy;
    }

    public EnemyData GetCurrentEnemy()
    {
        return currentEnemy;
    }
}
