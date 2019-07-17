using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovementBehaviour : MonoBehaviour
{

    // Similar to terrain movement behaviour

    /// Movement speed of this collectable instance.
    public float collectableMovementSpeed;

    // Stores a reference to the collectable manager.
    private GameObject collectableManager;     

    // Set rotation speed
    public float rotSpeed;

    // Scaling values    
    public float setScale;    

    void Start()
    {
                        
    }

    void OnEnable()
    {
        // Find the collectable spawner with tag.
        collectableManager = GameObject.FindGameObjectWithTag("CollectableSpawner");

        // Access the terrain manager script on the spawner and set the speed.
        collectableMovementSpeed = collectableManager.gameObject.GetComponent<CollectableManager>().collectableSpeed;
    }

    // FixedUpdate is used for physics updates
    void FixedUpdate()
    {
        // Move this instance of collectable. (Must use space.world because of the rotation)
        transform.Translate(Vector3.back * Time.deltaTime * collectableMovementSpeed, Space.World);

        // Rotates this collectable randomly
        transform.Rotate(rotSpeed, rotSpeed, rotSpeed);
        
        transform.localScale = new Vector3(setScale,setScale,setScale);
    }
}
