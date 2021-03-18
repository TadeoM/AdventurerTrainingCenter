using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    DateTime dateTimeVar;
    public string date;
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
    DateTime startTime;
    const int daysInGameConversion = 700;
    const int MinutesInDay = 1440/daysInGameConversion;
    public float elapsedGameTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;

      
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
        Debug.Log("Got To Next Day");
        trainingField.PerformTraining();
        PlayerHandler.Instance.TotalDayAssessment();
        day += 1;
    }
    bool TimeTick()
    {

        double timeVar = ((DateTime.Now - startTime).TotalMinutes)*timeMultiplier;
        //Debug.Log(timeVar);
        if(timeVar>MinutesInDay)
        {
            startTime = startTime.AddMinutes(MinutesInDay);
            date = startTime.ToString("M");
            Debug.Log(date);
            Debug.Log(startTime);
            return true;
        }
            
        else
            return false;
    }

    public void RecruitTrainees()
    {
        entityToAdd = Instantiate(heroRecruit, spawnPos, Quaternion.identity).GetComponent<Entity>().Init();
        trainingField.currTraineesInFacility.Add(entityToAdd);
        heroToAdd = new Hero(entityToAdd);
        PlayerHandler.Instance.heroPopulation.Add(heroToAdd);
        //PlayerHandler.Instance.heroPopulation.Add(heroToAdd);
        //Spawn  entity and add to entity list to playerhandler
        PlayerHandler.Instance.CalculateGoldIncome(50);
    }
    void WeekAssessment()
    {
        
    }
}
