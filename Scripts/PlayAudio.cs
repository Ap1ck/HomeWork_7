using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        Audio.Play();
    }
}
