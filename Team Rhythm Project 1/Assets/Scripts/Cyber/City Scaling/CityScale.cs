using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScale : MonoBehaviour
{
    [SerializeField, Tooltip("Rate at which the Object Scales")]
    float scaleRate;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float deltaTime1 = Time.fixedDeltaTime;
        transform.localScale += new Vector3((deltaTime1 * scaleRate), (deltaTime1 * scaleRate), (deltaTime1 * scaleRate)); // scales evenly
    }
}
