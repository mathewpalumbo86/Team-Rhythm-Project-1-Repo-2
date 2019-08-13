using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillUITimer : MonoBehaviour
{
    [SerializeField,Tooltip("Lifetime of Object in Seconds\n"+"Timer Starts in Start Function")]
    float lifeTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime); // on start wait 10 seconds then Destroy UI
    }

    
}
