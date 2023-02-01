using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;
    public Image RaidTimerImg;
    public Image WorkerTimerImg;
    public Image WarriorsTimerImg;


    public Button workerButton;
    public Button warriorButton;

    public Text resourcesText;

    public int workerCount;
    public int warriorsCount;
    public int wheatCount;


    public int wheatPerWorkers;
    public int wheatToWarriors;

    public int workerCost;
    public int warriorCost;

    public float workerCreatTime;
    public float warriorCreatTime;
    public float raidMaxTime;
    public int raidIncrease;
    public int nextRaid;


    private float _workerTimer = -2;
    private float _warriorTimer = -2;
    private float _raidTimer;

    private void Start()
    {
        UpdateText();

        _raidTimer = raidMaxTime;
    }

    private void Update()
    {
        _raidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = _raidTimer / raidMaxTime;

        if (_raidTimer <= 0)
        {
            _raidTimer = raidMaxTime;
            warriorsCount -= nextRaid;
            nextRaid += raidIncrease;
        }

        if (HarvestTimer.Tick)
        {
            wheatCount += workerCount * wheatPerWorkers;
        }

        if (EatingTimer.Tick)
        {
            wheatCount -= warriorsCount * wheatToWarriors;
        }

        if (_workerTimer > 0)
        {
            _workerTimer -= Time.deltaTime;
            WorkerTimerImg.fillAmount = _workerTimer / workerCreatTime;
        }
        else if (_workerTimer > -1)
        {
            WorkerTimerImg.fillAmount = 1;
            workerButton.interactable = true;
            workerCount += 1;
            _workerTimer = -2;
        }

        if (_warriorTimer > 0)
        {
            _warriorTimer -= Time.deltaTime;
            WarriorsTimerImg.fillAmount = _warriorTimer / warriorCreatTime;
        }
        else if (_warriorTimer > -1)
        {
            WarriorsTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorsCount += 1;
            _warriorTimer = -2;
        }

        UpdateText();
    }

    public void CreatWorker()
    {
        if (wheatCount > wheatPerWorkers)
        {
            wheatCount -= workerCost;
            _workerTimer = workerCreatTime;
            workerButton.interactable = false;
        }  
        else if(wheatCount<wheatPerWorkers)
        {
            workerButton.interactable = false;
        }
    }

    public void CreatWarrior()
    {
        if (wheatCount > wheatToWarriors)
        {
            wheatCount -= warriorCost;
            _warriorTimer = warriorCreatTime;
            warriorButton.interactable = false;
        }
        else if(wheatCount<wheatToWarriors)
        {
            warriorButton.interactable = false;
        }
    }

    private void UpdateText()
    {
        resourcesText.text =workerCount +"\n"+ warriorsCount + "\n\n"+ wheatCount;
    }
}
