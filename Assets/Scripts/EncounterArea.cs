using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterArea : MonoBehaviour
{
    [Range(0f, 1f)]
    public float encounterChance = 0.5f;
    public string areaName = "area 1";


    public bool RollEncounter()
    {
        return Random.value <= encounterChance;
    }
}
