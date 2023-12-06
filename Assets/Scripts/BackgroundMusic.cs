using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    private AudioSource audioSource;  
    private bool isMusicPlaying = true; 

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;

        PlayBackgroundMusic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleBackgroundMusic();
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 80, 10, 60, 40), isMusicPlaying ? "Mute" : "Unmute"))
        {
            ToggleBackgroundMusic();
        }
    }

    void PlayBackgroundMusic()
    {
        audioSource.Play();
    }

    void StopBackgroundMusic()
    {
        audioSource.Stop();
    }

    void ToggleBackgroundMusic()
    {
        isMusicPlaying = !isMusicPlaying;

        if (isMusicPlaying)
        {
            PlayBackgroundMusic();
        }
        else
        {
            StopBackgroundMusic();
        }
    }
}
