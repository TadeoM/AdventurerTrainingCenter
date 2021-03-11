using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int day;
    private float timePerDay;

    [SerializeField]
    private GameObject playerHandlerEntity;
    private PlayerHandler playerHandler;
    [SerializeField]
    private GameObject trainingFieldEntity;
    private TrainingField traingField;
    [SerializeField]
    private float timeMultiplier;
    [SerializeField]
    private float currTime;
    // Start is called before the first frame update
    void Start()
    {
        playerHandler = playerHandlerEntity.GetComponent<PlayerHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeTick())
        {
            NextDay();
        }

    }
    void NextDay()
    {
        playerHandler.CalculateGoldIncome();
        day += 1;
    }
    bool TimeTick()
    {
        currTime += Time.deltaTime * timeMultiplier;
        if (currTime >= timePerDay)
        {
            currTime = 0;
            return true;
        }
            
        else
            return false;
    }
    public void TotalDayAssessment(int amountUpgraded)
    {
       
    }
    public void RecruitTrainees()
    {
        //Spawn  entity and add to entity list to playerhandler
    }
    void WeekAssessment()
    {
        
    }
}
