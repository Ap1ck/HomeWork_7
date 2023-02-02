using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveImage : MonoBehaviour
{
    [SerializeField] private Image _imageActive;

    private bool _activeImage;

    public void ShowImage()
    {
        if (_activeImage)
        {
            _imageActive.gameObject.SetActive(false);
        }
        else
        {
            _imageActive.gameObject.SetActive(true);
        }

        _activeImage = !_activeImage;
    }
}
