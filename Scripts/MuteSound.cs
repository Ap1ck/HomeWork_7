using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    public AudioSource BackgroundSound;
    public AudioSource HarvestingWheatSound;
    public AudioSource CollectionOfFoodSound;
    public AudioSource RaidSound;

    private bool _muted;

    public void MutedMusic()
    {
        if (_muted)
        {
            BackgroundSound.Play();
            HarvestingWheatSound.Play();
            CollectionOfFoodSound.Play();
        }
        else
        {
            BackgroundSound.Pause();
            HarvestingWheatSound.Pause();
            CollectionOfFoodSound.Pause();
        }

        _muted = !_muted;
    }
}
