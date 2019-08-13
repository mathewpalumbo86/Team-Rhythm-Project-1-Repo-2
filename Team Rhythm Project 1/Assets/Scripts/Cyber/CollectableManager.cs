using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    // Stores the selected collectable prefab
    public GameObject thisCollectablePrefab;

    // How fast the collectable moves towards the player. Accessed by CollectableMovementBehaviour.cs
    public float collectableSpeed;

    // Collectable rotation speed range Accessed by CollectableMovementBehaviour.cs
    public float randRotMin;
    public float randRotMax;       

    // Start is called before the first frame update
    void Start()
    {
        // NOTE: This scripts execution order must be later than the object pooler. The object pooler needs time to build the pool before it is accessed.

        // Selects the collectable prefab to use (by it's tag) and grabs it from the pool
        if (thisCollectablePrefab.tag == "Collectable_1")
        {
            thisCollectablePrefab = ObjectPooler.SharedInstance.GetPooledObject("Collectable_1");
        }
        else if (thisCollectablePrefab.tag == "Collectable_2")
        {
            thisCollectablePrefab = ObjectPooler.SharedInstance.GetPooledObject("Collectable_2");
        }
        else if (thisCollectablePrefab.tag == "Collectable_3")
        {
            thisCollectablePrefab = ObjectPooler.SharedInstance.GetPooledObject("Collectable_3");
        }

        // Places the very first collectable object. The object moves to an object activator which triggers the rest.
        if (thisCollectablePrefab != null)
        {            
            thisCollectablePrefab.transform.position = transform.position;
            thisCollectablePrefab.transform.rotation = transform.rotation;
            
            thisCollectablePrefab.SetActive(true);            
        }
    }
}
