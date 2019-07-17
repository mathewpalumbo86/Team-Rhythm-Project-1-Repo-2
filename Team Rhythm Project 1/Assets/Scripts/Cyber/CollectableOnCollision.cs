using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableOnCollision : MonoBehaviour
{
    // Collectable audio effects script
    public GameObject collectableAudioEffectsObj;
    // public CollectableAudioEffects collectableAudioEffectsScript;
    public ParticleSystem collectableParticle;
    // Collectable tracking script
    public CollectableTracking collectableTracking;
    
    // Start is called before the first frame update
    void Start()
    {        
        // get the collectable audio effects object
        collectableAudioEffectsObj = GameObject.FindGameObjectWithTag("CollectableEffect_1");
        
        // get the particle that plays when collected
        collectableParticle = GetComponent<ParticleSystem>();

        // get the collectable tracking script
        collectableTracking = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CollectableTracking>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("collectable collided");

            // if the player hits this object play a collectable sound effect and set it to inactive
            collectableAudioEffectsObj.GetComponent<CollectableAudioEffects>().PlayCollectableEffect();

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
