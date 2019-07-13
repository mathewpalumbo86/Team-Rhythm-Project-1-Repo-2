using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    // How fast the collectable moves towards the player. Accessed by CollectableMovementBehaviour.cs
    public float collectableSpeed;

    // Collectable rotation speed range Accessed by CollectableMovementBehaviour.cs
    public float randRotMin;
    public float randRotMax;       

    // Start is called before the first frame update
    void Start()
    {
        // NOTE: This scripts execution order must be later than the object pooler. The object pooler needs time to build the pool before it is accessed.

        // Places the very first terrain object. The object moves to an object activator which triggers the rest.
        GameObject thisCollectablePrefab = ObjectPooler.SharedInstance.GetPooledObject("Collectable");
        if (thisCollectablePrefab != null)
        {            
            thisCollectablePrefab.transform.position = transform.position;
            thisCollectablePrefab.transform.rotation= transform.rotation;
            
            thisCollectablePrefab.SetActive(true);


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
