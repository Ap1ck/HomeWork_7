using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Button _worker;
    [SerializeField] private Button _warrior;
    [SerializeField] private AudioSource _harvestingSound;
    [SerializeField] private AudioSource _enemiesSound;
    [SerializeField] private AudioSource _eatingSound;
    [SerializeField] private AudioSource _backgroundSound;

    private bool _paused;

    public void PauseGame()
    {
        _worker.interactable = true;
        _warrior.interactable = true;

        if (_paused)
        {
            Time.timeScale = 1;
            _harvestingSound.mute = false;
            _enemiesSound.mute = false;
            _eatingSound.mute = false;
            _backgroundSound.mute = false;
        }
        else
        {
            Time.timeScale = 0;
            _harvestingSound.mute = true;
            _enemiesSound.mute = true;
            _eatingSound.mute = true;
            _backgroundSound.mute = true;

            _worker.interactable = false;
            _warrior.interactable = false;
        }

        _paused = !_paused;
    }
}
