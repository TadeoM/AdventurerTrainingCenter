using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName;
    public List<Room> additionalRooms;
    public List<string> unlockedHeroes;
    public List<string> unlockedMonsters;
    public List<string> unlockedWeapons;
    public List<string> unlockedArmors;
    public List<string> unlockedPassiveBonuses; // str+ , int+ , dex+ , damage+

    public List<string> unlockedRooms;
    public List<string> unlockedTrainers;

    public List<ScriptableObject> availableUpgrades;
    public List<ScriptableObject> unlockedUpgrades;
    // bonuses/armor/weapons have all the necessary stats, you add to all the entity's stats at the beginning of the dungeon.
    // go through the unlockedUpgrades and call an event that will pass the unlocked ability/entity/item (create 3 different methods in an event manager). Each method adds the passed in parameter to the 5 lists above, which will be stored in like, some account class
}
