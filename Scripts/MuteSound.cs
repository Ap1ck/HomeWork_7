using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    [SerializeField] private AudioSource BackgroundSound;
    [SerializeField] private AudioSource HarvestingWheatSound;
    [SerializeField] private AudioSource CollectionOfFoodSound;
    [SerializeField] private AudioSource RaidSound;

    private bool _muted;

    public void MutedMusic()
    {
        if (_muted)
        {
            BackgroundSound.mute=false;
            HarvestingWheatSound.mute = false;
            CollectionOfFoodSound.mute = false;
            RaidSound.mute = false;
        }
        else
        {
            BackgroundSound.mute = true;
            HarvestingWheatSound.mute = true;
            CollectionOfFoodSound.mute = true;
            RaidSound.mute = true;
        }

        _muted = !_muted;
    }
}
