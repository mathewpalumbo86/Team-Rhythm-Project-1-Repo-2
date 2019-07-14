﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementBehaviour : MonoBehaviour
{
    // Similar to terrain movement behaviour

    /// Movement speed of this collectable instance.
    public float obstacleMovementSpeed;

    // Stores a reference to the obstacle manager.
    private GameObject obstacleManager;
            
    void OnEnable()
    {
        // Find the collectable spawner with tag.
        obstacleManager = GameObject.FindGameObjectWithTag("ObstacleSpawner");

        // Access the terrain manager script on the spawner and set the speed.
        obstacleMovementSpeed = obstacleManager.gameObject.GetComponent<ObstacleManager>().obstacleSpeed;
    }

    // FixedUpdate is used for physics updates
    void FixedUpdate()
    {
        // Move this instance of obstacle. (Must use space.world because of the rotation)
        transform.Translate(Vector3.back * Time.deltaTime * obstacleMovementSpeed, Space.World);       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}