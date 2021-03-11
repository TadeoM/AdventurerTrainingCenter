using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text playerPopulation;
    public Text playerGold;
    public Text playerReputation;
    public Text currTime;
    public PlayerHandler playerEntity;

    public GameObject blacksmithObject;
    public GameObject infirmaryObject;
    public GameObject trainingFieldObject;
    public GameObject armoryObject;

    [SerializeField]
    private GameObject gameControllerEntity;
    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = gameControllerEntity.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        currTime.text ="Day "+ gameController.day;
        playerPopulation.text = "Population: " + PlayerHandler.Instance.heroPopulation.Count;
        playerGold.text = "Gold: " + PlayerHandler.Instance.playerGold + "/ + " + PlayerHandler.Instance.playerIncome;
        playerReputation.text = "Reputation: " + PlayerHandler.Instance.playerReputation.ToString();
    }


    public void SpawnRecruit()
    {
        gameController.RecruitTrainees();
    }
   
}
