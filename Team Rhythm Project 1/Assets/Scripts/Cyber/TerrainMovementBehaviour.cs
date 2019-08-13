using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovementBehaviour : MonoBehaviour
{

    // Movement speed of this terrain instance.
    public float terrainMovementSpeed;

    // Stores a reference to the terrain manager.
    private GameObject theTerrainManager;
    private TerrainManager terrainManagerScript;

    // Called when terrain instantiates.
    void OnEnable()
    {

        // Find the terrain spawner with tag.
        theTerrainManager = GameObject.FindGameObjectWithTag("TerrainSpawner");

        // Access the terrain manager script on the spawner and set the speed.
        terrainMovementSpeed = theTerrainManager.gameObject.GetComponent<TerrainManager>().terrainSpeed;

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
        terrainMovementSpeed = terrainManagerScript.terrainSpeed;

        // Move this instance of terrain.
        transform.Translate(Vector3.back * Time.fixedDeltaTime * terrainMovementSpeed);

        // Terrain offset calculation but use UpdateOffset(offset, terrainManagerScript.terrainSpeed) where you usually 
        // add the offset to the z position value (it will return a float). Also use this on enable as well to ensure that 
        // the speed is set correctly on spawn. e.g. Vector 3(~, ~, position.z + UpdateOffset(offset, terrainManagerScript.terrainSpeed))
        // UpdateOffset(offset, terrainManagerScript.terrainSpeed);
    }

    // float UpdateOffset(float currentOffset, float currentSpeed)
    // {
    // divides the current offset by the current speed then deducts that amount from the current 
    // offset (faster speed smaller offset?) try adding if it fails
    // float updatedOffset = currentOffset - (currentOffset / currentSpeed); 
    // return updatedOffset;
    // }

}
