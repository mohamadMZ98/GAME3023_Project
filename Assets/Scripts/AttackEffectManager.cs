using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum AttackType
{
    Lightning,
    Light,
    Heavy
}
public class AttackEffectManager : MonoBehaviour
{
   // public AudioSource lightningAudio;
    public GameObject attackEffectPrefab; // Assign the prefab in the inspector
    public GameObject shieldPrefab;
    public Transform attackEffectSpawnPoint;    // Where the effect appears (e.g., near the enemy)
    public Transform shieldEffectSpawnPoint;

    public float manaCost = 5f;
    private Dictionary<AttackType, float> attackDamageValues;

    public Slider enemyHealthBar;
    private float enemyMaxHealth = 100f;
    private float enemyCurrentHealth;

    private float lightningAttackDamage = 25f;


    //private void Awake()
    //{

    //    attackDamageValues = new Dictionary<AttackType, float>
    //    {
    //        { AttackType.Lightning, 20f },
    //        { AttackType.Heavy, 30f },
    //        { AttackType.Light, 10 }
    //    };
    //}
    void Start()
    {
        // Ensure the AudioSource is attached or get it dynamically
        //if (lightningAudio == null)
        //{
        //    lightningAudio = GetComponent<AudioSource>();
        //}
        // Initialize enemy health
        enemyCurrentHealth = enemyMaxHealth;

        // Set the health bar's maximum and current value
        if (enemyHealthBar != null)
        {
            enemyHealthBar.maxValue = enemyMaxHealth;
            enemyHealthBar.value = enemyCurrentHealth;
        }
    }

    public void ActivateShield() // Called by the UI button
    {
        // Instantiate the shield at the player's position
        GameObject shieldInstance = Instantiate(shieldPrefab, shieldEffectSpawnPoint.position, Quaternion.identity);

        // Start the coroutine to handle spinning and disappearance
        StartCoroutine(HandleShield(shieldInstance));
    }

    private IEnumerator HandleShield(GameObject shield)
    {
        float duration = 3f;  // Shield active duration
        float rotationSpeed = 100f;  // Speed of the spin

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            // Spin the shield
            shield.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
        }

        // Destroy the shield after the duration
        Destroy(shield);
    }

    public void PlayAttackEffect()
    {
        // Instantiate the effect at the desired position and rotation
        GameObject effect = Instantiate(attackEffectPrefab, attackEffectSpawnPoint.position, Quaternion.identity);
        //lightningAudio.Play();
        Destroy(effect, 2f);

        ApplyDamage(lightningAttackDamage);

    }


    private void ApplyDamage(float damage)
    {
        // Reduce the enemy's health
        enemyCurrentHealth -= damage;

        // Clamp the health to ensure it doesn't go below 0
        enemyCurrentHealth = Mathf.Clamp(enemyCurrentHealth, 0, enemyMaxHealth);

        // Update the health bar UI
        if (enemyHealthBar != null)
        {
            enemyHealthBar.value = enemyCurrentHealth;
        }

        // Check if the enemy is defeated
        if (enemyCurrentHealth <= 0)
        {
            Debug.Log("Enemy defeated!");
            // Add additional logic here for what happens when the enemy is defeated
        }
    }
}
