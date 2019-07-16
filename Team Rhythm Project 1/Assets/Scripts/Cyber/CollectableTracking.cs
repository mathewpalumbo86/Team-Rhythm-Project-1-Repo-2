using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTracking : MonoBehaviour
{
    // Total collectables picked up by the player
    public int totalCollected;

    // How many collectables are needed to increment the audio pitch
    public int collectablesPerIncrement;

    // The audio pitch will not increment further after the collectable max
    public int collectableMax;

    // The music track
    public AudioSource musicSource;

    bool pitchIncreaseCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();

        totalCollected = 0;
        // pitchIncreaseCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increases the pitch based on how many collectables have been collected
    public void IncreasePitch()
    {
        if (pitchIncreaseCheck == false)
        {
            if (totalCollected % collectablesPerIncrement == 0 && totalCollected > 0 && totalCollected < collectableMax)
            {
                Debug.Log("multiple of 5");

                pitchIncreaseCheck = true;

                if (pitchIncreaseCheck == true)
                {

                    Debug.Log("increase pitch");

                    musicSource.pitch += 0.01f;

                    pitchIncreaseCheck = false;
                }

            }
        }
    }

}
