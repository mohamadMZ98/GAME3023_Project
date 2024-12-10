using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip buttonSound;

    //public void Start()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //}

    public void PlayButtonSound(AudioClip clip)
    {
        if (audioSource != null && buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not assigned!");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsScene");
    }


    public void Exit()
    {
        Application.Quit();
    }
}
