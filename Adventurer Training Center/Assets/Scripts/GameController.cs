using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int day;
    private float timePerDay;
    public Vector3 spawnPos;
    public GameObject heroRecruit;
    private Hero heroToAdd;
    private Entity entityToAdd;
    [SerializeField]
    private GameObject trainingFieldEntity;
    private TrainingField trainingField;
    [SerializeField]
    private float timeMultiplier;
    [SerializeField]
    private float currTime;

    // Start is called before the first frame update
    void Start()
    {
        trainingField = trainingFieldEntity.GetComponent<TrainingField>();
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
        trainingField.PerformTraining();
        PlayerHandler.Instance.TotalDayAssessment();
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

    public void RecruitTrainees()
    {
        entityToAdd=Instantiate(heroRecruit,spawnPos,Quaternion.identity).GetComponent<Entity>();
        trainingField.currTraineesInFacility.Add(entityToAdd);
        //PlayerHandler.Instance.heroPopulation.Add(heroToAdd);
        //Spawn  entity and add to entity list to playerhandler
        PlayerHandler.Instance.CalculateGoldIncome(50);
    }
    void WeekAssessment()
    {
        
    }
}
