using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovementBehaviour : MonoBehaviour
{

    // Movement speed of this terrain instance.
    // public float terrainMovementSpeed;

    // Stores a reference to the terrain manager.
    private GameObject theTerrainManager;
    private TerrainManager terrainManagerScript;

    // Called when terrain instantiates.
    void OnEnable()
    {

        // Find the terrain spawner with tag.
        theTerrainManager = GameObject.FindGameObjectWithTag("LevelPieceSpawner");

        // Access the terrain manager script on the spawner and set the speed.
        // terrainMovementSpeed = theTerrainManager.gameObject.GetComponent<TerrainManager>().terrainSpeed;

        //
        if (theTerrainManager != null)
        {
            terrainManagerScript = theTerrainManager.gameObject.GetComponent<TerrainManager>();
        }
        
        // Debug.Log("FIXED DELTA TIME " + Time.fixedDeltaTime);

        // Debug.Log("terrain movement speed " + terrainMovementSpeed);
    }

    // FixedUpdate is used for physics updates
    void FixedUpdate()
    {
        // Access the terrain manager script on the spawner and set the speed.
        // terrainMovementSpeed = terrainManagerScript.terrainSpeed;

        // Move this instance of terrain.
        // transform.Translate(Vector3.back * Time.fixedDeltaTime * terrainMovementSpeed);

    }

}
