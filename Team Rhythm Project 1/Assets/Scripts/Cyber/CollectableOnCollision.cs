using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableOnCollision : MonoBehaviour
{
    // Collectable audio effects script
    public GameObject collectableAudioEffectsObj;
    // public CollectableAudioEffects collectableAudioEffectsScript;
    public ParticleSystem collectableParticle;


    // Start is called before the first frame update
    void Start()
    {
        
        // get the collectable audio effects object
        collectableAudioEffectsObj = GameObject.FindGameObjectWithTag("CollectableEffect_1");
        // get the collectable audio effects script
        // collectableAudioEffectsScript = GetComponent<CollectableAudioEffects>();

        collectableParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // if the player hits this object play a collectable sound effect and set it to inactive
            collectableAudioEffectsObj.GetComponent<CollectableAudioEffects>().PlayCollectableEffect();

            // Debug.Log("collectable collided");

            if(collectableParticle != null)
            {
                collectableParticle.Play();
            }
            else
            {
                Debug.Log("no particle attached");
            }    
            
            StartCoroutine(Delay());

            // this.gameObject.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.2f);
        print(Time.time);
    }

}
