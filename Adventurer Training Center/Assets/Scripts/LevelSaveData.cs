using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelSaveData : MonoBehaviour
{
    public Tilemap tilemap;
    private GridLayout gridLayout;
    public TileData tileData;
    public Tile tile;

    // TODO: we want to save the static things first, IE walls, decor, floor
    // TODO: when the app goes to foreground we want to save the entity positions and trap positions

    private void Start()
    {
        gridLayout = GetComponent<GridLayout>();

        Debug.Log(tilemap.size);
    }
}
