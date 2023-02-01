using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    private AudioSource _audio;
    public float MaxTime;
    public bool Tick;

    private Image _image;
    private float _currentTime;

    void Start()
    {
        _image = GetComponent<Image>();
        _audio = GetComponent<AudioSource>();
        _currentTime = MaxTime;
    }

    void Update()
    {
        Tick = false;
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            Tick = true;
            _currentTime = MaxTime;
            _audio.Play();
        }

        _image.fillAmount = _currentTime / MaxTime;
    }
}
