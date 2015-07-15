using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public AudioClip clipToPlay;

    public void PlayAudioClip()
    {
        audio.clip = clipToPlay;
        audio.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAudioClip();
        }
    }
}
