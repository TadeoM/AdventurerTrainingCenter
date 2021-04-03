using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterTrader : MonoBehaviour
{
    public List<MonsterData> monsterDataForDungeon;
    public float goodEventChance;
    public float badEventChance;

    public GameObject monsterTraderMenu;
    public GameObject monsterListContainer;
    public GameObject listedMonsterTemplate;
    public List<GameObject> monsterPrefabs;
    public List<MonsterData> currMonstersInShop;
    public List<MonsterData> availableMonsterList;
    bool openClose = false;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < monsterPrefabs.Count; i++)
        {
            availableMonsterList.Add(monsterPrefabs[i].GetComponent<MonsterData>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void AddToAvailableMonsterList(GameObject monsterPrefabToAdd)
    {
        availableMonsterList.Add(monsterPrefabToAdd.GetComponent<MonsterData>());
    }
    void RandomizeShop()
    {
        //if(false)//Next Day switchup or maybe after a week switch up
        currMonstersInShop.Clear();
        for (int i = 0; i < Random.Range(1,4); i++)
        {
            currMonstersInShop.Add(availableMonsterList[i]);
        }
       
    }

    void InitalizeShop()
    {

        for (int i = 0; i < currMonstersInShop.Count; i++)
        {
            GameObject newListedMonster = Instantiate(listedMonsterTemplate);
            newListedMonster.transform.SetParent(monsterListContainer.transform);
            MonsterData currentMonsterData = currMonstersInShop[i].GetComponent<MonsterData>();
            //currentMonsterData.Init(goodEventChance,badEventChance);
            newListedMonster.GetComponent<ListedMonster>().Init(currentMonsterData);
            newListedMonster.GetComponent<Button>().onClick.AddListener(() => BuyMonster(currentMonsterData));
        }
    }
    public void BuyMonster(MonsterData currMonsterData)
    {
        if(PlayerHandler.Instance.CheckGoldForSpend(currMonsterData.cost))
        {
            PlayerHandler.Instance.monsterPossession.Add(currMonsterData);
        }
        else
        {
            Debug.Log("Not Enough Money");
        }


    }
    public void DisplayShop()
    {
        openClose = !openClose;
        monsterTraderMenu.SetActive(openClose);
        RandomizeShop();
        InitalizeShop();
    }
    int RandomizeAmount()
    {
        if (Random.Range(0f, 1f) < badEventChance)
        {
            return -Random.Range(1, 3);
        }
        else if (Random.Range(0, 1f) < goodEventChance)
        {
            return Random.Range(3, 5);
        }
        else
            return 0;
       
        
    }
    /*
void TraderEvent()
{

}

int ModifyCost(MonsterData currMonsterData)
{
    if((Random.Range(0,1))<goodEventChance)
    {
        cost = currMonsterData.cost - 100;
    }

    return cost;
}
*/
}
