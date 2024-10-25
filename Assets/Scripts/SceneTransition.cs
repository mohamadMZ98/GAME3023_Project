using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transition;
   // public CanvasGroup fadeCanvasGroup;  // Reference to the CanvasGroup of the full-screen Image
    public float fadeDuration = 1.0f;    // Duration for fade effect


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int level)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(fadeDuration);

        SceneManager.LoadScene("BattleScene");
    }
}
