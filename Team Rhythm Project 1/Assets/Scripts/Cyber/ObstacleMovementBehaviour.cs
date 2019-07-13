using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementBehaviour : MonoBehaviour
{
    // Similar to terrain movement behaviour

    /// Movement speed of this collectable instance.
    public float obstacleMovementSpeed;

    // Stores a reference to the obstacle manager.
    private GameObject obstacleManager;

    // Rotation speed for collectables
    // private float randRotSpeed;
    // private float thisRotMin;
    // private float thisRotMax;

    // Scaling values
    // public float scaleSpeed;


    void Start()
    {
        // Sets the rotation speed range for this object
        // thisRotMin = collectableManager.gameObject.GetComponent<CollectableManager>().randRotMin;
        // thisRotMax = collectableManager.gameObject.GetComponent<CollectableManager>().randRotMax;

        // Sets the rotation speed for this object
        // randRotSpeed = Random.Range(thisRotMin, thisRotMax);

    }


    //.
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

        // Rotates this collectable randomly
        // transform.Rotate(randRotSpeed, randRotSpeed, randRotSpeed);

        // Scales collectables up and down
        // transform.localScale = new Vector3(Mathf.PingPong(scaleSpeed * Time.time, 3) + 1f, Mathf.PingPong(scaleSpeed * Time.time, 3) + 1f, Mathf.PingPong(scaleSpeed * Time.time, 3) + 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
