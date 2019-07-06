using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScale : MonoBehaviour
{
    [SerializeField, Tooltip("Rate at which the Object Scales")]
    float scaleRate;


    
    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0f, (Time.deltaTime * scaleRate), (Time.deltaTime * scaleRate)); // scales evenly
    }
}
