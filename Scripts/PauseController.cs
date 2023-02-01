using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Button Worker;
    public Button Warrior;
    public AudioSource BackgroundSound;
    public AudioSource HarvestingWheatSound;
    public AudioSource RaidSound;
    public AudioSource CollectionOfFoddSound;
    public int Warriors;

    private bool _paused;
    private bool _mute;

    public void PauseGame()
    {
        Worker.interactable = true;
        Warrior.interactable=true;

        if (_paused)
        {
            Time.timeScale = 1;
            BackgroundSound.Play();
            HarvestingWheatSound.Play();
            CollectionOfFoddSound.Play();
        }
        else
        {
            Time.timeScale = 0;
            BackgroundSound.Pause();
            HarvestingWheatSound.Pause();
            CollectionOfFoddSound.Pause();
            Worker.interactable = false;
            Warrior.interactable = false;
        }

        _paused = !_paused;
    }

    public void TurnOffTheMusic()
    {
        if (_mute)
        {
            BackgroundSound.Play();
        }
        else
        {
            BackgroundSound.Pause();
        }

        _mute = !_mute;
    }
}
