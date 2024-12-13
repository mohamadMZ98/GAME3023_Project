using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsSaver : MonoBehaviour
{

    [SerializeField]private Transform player;

    [SerializeField]KeyCode keycode;

    private void Start()
    {
        SaveController.LoadPlayerPosition(player);
    }

    private void Update()
    {
        if(Input.GetKeyDown(keycode))
        {
            SaveController.SavePlayePosition(player);
        }
    }


   

   


}
