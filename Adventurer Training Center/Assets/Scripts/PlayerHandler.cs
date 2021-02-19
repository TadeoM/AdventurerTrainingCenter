﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public List<FacilityUpgrade> currentUpgrades;
    [SerializeField]
    private List<FacilityUpgrade> AllAvailableUpgrades;
    public int StartingGold;
    public int playerGold;
    public int playerPopulation;
    public enum PlayerReputation
    {
        Legendary,
        Renown,
        Respected,
        Known,
        Unheard,
    }
    // Start is called before the first frame update
    void Start()
    {
        currentUpgrades = new List<FacilityUpgrade>();
        playerGold = StartingGold;
        playerPopulation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetGold()
    {
        return playerGold;
    }
    public bool BuyFacilityRoomCreation(FacilityUpgrade upgrade)
    {
        Debug.Log("Bought Upgrade: " + upgrade.UpgradeName);

        if (!currentUpgrades.Contains(upgrade) && CheckGoldForSpend(upgrade.UpgradeCost))
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
        if (!currentUpgrades.Contains(upgrade) && CheckGoldForSpend(upgrade.UpgradeCost))
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
