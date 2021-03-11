using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "FacilityUpgrades", menuName = "ScriptableObjects/Create Facility Upgrade", order = 1)]
public class FacilityUpgrade : ScriptableObject
{
    public string upgradeName;
    [TextArea(3,10)]
    public string upgradeDescription;
    public int upgradeCost;
    public Sprite upgradeThumbnail;
    public bool spawnRoom;
    public Vector3 spawnLocation;
    [SerializeField]
    protected GameObject roomPrefab;

    [SerializeField] protected int bonusStrength;
    [SerializeField] protected int bonusDexterity;
    [SerializeField] protected int bonusIntelligence;

    [SerializeField] protected int bonusHealth;
    [SerializeField] protected int bonusMana;
    [SerializeField] protected int bonusArmor;

    [SerializeField] protected int bonusMovemenSpeed;
    [SerializeField] protected float bonusAttackSpeed;
    [SerializeField] protected float bonusDodgeChance;


    public FacilityUpgrade(string upgradeName, string upgradeDescription, Sprite upgradeThumbnail, bool spawnRoom, Vector3 spawnLocation)
    {
        this.upgradeName = upgradeName;
        this.upgradeDescription = upgradeDescription;
        this.upgradeThumbnail = upgradeThumbnail;
        this.spawnRoom = spawnRoom;
        this.spawnLocation = spawnLocation;
    }
    public void FacilityRoomCreation()
    {
        Debug.Log("Got to create method");
        Instantiate(roomPrefab, spawnLocation,Quaternion.identity);

    }
    public void SetUpgradeEffect()
    {

    }
    public bool CheckUpgrade()
    {
        return true;
    }
    public bool CheckCost(int playerGold)
    {
        if(playerGold>upgradeCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
