using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableOnCollision : MonoBehaviour
{
    // Collectable audio effects script
    //public GameObject collectableAudioEffectsObj;
    CollectableAudioEffects collectableAudioScript;
    CountColour myColour;
    // public CollectableAudioEffects collectableAudioEffectsScript;
    public ParticleSystem collectableParticle;
    // Collectable tracking script
    public CollectableTracking collectableTracking;
    
    // Stores this collectables position on collision so the audio can be played at that position
    public Transform thisCollectablesPosition;    

    // Start is called before the first frame update
    void Start()
    {
        // get the collectable audio effects object
        // collectableAudioEffectsObj = GameObject.FindGameObjectWithTag("CollectableEffect_1");
        collectableAudioScript = FindObjectOfType<CollectableAudioEffects>();

        // get the particle that plays when collected
        collectableParticle = GetComponent<ParticleSystem>();

        // get the collectable tracking script
        collectableTracking = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CollectableTracking>();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("collectable collided");

            // Store the position that the collision occurred
            // collectableAudioEffectsObj.GetComponent<CollectableAudioEffects>().collisionPosition = gameObject.transform;

            if(gameObject.GetComponent<MeshRenderer>().enabled == true)
            {
                // Turn the collectable renderer off
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }            

            // Sets the index for the collectable audio effect array based on which collectable this is
            if (gameObject.tag == "Collectable_1")
            {
                myColour = CountColour.Yellow;
                collectableAudioScript.index = 0;
                collectableTracking.SetCubeActive(myColour);
                collectableTracking.DoCount();
                
                

            }

            if (gameObject.tag == "Collectable_2")
            {
                myColour = CountColour.Pink;
                collectableAudioScript.index = 1;
                collectableTracking.SetCubeActive(myColour);
                collectableTracking.DoCount();
            }

            if (gameObject.tag == "Collectable_3")
            {
                myColour = CountColour.Blue;
                collectableAudioScript.index = 2;
                collectableTracking.SetCubeActive(myColour);
                collectableTracking.DoCount();
            }

            // if the player hits this object play a collectable sound effect and set it to inactive
            collectableAudioScript.PlayCollectableEffect();

            // For every collectable the player collides with increment this value +1;
            collectableTracking.totalCollected++;
            // For every collectable check if the audio pitch can be increased
            collectableTracking.IncreasePitch();

            // If a particle exists play it
            if(collectableParticle != null)
            {
                collectableParticle.Play();
            }
            else
            {
                Debug.Log("no particle attached");
            }                
            // StartCoroutine(Delay());
            // this.gameObject.SetActive(false);
        }
    }

    //IEnumerator Delay()
    //{
    //    // print(Time.time);
    //    yield return new WaitForSeconds(0.0f);
    //    // print(Time.time);
    //}

}
