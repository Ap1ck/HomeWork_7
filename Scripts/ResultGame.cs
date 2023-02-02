using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGame : MonoBehaviour
{
    [SerializeField] private Image _panel;

    private GameManager _gameManager;
    private PauseController _pauseControll;

    private int _wheatCount = 20;
    private int _warriorsCount = 2;

    public void ResultWin()
    {
        if (_gameManager.WheatCount <= _wheatCount && _warriorsCount <= _gameManager.WarriorsCount)
        {
            _panel.gameObject.SetActive(true);
            _pauseControll.PauseGame();
        }
    }

    public void ResultLost()
    {
        if (_gameManager.WarriorsCount <= -1)
        {
            _panel.gameObject.SetActive(true);
            _pauseControll.PauseGame();
        }
    }

    public void Update()
    {
        ResultLost();
        ResultWin();
    }
}
