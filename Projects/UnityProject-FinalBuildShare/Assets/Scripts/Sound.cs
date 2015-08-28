using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{

    public AudioClip audioClip;

    void PlayAudioClip()
    {
        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayAudioClip();
        }
    }
}
