using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public AudioClip clickSound;

    public void SceneLoader(string SceneName)
    {
        AudioSource source = FindObjectOfType<AudioSource>();
        source.PlayOneShot(clickSound);

        SceneManager.LoadScene(SceneName);

        AudioSource audioSource = FindAnyObjectByType<AudioSource>();
        DontDestroyOnLoad(audioSource);
    }
}
