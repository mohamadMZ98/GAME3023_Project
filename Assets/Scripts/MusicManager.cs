using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> audioClips; // Assign audio clips in the Inspector
    public List<string> sceneNames; // Corresponding scene names for the clips

    private AudioSource audioSource;
    private Dictionary<string, AudioClip> sceneAudioMap;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        // Initialize the dictionary
        sceneAudioMap = new Dictionary<string, AudioClip>();

        // Map scene names to audio clips
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (i < audioClips.Count)
            {
                sceneAudioMap[sceneNames[i]] = audioClips[i];
            }
        }

        // Get the current scene name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Play the corresponding audio clip
        if (sceneAudioMap.TryGetValue(currentSceneName, out AudioClip clip))
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"No audio clip assigned for the scene: {currentSceneName}");
        }
    }
}
