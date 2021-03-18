using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FacilityUIHandler : MonoBehaviour
{
    public Text playerPopulation;
    public Text playerGold;
    public Text playerReputation;
    public Text currTime;

    public GameObject blacksmithObject;
    public GameObject infirmaryObject;
    public GameObject trainingFieldObject;
    public GameObject armoryObject;


    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currTime.text =" "+ GameController.Instance.date;
        playerPopulation.text = "Population: " + PlayerHandler.Instance.heroPopulation.Count;
        playerGold.text = "Gold: " + PlayerHandler.Instance.playerGold + "/ + " + PlayerHandler.Instance.playerIncome;
        playerReputation.text = "Reputation: " + PlayerHandler.Instance.playerReputation.ToString();
    }


    public void SpawnRecruit()
    {
        GameController.Instance.RecruitTrainees();
    }
   
}
