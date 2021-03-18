using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum SpawnType
{
    Trap,
    Monster
}
public class DungeonMenuSpawnLocation : MonoBehaviour
{
    public GameObject spawnLocation;
    public SpawnType spawnType;
    public TMP_Dropdown dropdown;

    public Vector2 GetSpawnLocation()
    {
        return Camera.main.ScreenToWorldPoint(spawnLocation.transform.position);
    }
}
