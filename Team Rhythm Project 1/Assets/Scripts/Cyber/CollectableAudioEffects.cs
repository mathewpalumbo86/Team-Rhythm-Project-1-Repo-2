using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAudioEffects : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] hit;
    private AudioClip hitClip;

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
        int index = Random.Range(0, hit.Length);
        hitClip = hit[index];
        audioSource.clip = hitClip;
        audioSource.Play();
    }

   
}
