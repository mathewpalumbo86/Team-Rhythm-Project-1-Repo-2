using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovementBehaviour : MonoBehaviour
{
    // Similar to terrain movement behaviour

    /// Movement speed of this collectable instance.
    public float collectableMovementSpeed;

    // Stores a reference to the collectable manager.
    public GameObject collectableManager;

    public CollectableManager collectableManagerScript;
    
    // Set rotation speed
    public float rotSpeed;

    // Scaling values    
    public float setScale;    

    void Start()
    {
        
    }

    void OnEnable()
    {
        if (gameObject.GetComponent<MeshRenderer>().enabled == false)
        {
            // Turn the collectable renderer on
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        // Find the collectable spawner with tag.
        if (gameObject.tag == "Collectable_1")
        {
            // Debug.Log("collectable 1");

            collectableManager = GameObject.FindGameObjectWithTag("CollectableSpawner_1");
        }

        if (gameObject.tag == "Collectable_2")
        {
            // Debug.Log("collectable 2");

            collectableManager = GameObject.FindGameObjectWithTag("CollectableSpawner_2");
        }

        if (gameObject.tag == "Collectable_3")
        {
            // Debug.Log("collectable 3");

            collectableManager = GameObject.FindGameObjectWithTag("CollectableSpawner_3");
        }

        // Access the collectable manager script on the spawner and set the speed.
        collectableMovementSpeed = collectableManager.gameObject.GetComponent<CollectableManager>().collectableSpeed;

        //
        if(collectableManager != null)
        {
            collectableManagerScript = collectableManager.gameObject.GetComponent<CollectableManager>();
        }

    }

    // FixedUpdate is used for physics updates
    void FixedUpdate()
    {
        // Move this instance of collectable. (Must use space.world because of the rotation)
        transform.Translate(Vector3.back * Time.fixedDeltaTime * collectableManagerScript.collectableSpeed, Space.World);

        // Rotates this collectable randomly
        transform.Rotate(rotSpeed, rotSpeed, rotSpeed);
        
        // 
        // transform.localScale = new Vector3(setScale,setScale,setScale);
    }
}
