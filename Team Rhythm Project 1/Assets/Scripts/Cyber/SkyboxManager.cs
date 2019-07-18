using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public AudioSource musicSource;     // Background music source
    public AudioClip musicClip;         // The BG music clip
    public float musicLength;           // Length of the music clip
    public float musicPos;              // The position in the music clip (value between 0-1, percentage of the whole clip)

    public float exposure;              // The float for the skybox exposure
    public float exposureMin;           // Lowest value for the exposure
    public float exposureMax;           // Highest value for the exposure
    public float exposureDiff;          // Difference between high and low exposure

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();
        musicClip = musicSource.clip;
        musicLength = musicClip.length;

        exposure = exposureMin;
        exposureDiff = exposureMax - exposureMin;
    }

    // Update is called once per frame
    void Update()
    {
        musicPos = musicLength / Time.time;
        exposure = exposureDiff / musicPos;
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
    }
}
