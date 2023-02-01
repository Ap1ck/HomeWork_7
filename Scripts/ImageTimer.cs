using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public float MaxTime;
    public bool Tick;

    private Image _image;
    private float _currentTime;
   
    void Start()
    {
        _image = GetComponent<Image>();

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
        }

        _image.fillAmount = _currentTime / MaxTime;
    }
}
