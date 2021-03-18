using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerReputation
{
    Legendary,
    Renown,
    Respected,
    Known,
    Unheard,
}

public struct Hero
{
    public int level;
    public string name;
    public HeroClass heroClass;
    public Hero(Entity entity)
    {
        level = entity.level;
        name = entity.name;
        heroClass = entity.heroClass;
    }
}

public class PlayerHandler : Singleton<PlayerHandler>
{
    public List<FacilityUpgrade> currentUpgrades;
    [SerializeField]
    private List<FacilityUpgrade> AllAvailableUpgrades;
    public int StartingGold;
    public int playerGold;
    public List<Hero> heroPopulation;

    public PlayerReputation playerReputation;
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        currentUpgrades = new List<FacilityUpgrade>();
        playerGold = StartingGold;
        heroPopulation = new List<Hero>();
        for (int i = 0; i < 2; i++)
        {
            Hero newHero = new Hero();
            newHero.level = 1;
            newHero.heroClass = (HeroClass)Random.Range(0, 3);
            newHero.name = $"{newHero.heroClass}_{i}";
            heroPopulation.Add(newHero);
        }
    }

    public int GetGold()
    {
        return playerGold;
    }
    public bool BuyFacilityRoomCreation(FacilityUpgrade upgrade)
    {
        Debug.Log("Bought Upgrade: " + upgrade.upgradeName);

        if (!currentUpgrades.Contains(upgrade) && CheckGoldForSpend(upgrade.upgradeCost))
        {
            currentUpgrades.Add(upgrade);
            //Instantiate Room
            upgrade.FacilityRoomCreation();
            return true;
        }
        else
            return false;
    }
    public bool BuyFacilityUpgrade(FacilityUpgrade upgrade)
    {
        if (!currentUpgrades.Contains(upgrade) && CheckGoldForSpend(upgrade.upgradeCost))
        {
            currentUpgrades.Add(upgrade);
            upgrade.SetUpgradeEffect();
            return true;
        }
        else
            return false;
    }   
   public bool CheckGoldForSpend(int goldAmount)
    {
        if (GetGold() >= goldAmount)
        {
            playerGold -= goldAmount;
            return true;
        }
        else
        {
            return false;
        }
    }
}
