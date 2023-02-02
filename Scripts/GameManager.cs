using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ImageTimer _harvestTimer;
    [SerializeField] private ImageTimer _eatingTimer;
    [SerializeField] private Image _raidTimerImg;
    [SerializeField] private Image _workerTimerImg;
    [SerializeField] private Image _warriorsTimerImg;

    [SerializeField] private Button _workerButton;
    [SerializeField] private Button _warriorButton;

    [SerializeField] private Text _resourcesText;

    [SerializeField] private int _workerCount;
    [SerializeField] private int _warriorsCount;
    [SerializeField] private int _wheatCount;

    [SerializeField] private int _wheatPerWorkers;
    [SerializeField] private int _wheatToWarriors;

    [SerializeField] private int _workerCost;
    [SerializeField] private int _warriorCost;

    [SerializeField] private float _workerCreatTime;
    [SerializeField] private float _warriorCreatTime;
    [SerializeField] private float _raidMaxTime;
    [SerializeField] private int _raidIncrease;
    [SerializeField] private int _nextRaid;

    private float _workerTimer = -2;
    private float _warriorTimer = -2;
    private float _raidTimer;

    private void Start()
    {
        UpdateText();

        _raidTimer = _raidMaxTime;
    }

    private void Update()
    {
        _raidTimer -= Time.deltaTime;
        _raidTimerImg.fillAmount = _raidTimer / _raidMaxTime;

        if (_raidTimer <= 0)
        {
            _raidTimer = _raidMaxTime;
            _warriorsCount -= _nextRaid;
            _nextRaid += _raidIncrease;
        }

        if (_harvestTimer.Tick)
        {
            _wheatCount += _workerCount * _wheatPerWorkers;
        }

        if (_eatingTimer.Tick)
        {
            _wheatCount -= _warriorsCount * _wheatToWarriors;
        }

        if (_workerTimer > 0)
        {
            _workerTimer -= Time.deltaTime;
            _workerTimerImg.fillAmount = _workerTimer / _workerCreatTime;
        }
        else if (_workerTimer > -1)
        {
            _workerTimerImg.fillAmount = 1;
            _workerButton.interactable = true;
            _workerCount += 1;
            _workerTimer = -2;
        }

        if (_warriorTimer > 0)
        {
            _warriorTimer -= Time.deltaTime;
            _warriorsTimerImg.fillAmount = _warriorTimer / _warriorCreatTime;
        }
        else if (_warriorTimer > -1)
        {
            _warriorsTimerImg.fillAmount = 1;
            _warriorButton.interactable = true;
            _warriorsCount += 1;
            _warriorTimer = -2;
        }

        UpdateText();
    }

    public void CreatWorker()
    {
        if (_wheatCount > _wheatPerWorkers)
        {
            _wheatCount -= _workerCost;
            _workerTimer = _workerCreatTime;
            _workerButton.interactable = false;
        }
        else if (_wheatCount < _wheatPerWorkers)
        {
            _workerButton.interactable = false;
        }
    }

    public void CreatWarrior()
    {
        if (_wheatCount > _wheatToWarriors)
        {
            _wheatCount -= _warriorCost;
            _warriorTimer = _warriorCreatTime;
            _warriorButton.interactable = false;
        }
        else if (_wheatCount < _wheatToWarriors)
        {
            _warriorButton.interactable = false;
        }
    }

    private void UpdateText()
    {
        _resourcesText.text = ($"Рабочие:{_workerCount} \n Воины:{_warriorsCount} \n\n Пшеница:{_wheatCount}");
    }
}
