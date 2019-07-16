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
        float deltaTime1 = Time.deltaTime;
        transform.localScale += new Vector3(0f, (deltaTime1 * scaleRate), (Time.deltaTime * scaleRate)); // scales evenly
    }
}
