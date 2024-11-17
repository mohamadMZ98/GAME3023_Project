using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public class RandomEncounter : MonoBehaviour
{
    public EnemyDatabase enemyDatabase;
    Rigidbody2D body;
    public float distanceTravelledSinceLastEncounter = 0;

    [Range(0f, 100000f)]
    [SerializeField]
    public float minEncounterDistance = 2;
    //public EnemyInfoDisplay enemyInfoDisplay;  // Reference to the EnemyInfoDisplay script


    public string sceneName = "BattleScene";
    public SceneTransition sceneTransition;
    // TopDownCharacterController movement;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //StartBattle();

        if (collision != null)
        {
            EncounterArea encounterZone = collision.GetComponent<EncounterArea>();
            if (encounterZone != null)
            {
                if (body.velocity.magnitude > 0)
                {
                    distanceTravelledSinceLastEncounter += body.velocity.magnitude * Time.fixedDeltaTime;

                    if (distanceTravelledSinceLastEncounter > minEncounterDistance)
                    {
                        distanceTravelledSinceLastEncounter = 0;

                        if (encounterZone.RollEncounter())
                        {
                            EnemyData randomEnemy = ChooseRandomEnemy(encounterZone);
                            if (randomEnemy != null)
                            {
                                Debug.Log("ENCOUNTER!!" + encounterZone.areaName);
                                //string enemyDetails = "Enemy: Rascal \nHealth: 150\nAttack: 25";  // Example enemy details
                                GameManager.instance.SetEnemyData(randomEnemy);
                                sceneTransition.LoadNextLevel();
                            }
                        }

                    }
                }
            }
        }
    }

    public EnemyData ChooseRandomEnemy(EncounterArea encounterZone)
    {
        var possibleEnemies = encounterZone.possibleEnemies;
        if (possibleEnemies.Count == 0) return null;

        return possibleEnemies[Random.Range(0, possibleEnemies.Count)];
    }

    private void DisplayEnemy(EnemyData enemy)
    {
        GameManager.instance.SetEnemyData(enemy);
    }
    //void StartBattle()
    //{
    //    string enemyDetails = "Enemy: Dragon\nHealth: 150\nAttack: 25";
    //    enemyInfoDisplay.DisplayEnemyInfo(enemyDetails);
    //    // Additional logic to start the battle, such as setting up the battlefield
    //}
}
