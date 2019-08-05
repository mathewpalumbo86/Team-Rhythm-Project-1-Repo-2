using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerControl : MonoBehaviour
{
    public AudioMixer masterAudio;
    
    public bool ON = false;


    [Range(-80f, 20f)]
    public float volume;
    [Range(-80, 20f)]
    public float pitch;

    

    public void SetMasterMusic(float masterVol)
    {
        
        masterAudio.SetFloat("MasterVol", masterVol);
        
    }
    private void Start()
    {
      //CyberSfx2(10);

    }
    public void Update()
    {
        if (ON == true)
        {
            CyberSfx1(20);
        }
        else 
        {
            ON = false;
            CyberSfx1(-80);
        }
    }

    public void CyberSfx1 (float Cbr1)
    {
        
        masterAudio.SetFloat("Cyber1", Cbr1);

        

    }
    public void CyberSfx2(float Cbr2)
    {
        masterAudio.SetFloat("Cyber2", Cbr2);
        
    }

    public void CyberSfx3(float Cbr3)
    {
        masterAudio.SetFloat("Cyber3", Cbr3);
    }

    public void DrumSfx1 (float Drum1)
    {
        masterAudio.SetFloat("Drum1", Drum1);
    }

    public void DrumSfx2 (float Drum2)
    {
        masterAudio.SetFloat("Drum2", Drum2);
    }

    public void DrumSfx3 (float Drum3)
    {
        masterAudio.SetFloat("Drum3", Drum3);
    }


    public void MusicOn()
    {

        ON = true;
               
    }

    public void MusicOff()
    {
        ON = false;

    }
}
