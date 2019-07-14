﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeactivater : MonoBehaviour
{

    
    // Used to set the tag of the type of object to be turned off.
    // public string objectTag;


    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("trigger entered");
                
        other.gameObject.SetActive(false);
    }

    
}
