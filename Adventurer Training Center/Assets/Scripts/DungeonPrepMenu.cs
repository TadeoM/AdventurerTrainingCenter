using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPrepMenu : MonoBehaviour
{
    // need to choose map
        // load the map chosen
            // a map should have slots to be filled with either a trap, or an enemy/enemy cluster
            // Create 
                // an array of [custom class] that has the following:
                    // Vector3 location
                    // Gameobject to spawn
                    // number of gameobject to spawn

    public GameObject mapToLoad;

    public void ChooseRegularMap()
    {
        mapToLoad = Resources.Load<GameObject>("Maps/Dungeon");
        Instantiate(mapToLoad);
        Destroy(gameObject);
    }
}
