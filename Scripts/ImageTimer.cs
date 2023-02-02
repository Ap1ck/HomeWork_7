using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] private float _maxTime;

    private AudioSource _audio;
    private Image _image;
    private bool _tick;
    private float _currentTime;

    public bool Tick => _tick;

    private void Start()
    {
        _image = GetComponent<Image>();
        _audio = GetComponent<AudioSource>();
        _currentTime = _maxTime;
    }

    private void Update()
    {
        _tick = false;
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            _tick = true;
            _currentTime = _maxTime;
            _audio.Play();
        }

        _image.fillAmount = _currentTime / _maxTime;
    }
}
