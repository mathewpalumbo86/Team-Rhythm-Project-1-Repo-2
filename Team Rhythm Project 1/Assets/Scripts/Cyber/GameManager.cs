using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public AudioSource bgMusicSource;
    public float bgMusicLength;
    public float bgMusicPos;
    public float percentageMusicComplete;
    public float timeCheck;
    public float endLevelThreshhold;
    public GameObject city;
    public ParticleSystem cityParticle;
    AudioSource bgMusicSource; // background music clip
    AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        explosionSound = GetComponent<AudioSource>(); // AS that is attached to GM
        bgMusicLength = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>().clip.length;
        bgMusicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();
        city = GameObject.FindGameObjectWithTag("City");
        cityParticle = city.GetComponent<ParticleSystem>();

        StartCoroutine(StartEffectTimer(bgMusicSource)); // starts coroutine
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //Runs at start and waits until the end to play the sound and effect
    IEnumerator StartEffectTimer(AudioSource bgrClip)
    {
        yield return new WaitUntil(() => !bgrClip.isPlaying); //waits until song finishes
        PlaySoundAndEffect();
    }

    IEnumerator StartExplosionSound(AudioSource explosionEffectClip)
    {
        explosionSound.PlayOneShot(explosionSound.clip);
        yield return new WaitUntil(() => !cityParticle.isPlaying);
        yield return new WaitUntil(() => !explosionEffectClip.isPlaying);
        DestroyCity();
    }

    //plays sound and effect
    void PlaySoundAndEffect()
    {
        //bgMusicPos = Time.time;
        //percentageMusicComplete = bgMusicPos / bgMusicLength * 100;

        // At the percentage threshhold the level ends
        //if (percentageMusicComplete >= endLevelThreshhold)
        //{
            // Debug.Log("level ends here");

            if (!cityParticle.isPlaying)
            {
                cityParticle.Play();

                StartCoroutine(StartExplosionSound(explosionSound));
            }
            

           //if (cityParticle.isPlaying)
           // {
              // return;
            //}
            //else
            //{
           //    city.SetActive(false);
           // }


        //}
    }



    void DestroyCity()
    {
        Destroy(GameObject.FindGameObjectWithTag("City"));
    }

}
