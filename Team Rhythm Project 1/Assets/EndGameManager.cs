using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField, Tooltip("Put everything but the player/camera rig in this array")]
    GameObject[] objectsInScene;

    [SerializeField, Tooltip("Put All Firework Objects to instantiate after city explosion")]
    GameObject[] fireworksToSpawn;

    [SerializeField, Tooltip("Put All Secondary FX Objects to instantiate after city explosion")]
    GameObject[] secondaryFXToSpawn;

    [SerializeField, Tooltip("Put All Tertiary FX Objects to instantiate after city explosion")]
    GameObject[] tertiaryFXToSpawn;

    [SerializeField, Tooltip("Put All Firework Spawn Points in here")]
    GameObject[] fireworkSpawnPoints;

    [SerializeField, Tooltip("Put All Secondary Spawn Points in here")]
    GameObject[] secondaryEffectSpawnPoints;

    [SerializeField, Tooltip("Put All Tertiary Spawn Points in here")]
    GameObject[] tertiaryEffectSpawnPoints;

    private void OnEnable()
    {
        Debug.Log("Did you tag all EoG Objects with the EoGSpawnPoint or EoGObject tags?");
        DeactivateObjects(); // Deactivates the game objects
        SpawnObjects(); // Spawns EoG Objects from arrays
    }

    void DeactivateObjects()
    {
        if (objectsInScene != null)
        {
            foreach(GameObject currentObject in objectsInScene)
            {
                if (currentObject.tag != "CameraRig" && currentObject.tag != "EoGSpawnPoint")// makes sure mistakes are minimized when debugging. EoGSpawnPoint is for end of game spawns (fireworks, etc.)
                {
                    currentObject.SetActive(false); // deactivates everything in the array
                }
            }
        }
    }

    void SpawnObjects()
    {
        if (fireworksToSpawn != null)
        {
            for(int i = 0; i < (fireworkSpawnPoints.Length - 1); i++)
            {
                if (i > (fireworksToSpawn.Length - 1) || i <= -1)
                {
                    break;
                }
                Instantiate(fireworksToSpawn[i], fireworkSpawnPoints[i].transform.position, Quaternion.identity);

            }
        }

        if (secondaryFXToSpawn != null)
        {
            for (int i = 0; i < (secondaryEffectSpawnPoints.Length - 1); i++)
            {
                if (i > (secondaryFXToSpawn.Length - 1) || i <= -1)
                {
                    break;
                }
                Instantiate(secondaryFXToSpawn[i], secondaryEffectSpawnPoints[i].transform.position, Quaternion.identity);

            }
        }

        if (tertiaryFXToSpawn != null)
        {
            for (int i = 0; i < (tertiaryEffectSpawnPoints.Length - 1); i++)
            {
                if (i > (tertiaryFXToSpawn.Length - 1) || i <= -1)
                {
                    break;
                }
                Instantiate(tertiaryFXToSpawn[i], tertiaryEffectSpawnPoints[i].transform.position, Quaternion.identity);

            }
        }
    }

    
}
