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

    // Start is called before the first frame update
    void Start()
    {
        bgMusicLength = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>().clip.length;
        city = GameObject.FindGameObjectWithTag("City");
        cityParticle = city.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        bgMusicPos = Time.time;
        percentageMusicComplete = bgMusicPos / bgMusicLength * 100;
        // At the percentage threshhold the level ends
        if (percentageMusicComplete >= endLevelThreshhold)
        {
            // Debug.Log("level ends here");

            if (!cityParticle.isPlaying)
            {
                cityParticle.Play();
            }

            if (cityParticle.isPlaying)
            {
                return;
            }
            else
            {
                city.SetActive(false);
            }
            

        }
    }
}
