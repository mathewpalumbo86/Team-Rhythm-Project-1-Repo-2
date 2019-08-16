using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOnCollision : MonoBehaviour
{
    // This scripts controls what happens to an obstacle when it collides with the player

    AudioSource audioSource;
    AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.GetComponent<MeshRenderer>().enabled == true)
            {
                // Turn the obstacle renderer on
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            StartCoroutine(WaitForAudioToFinish());

        }
    }

    IEnumerator WaitForAudioToFinish()
    {
        audioSource.PlayOneShot(audioClip);

        yield return new WaitWhile(() => audioSource.isPlaying);
        
        gameObject.SetActive(false);


    }

}
