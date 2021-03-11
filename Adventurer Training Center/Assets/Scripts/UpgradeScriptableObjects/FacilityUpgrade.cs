using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "FacilityUpgrades", menuName = "ScriptableObjects/Create Facility Upgrade", order = 1)]
public class FacilityUpgrade : ScriptableObject
{

    [SerializeField]
    private string UpgradeName;
    [SerializeField]
    [TextArea(3,10)]
    private string UpgradeDescription;
    [SerializeField]
    public int UpgradeCost;
    [SerializeField]
    private Sprite UpgradeThumbnail;
    [SerializeField]
    private bool SpawnRoom;
    [SerializeField]
    private Vector3 SpawnLocation;
    [SerializeField]
    protected GameObject RoomPrefab;



    
    public FacilityUpgrade(string upgradeName, string upgradeDescription, Sprite upgradeThumbnail, bool spawnRoom, Vector3 spawnLocation)
    {
        
        UpgradeName = upgradeName;
        UpgradeDescription = upgradeDescription;
        UpgradeThumbnail = upgradeThumbnail;
        SpawnRoom = spawnRoom;
        SpawnLocation = spawnLocation;
    }
    public void FacilityRoomCreation()
    {
        Debug.Log("Got to create method");
        Instantiate(RoomPrefab, SpawnLocation,Quaternion.identity);

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
