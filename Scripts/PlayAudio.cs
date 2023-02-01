using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    public AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        Audio.Play();
    }
}
