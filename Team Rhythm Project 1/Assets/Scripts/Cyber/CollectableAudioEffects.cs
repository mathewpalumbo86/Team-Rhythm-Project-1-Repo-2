using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAudioEffects : MonoBehaviour
{

    private AudioSource audioSource;    // The source of the collectable audio
    public AudioClip[] collisionSounds; // The collectables audio array
    private AudioClip collisionClip;    // The selected audio clip to play

    public Transform collisionPosition; // Where the audio clip should play (at the collision position (for spatial audio)). Accessed from the CollectableObCollision script
    public int index = 0;               // Needs to be accessible from the CollectableOnCollision script

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    int index = Random.Range(0, shoot.Length);
        //    shootClip = shoot[index];
        //    audioSource.clip = shootClip;
        //    audioSource.Play();
        //}
    }

    // Plays a random clip from an array
    public void PlayCollectableEffect()
    {
        Debug.Log("play the sound");

        // int index = Random.Range(0, collisionSounds.Length);
        // Plays the collectable audio clip based on which type was collided with 
        collisionClip = collisionSounds[index];
        audioSource.clip = collisionClip;
        // audioSource.PlayOneShot(collisionClip);

        AudioSource.PlayClipAtPoint(collisionClip, collisionPosition.position);
    }

   
}
