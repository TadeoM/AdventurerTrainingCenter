using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{
    public enum MonsterType
    {
        Undead,
        Giants,
        Demon,
        Humanoid,
    }
    public int modifiers;
    public int level;
    public string monsterName;
    public string monsterDescription;
    public int expGain;
    public int cost;
    public int baseAmount;
    public MonsterType monsterType;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(float goodEventChance,float badEventChance)
    {
        baseAmount = baseAmount + RandomizeAmount(badEventChance, goodEventChance);
    }
    int RandomizeAmount(float badEventChance, float goodEventChance)
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
    public string GetImagePath()
    {
        switch (monsterType)
        {
            case MonsterType.Undead:
                return "BabySkeleton";
            case MonsterType.Giants:
                return "OrangeKnight";
            case MonsterType.Demon:
                return "Wizard";
            case MonsterType.Humanoid:
                return "TealLizard";
            default:
                return "";
        }
    }
}
