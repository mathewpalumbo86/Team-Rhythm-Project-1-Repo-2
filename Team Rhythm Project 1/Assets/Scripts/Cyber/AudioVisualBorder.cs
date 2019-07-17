using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualBorder : MonoBehaviour
{
    // Stores the spectrum analyser script
    public SoundVisual soundVisual;
    
    // Used as conditions for setting the AV object spawn direction
    public enum SpawnDirections { Left, Right, Up, Down, Forward, Back}
    // The selected enum option
    public SpawnDirections selectedSpwnDir;

    // Stores the selected vector that will be used to instantiate the blocks in that direction
    public Vector3 spawnDirection;
    
    // Visual stuff =====================================
    // list of objects spawned
    private Transform[] visualList;       

    // the height scale of each cube based on the audio
    private float[] visualScale;
    // number of cubes
    public int amountOfVisuals;

    public GameObject audioVisualPrefab; // object to instantiate, will scale based on the audio


    // Start is called before the first frame update
    void Start()
    {
        SetSpawnDirection();

        soundVisual = FindObjectOfType<SoundVisual>(); // GetComponent<SoundVisual>();

        SpawnLine();        

    }


    // Update is called once per frame
    void Update()
    {
        UpdateVisual();
    }

    void SetSpawnDirection()
    {
        switch (selectedSpwnDir)
        {
            case SpawnDirections.Left:
                spawnDirection = Vector3.left;
                break;
            case SpawnDirections.Right:
                spawnDirection = Vector3.right;
                break;
            case SpawnDirections.Up:
                spawnDirection = Vector3.up;
                break;
            case SpawnDirections.Down:
                spawnDirection = Vector3.down;
                break;
            case SpawnDirections.Forward:
                spawnDirection = Vector3.forward;
                break;
            case SpawnDirections.Back:
                spawnDirection = Vector3.back;
                break;
            default:
                spawnDirection = Vector3.up;
                break;

        }
    }


    // spawn objects 
    private void SpawnLine()
    {
        // These are the scale values which are updated based on the audio spectrum data
        visualScale = new float[amountOfVisuals];

        visualList = new Transform[amountOfVisuals];

        // Spawn a line of objects to be scale (along a vector)
        for (int i = 0; i < amountOfVisuals; i++)
        {
            // spawns prefabs 
            GameObject go = Instantiate(audioVisualPrefab, transform.position, Quaternion.identity); // GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;

            // adds it to the list
            visualList[i] = go.transform;
            // gives it a position
            visualList[i].localPosition = visualList[i].localPosition + (spawnDirection * i);
        }

    }

    private void UpdateVisual()
    {

        int visualIndex = 0;
        // which frequency
        int spectrumIndex = 0;
        // splits all the samples up into bins based on how many visuals there are
        int averageSize = SoundVisual.SAMPLE_SIZE / amountOfVisuals;

        while (visualIndex < amountOfVisuals)
        {
            int j = 0;
            float sum = 0;
            while (j < averageSize)
            {
                sum += soundVisual.spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            // 
            float scaleY = sum / averageSize * soundVisual.visualModifier;

            visualScale[visualIndex] -= Time.deltaTime * soundVisual.smoothSpeed;

            if (visualScale[visualIndex] < scaleY)
                visualScale[visualIndex] = scaleY;

            // modifies the scale of each object
            visualList[visualIndex].localScale = Vector3.one + Vector3.up * visualScale[visualIndex];
            visualIndex++;



        }
    }


}
