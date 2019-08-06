using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerControl : MonoBehaviour
{
    public AudioMixer masterAudio;
    
    public bool ON = false;


    [Range(-80f, 20f)]
    public float mVolume;
    [Range(-80, 20f)]
    public float pitch;
    [Range(-80f, 20f)]
    public float c1Volume;
    [Range(-80f, 20f)]
    public float c2Volume;
    [Range(-80f, 20f)]
    public float c3Volume;
    [Range(-80f, 20f)]
    public float d1Volume;
    [Range(-80f, 20f)]
    public float d2Volume;
    [Range(-80f, 20f)]
    public float d3Volume;



    public void SetMasterMusic(float masterVol)
    {
        
        masterAudio.SetFloat("MasterVol", masterVol);
        
    }
    private void Start()
    {
        CyberSfx1(-80);


    }
    public void Update()
    {

        /*if (ON == true)
        {
            CyberSfx1(volume);// how you set the music (between -80 and 20)
        }
        else 
        {
            ON = false;
            CyberSfx1(-80);
        }
        */

        SetMasterMusic(mVolume);// master music slider 
        
        CyberSfx1(c1Volume);// cyber effect sliders 
        CyberSfx2(c2Volume);
        CyberSfx3(c3Volume);

        DrumSfx1(d1Volume);//drum effect sliders 
        DrumSfx2(d2Volume);
        DrumSfx3(d3Volume);



    }

    public void CyberSfx1 (float Cbr1)
    {

                masterAudio.SetFloat("Cyber1", Cbr1);// lets you change the volume for Cyber effect 

        
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
