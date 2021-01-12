using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://pavcreations.com/tilemap-based-a-star-algorithm-implementation-in-unity-game/
 */

public class WorldTile : MonoBehaviour
{
    public int gCost;
    public int hCost;
    public int gridX, gridY, cellX, cellY;
    public bool isWalkable;
    public List<WorldTile> neighbors;
    public WorldTile parent;

    public WorldTile(bool walkable, int x, int y)
    {
        isWalkable = walkable; 
        gridX = x;
        gridY = y;
    }

    public int fCost{ get { return gCost + hCost; } }
}
