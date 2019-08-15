using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NaughtyAttributes;
public class EndGameManager : MonoBehaviour
{
    [Required("Needs audio source for Fireworks.wav")]
    [SerializeField]
    AudioSource fireworkSound;

    [Required("Need End of Game Voice Clip")]
    [SerializeField]
    AudioSource voiceEoG;

    [Required("Need Reference to the Background Music Audio Source")]
    [SerializeField]
    AudioSource backgroundMusic;

    [Required("Need The End Game Text and Fireworks")]
    [SerializeField]
    GameObject effectEoG;

    [ReadOnly, TextArea(3,5), SerializeField]
    string scriptUsage = "To Use This Script Properly\n" + "Just Activate The attached object\n" + "after City Explodes";

    // Spawners to be turned off
    [SerializeField]
    GameObject objectActivator;

    void Start()
    {
        // objectActivator = GameObject.FindGameObjectWithTag("ObjectActivator");        
    }

    private void OnEnable()
    {
        TurnOnEndSceneOBJs(); // turns on EoG UI and Fireworks Particles
        StopBGMusic();// stops background music
        PlayAudio(); // plays EoG VO and Fireworks sound
        TurnOffSpawners(); // Turns off all the spawners
    }

    void TurnOnEndSceneOBJs()
    {
        if (effectEoG == null)
        {
            return;
        }
        else
        {
            if (effectEoG.activeInHierarchy == false)
            {
                effectEoG.SetActive(true); // enable game object
            }
        }
        
    }

    void PlayAudio()
    {
        fireworkSound.Play(); // plays continuously (loops)
        voiceEoG.PlayOneShot(voiceEoG.clip); // plays once, use mixer to configure sound
    }

    void StopBGMusic()
    {
        if(backgroundMusic.isPlaying == true)
        {
            backgroundMusic.Stop();
        }
    }

    void TurnOffSpawners()
    {
        objectActivator.SetActive(false);        
    }
}
