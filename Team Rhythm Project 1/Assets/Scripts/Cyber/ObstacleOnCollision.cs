using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOnCollision : MonoBehaviour
{
    // This scripts controls what happens to an obstacle when it collides with the player
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

}
