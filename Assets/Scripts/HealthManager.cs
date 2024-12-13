using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class HealthManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private HealthSystem healthSystem;

    // Start is called before the first frame update
   private void Awake()
    {
        healthSystem = new HealthSystem(100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
