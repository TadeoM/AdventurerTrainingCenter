using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FacilityUpgrades", menuName = "ScriptableObjects/Create Facility Upgrade", order = 1)]
public class FacilityUpgrade : ScriptableObject
{

    public string UpgradeName;
    [TextArea(3,10)]
    public string UpgradeDescription;
    public int UpgradeCost;
    public Sprite UpgradeThumbnail;
    public bool SpawnRoom;
    public Transform SpawnLocation;
    [SerializeField]
    private GameObject RoomPrefab;

    public enum RoomType
    {
        Infirmary,
        Dormitory,
        Armory,
        Blacksmith,
        TrainingField,
        Office,
        ResearchLaboratory,

    }
    
    public FacilityUpgrade(string upgradeName, string upgradeDescription, Sprite upgradeThumbnail, bool spawnRoom, Transform spawnLocation)
    {
        UpgradeName = upgradeName;
        UpgradeDescription = upgradeDescription;
        UpgradeThumbnail = upgradeThumbnail;
        SpawnRoom = spawnRoom;
        SpawnLocation = spawnLocation;
    }
    public void UpgradeEffect()
    {
        if(SpawnRoom)
        {

        }
        
    }
    public bool CheckUpgrade()
    {
        return true;
    }
    public bool CheckCost(int playerGold)
    {
        if(playerGold>UpgradeCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
