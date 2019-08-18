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
        
    }

    // Plays a random clip from an array
    public void PlayCollectableEffect()
    {
        // this is to remove a console error
        if(gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
        }
        StartCoroutine(WaitForAudioToFinish());
    }

    IEnumerator WaitForAudioToFinish()
    {
        // Plays the collectable audio clip based on which type was collided with 
        collisionClip = collisionSounds[index];

        // AudioSource.PlayClipAtPoint(collisionClip, collisionPosition.position);
        audioSource.PlayOneShot(collisionClip);

        yield return new WaitForSeconds(collisionClip.length + 2f);

        gameObject.SetActive(false);

    }

}
