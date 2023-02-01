using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public AudioSource Sound;

    private bool _paused;
    private bool _mute;

    public void PauseGame()
    {
        if (_paused)
        {
            Time.timeScale = 1;
            Sound.Play();
        }
        else
        {
            Time.timeScale = 0;
            Sound.Pause();
        }

        _paused = !_paused;
    }

    public void TurnOffTheMusic()
    {
        if (_mute)
        {
            Sound.Play();
        }
        else
        {
            Sound.Pause();
        }

        _mute = !_mute;
    }
}
