using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Muse : MonoBehaviour
{


    AudioMixerControl mixer;

    [Range(-80f, 20f)]
    public float volume;
    [Range(-80, 20f)]
    public float pitch;


    // Start is called before the first frame update
    void Start()
    {

        

        mixer.DrumSfx1(10);

    }




   
}
