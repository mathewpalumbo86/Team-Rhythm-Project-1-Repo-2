using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{

    // public string objectTag; // Used to check the tag of the object to be turned on.

    //========================= Terrain varibles ==============================
    // public Transform terrainSpawnPosition; // Reference to the terrain spawn position.
    // public float spawnOffset; // Offsets the objects position when spawned so they tile next to each other
    // public MeshGenerator meshGenerator; // Stores the mesh generator script attached to the object entered the trigger        
    
    //========================= Collectable variables =========================
    // Collectable spawn position x and y axis is randomised
    public float spawnPosX;
    public float spawnRangeXMin;
    public float spawnRangeXMax;
    public float spawnPosY;
    public float spawnRangeYMin;
    public float spawnRangeYMax;
    // Variables to randomise the delay
    // public float collectableRandMin; 
    // public float collectableRandMax;

    // private float objectDelay; // For setting a delay between object placements
    public Vector3 collectableSpawnPos_1; // Collectable spawn 1
    public Vector3 collectableSpawnPos_2; // Collectable spawn 2
    public Vector3 collectableSpawnPos_3; // Collectable spawn 3
    public Transform obstacleSpawnPosition; // Reference to the object spawn position.

    //========================== Obstacle variables ===========================
    public float obstacleSpawnOffset;

    // Checks what type of object entered the attached trigger then spawns the next one available in the object pool
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("trigger entered");        

        //if (other.tag == "Terrain")
        //{
        //    // Grabs the mesh generator of the object that collided and gets it's mesh z size. 
        //    // This is used to offset and tile the objects perfectly next to each other.
        //    meshGenerator = other.gameObject.GetComponent<MeshGenerator>();
        //    spawnOffset = meshGenerator.zSize;


        //    // Debug.Log("tag is true");
           
        //    GameObject objectToActivate = ObjectPooler.SharedInstance.GetPooledObject("Terrain");
        //    if (objectToActivate != null)
        //    {
        //        // Sets the position of each object, allowing for the position offset
        //        objectToActivate.transform.position = new Vector3(terrainSpawnPosition.transform.position.x, terrainSpawnPosition.transform.position.y, (terrainSpawnPosition.transform.position.z + spawnOffset));
        //        objectToActivate.transform.rotation = terrainSpawnPosition.transform.rotation;
        //        objectToActivate.SetActive(true);
        //        // Debug.Log("spawn offset = " + spawnOffset);
        //    }
        //}

        if (other.tag == "Collectable_1")
        {
            
            // objectDelay = Random.Range(collectableRandMin, collectableRandMax);
            // DelayObjectPlacement();

            // Debug.Log("is a collectable");

            // Randomise spawn position
            // spawnPosX = Random.Range(spawnRangeXMin, spawnRangeXMax);
            // spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);

            GameObject objectToActivate = ObjectPooler.SharedInstance.GetPooledObject("Collectable_1");
            if (objectToActivate != null)
            {
                // Sets the position of each object
                objectToActivate.transform.position = collectableSpawnPos_1;
                objectToActivate.transform.rotation = Quaternion.Euler(collectableSpawnPos_1);
                objectToActivate.SetActive(true);
                // Debug.Log("spawn offset = " + spawnOffset);
            }
        }

        if (other.tag == "Collectable_2")
        {

            // objectDelay = Random.Range(collectableRandMin, collectableRandMax);
            // DelayObjectPlacement();

            // Debug.Log("is a collectable");

            // Randomise spawn position
            // spawnPosX = Random.Range(spawnRangeXMin, spawnRangeXMax);
            // spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);

            GameObject objectToActivate = ObjectPooler.SharedInstance.GetPooledObject("Collectable_2");
            if (objectToActivate != null)
            {
                // Sets the position of each object
                objectToActivate.transform.position = collectableSpawnPos_2;
                objectToActivate.transform.rotation = Quaternion.Euler(collectableSpawnPos_2);
                objectToActivate.SetActive(true);
                // Debug.Log("spawn offset = " + spawnOffset);
            }
        }

        if (other.tag == "Collectable_3")
        {

            // objectDelay = Random.Range(collectableRandMin, collectableRandMax);
            // DelayObjectPlacement();

            // Debug.Log("is a collectable");

            // Randomise spawn position
            // spawnPosX = Random.Range(spawnRangeXMin, spawnRangeXMax);
            // spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);

            GameObject objectToActivate = ObjectPooler.SharedInstance.GetPooledObject("Collectable_3");
            if (objectToActivate != null)
            {
                // Sets the position of each object
                objectToActivate.transform.position = collectableSpawnPos_3;
                objectToActivate.transform.rotation = Quaternion.Euler(collectableSpawnPos_3);
                objectToActivate.SetActive(true);
                // Debug.Log("spawn offset = " + spawnOffset);
            }
        }


        if (other.tag == "Obstacle")
        {                 
                        
            // Randomise spawn position
            spawnPosX = Random.Range(spawnRangeXMin, spawnRangeXMax);
            // spawnPosY = Random.Range(spawnRangeYMin, spawnRangeYMax);

            GameObject objectToActivate = ObjectPooler.SharedInstance.GetPooledObject("Obstacle");
            if (objectToActivate != null)
            {
                // DelayObjectPlacement();

                // Sets the position of each object
                objectToActivate.transform.position = new Vector3(spawnPosX, spawnPosY, (obstacleSpawnPosition.transform.position.z+obstacleSpawnOffset));
                objectToActivate.transform.rotation = obstacleSpawnPosition.transform.rotation;
                objectToActivate.SetActive(true);
                // Debug.Log("spawn offset = " + spawnOffset);
            }
        }
    }    

}
