using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{

    public AudioClip audioClip;

    void PlayAudioClip()
    {
        audio.clip = audioClip;
        audio.Play();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayAudioClip();
        }
    }
}
