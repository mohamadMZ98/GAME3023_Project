using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FleeButtonBehaviour : MonoBehaviour
{
    public void Flee()
    {
        SceneManager.LoadScene("GameScene");
    }
}
