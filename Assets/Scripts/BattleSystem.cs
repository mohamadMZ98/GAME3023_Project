using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.SceneManagement;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        //SetupBattle();
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
       GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
       GameObject enemyGO =  Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();


    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        enemyUnit.TakeDamage(playerUnit.damage);

        yield return new WaitForSeconds(2f);
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy is Attacking");
        yield return new WaitForSeconds(2f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }


    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            SceneManager.LoadScene("GameScene");
        }
        else if(state == BattleState.LOST)
        {
            Debug.Log("You Lost :(");
            SceneManager.LoadScene("GameScene");
        }
    }

    void PlayerTurn()
    {
        //DialogText.text = "CHoose An Action";
    }

    public void AttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;

            StartCoroutine(PlayerAttack());
        }


    }



}
