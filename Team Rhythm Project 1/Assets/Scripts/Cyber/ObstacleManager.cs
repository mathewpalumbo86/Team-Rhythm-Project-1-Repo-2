using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    /// How fast the terrain moves towards the player. Accessed by ObstacleMovementBehaviour.cs
    public float obstacleSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
        // NOTE: This scripts execution order must be later than the object pooler. The object pooler needs time to build the pool before it is accessed.

        // Places the very first obstacle object. The object moves to an object activator which triggers the rest.
        GameObject thisCollectablePrefab = ObjectPooler.SharedInstance.GetPooledObject("Obstacle");
        if (thisCollectablePrefab != null)
        {
            thisCollectablePrefab.transform.position = transform.position;
            thisCollectablePrefab.transform.rotation = transform.rotation;

            thisCollectablePrefab.SetActive(true);
        }
    }
}
