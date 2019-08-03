using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTracking : MonoBehaviour
{
    // This script tracks the amount of collectables collected by 
    // the player and executes behaviour based on the amount.
    

    // Total collectables picked up by the player
    public int totalCollected;

    // How many collectables are needed to increment the audio pitch
    public int collectablesPerIncrement;

    // The audio pitch will not increment further after the collectable max
    public int collectableMax;

    // Pitch increment value
    public float pitchIncrement;

    // The music track
    public AudioSource musicSource;

    // Stores a reference to the terrain manager.
    private GameObject theTerrainManager;
    private TerrainManager terrainManagerScript;

    // The how much to increase the terrain movement speed
    public float terrainSpeedIncrease;

    // Boat speed up audio source
    public AudioSource boatSpeedUpAudio;

    // VO source. Plays the VO clip when the track speeds up
    public AudioSource VOSource;

    // The particle that plays on speed up
    public ParticleSystem speedUpParticle;    

    bool pitchIncreaseCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();
        VOSource = GameObject.FindGameObjectWithTag("CollectableVOEffects").GetComponent<AudioSource>();
        boatSpeedUpAudio = GameObject.FindGameObjectWithTag("BoatSpeedUpAudio").GetComponent<AudioSource>();
        speedUpParticle = GameObject.FindGameObjectWithTag("SpeedUpParticle").GetComponent<ParticleSystem>();
        terrainManagerScript = GameObject.FindGameObjectWithTag("TerrainSpawner").GetComponent<TerrainManager>();

        totalCollected = 0;
        // pitchIncreaseCheck = false;
    }
    
    // Increases the pitch based on how many collectables have been collected
    public void IncreasePitch()
    {
        if (pitchIncreaseCheck == false)
        {
            if (totalCollected % collectablesPerIncrement == 0 && totalCollected > 0 && totalCollected < collectableMax)
            {
                // Debug.Log("multiple of the collectables increment");

                pitchIncreaseCheck = true;

                if (pitchIncreaseCheck == true)
                {
                    // This is where all the major feedback for player progress is called. Every time the player
                    // collects enough collectables the music speeds up, movement speeds up, a voice over is played, the boat makes a boost sound
                    // and a speed up particle effect is played.

                    // Debug.Log("increase pitch");

                    // Increment the pitch
                    musicSource.pitch += pitchIncrement;

                    // Speeds up terrain movement
                    terrainManagerScript.terrainSpeed = terrainManagerScript.terrainSpeed + terrainSpeedIncrease;

                    // Play a random voice over pitch to indicate the pitch has sped up
                    VOSource.GetComponent<CollectableVOEffects>().PlayCollectableVOEffect();
                    
                    // Play the speed up particle
                    speedUpParticle.GetComponent<ParticleSystem>().Play();
                    
                    // Play the boat boost speed
                    boatSpeedUpAudio.GetComponent<AudioSource>().Play();

                    pitchIncreaseCheck = false;
                }

            }
        }
    }    
}
