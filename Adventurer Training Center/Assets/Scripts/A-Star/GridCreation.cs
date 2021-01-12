using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridCreation : MonoBehaviour
{
    public Grid gridBase;
    public Tilemap floor;
    public List<Tilemap> obstacleLayers;
    public GameObject gridNode;
    public GameObject nodePrefab;

    public int scanStartX;
    public int scanStartY;
    public int scanFinishX;
    public int scanFinishY; 
    public int gridSizeX, gridSizeY;

    public List<GameObject> unsortedNodes;
    public GameObject[,] sortedNodes;
    private int gridBoundX = 0;
    private int gridBoundY = 0;

    private void Awake()
    {
        gridSizeX = Mathf.Abs(scanStartX) + Mathf.Abs(scanFinishX);
        gridSizeY = Mathf.Abs(scanStartY) + Mathf.Abs(scanFinishY);
        CreateGrid();
    }

    private void CreateGrid()
    {
        int gridX = 0, gridY = 0;
        bool foundTileOnLastPass = false;
        for (int x = scanStartX; x < scanFinishX; x++)
        {
            for (int y = scanStartY; y < scanFinishY; y++)
            {
                TileBase tb = floor.GetTile(new Vector3Int(x, y, 0));
                if (tb != null)
                {
                    bool foundObstacle = false;
                    foreach (Tilemap t in obstacleLayers)
                    {
                        TileBase tb2 = t.GetTile(new Vector3Int(x, y, 0));
                        if (tb2 != null) foundObstacle = true;
                    }

                    Vector3 worldPosition = new Vector3(x + 0.5f + gridBase.transform.position.x, y + 0.5f + gridBase.transform.position.y, 0);
                    GameObject node = (GameObject)Instantiate(nodePrefab, worldPosition, Quaternion.Euler(0, 0, 0));
                    Vector3Int cellPosition = floor.WorldToCell(worldPosition);
                    WorldTile wt = node.GetComponent<WorldTile>();
                    wt.gridX = gridX; 
                    wt.gridY = gridY; 
                    wt.cellX = cellPosition.x; 
                    wt.cellY = cellPosition.y;
                    node.transform.parent = gridNode.transform;

                    if (!foundObstacle)
                    {
                        foundTileOnLastPass = true;
                        node.name = "Walkable_" + gridX.ToString() + "_" + gridY.ToString();
                        wt.isWalkable = true;
                    }
                    else
                    {
                        foundTileOnLastPass = true;
                        node.name = "Unwalkable_" + gridX.ToString() + "_" + gridY.ToString();
                        wt.isWalkable = false;
                        node.GetComponent<SpriteRenderer>().color = Color.red;
                    }

                    unsortedNodes.Add(node);

                    gridY++;
                    if (gridX > gridBoundX)
                        gridBoundX = gridX;

                    if (gridY > gridBoundY)
                        gridBoundY = gridY;
                }
            }

            if (foundTileOnLastPass)
            {
                gridX++;
                gridY = 0;
                foundTileOnLastPass = false;
            }
        }
        sortedNodes = new GameObject[gridBoundX + 1, gridBoundY + 1];

        foreach (GameObject g in unsortedNodes)
        {
            WorldTile wt = g.GetComponent<WorldTile>();
            sortedNodes[wt.gridX, wt.gridY] = g;
        }

        for (int x = 0; x < gridBoundX; x++)
        {
            for (int y = 0; y < gridBoundY; y++)
            {
                if (sortedNodes[x, y] != null)
                {
                    WorldTile wt = sortedNodes[x, y].GetComponent<WorldTile>();
                    wt.neighbors = getNeighbours(x, y, gridBoundX, gridBoundY);
                }
            }
        }
    }

    public List<WorldTile> getNeighbours(int x, int y, int width, int height)
    {
        List<WorldTile> myNeighbours = new List<WorldTile>();

        if (x > 0 && x < width - 1)
        {
            if (y > 0 && y < height - 1)
            {
                if (sortedNodes[x + 1, y] != null)
                {
                    WorldTile wt1 = sortedNodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (sortedNodes[x - 1, y] != null)
                {
                    WorldTile wt2 = sortedNodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (sortedNodes[x, y + 1] != null)
                {
                    WorldTile wt3 = sortedNodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }

                if (sortedNodes[x, y - 1] != null)
                {
                    WorldTile wt4 = sortedNodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
            else if (y == 0)
            {
                if (sortedNodes[x + 1, y] != null)
                {
                    WorldTile wt1 = sortedNodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (sortedNodes[x - 1, y] != null)
                {
                    WorldTile wt2 = sortedNodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (sortedNodes[x, y + 1] == null)
                {
                    WorldTile wt3 = sortedNodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == height - 1)
            {
                if (sortedNodes[x, y - 1] != null)
                {
                    WorldTile wt4 = sortedNodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
                if (sortedNodes[x + 1, y] != null)
                {
                    WorldTile wt1 = sortedNodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (sortedNodes[x - 1, y] != null)
                {
                    WorldTile wt2 = sortedNodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }
            }
        }
        else if (x == 0)
        {
            if (y > 0 && y < height - 1)
            {
                if (sortedNodes[x + 1, y] != null)
                {
                    WorldTile wt1 = sortedNodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (sortedNodes[x, y - 1] != null)
                {
                    WorldTile wt4 = sortedNodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }

                if (sortedNodes[x, y + 1] != null)
                {
                    WorldTile wt3 = sortedNodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == 0)
            {
                if (sortedNodes[x + 1, y] != null)
                {
                    WorldTile wt1 = sortedNodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (sortedNodes[x, y + 1] != null)
                {
                    WorldTile wt3 = sortedNodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == height - 1)
            {
                if (sortedNodes[x + 1, y] != null)
                {
                    WorldTile wt1 = sortedNodes[x + 1, y].GetComponent<WorldTile>();
                    if (wt1 != null) myNeighbours.Add(wt1);
                }

                if (sortedNodes[x, y - 1] != null)
                {
                    WorldTile wt4 = sortedNodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
        }
        else if (x == width - 1)
        {
            if (y > 0 && y < height - 1)
            {
                if (sortedNodes[x - 1, y] != null)
                {
                    WorldTile wt2 = sortedNodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (sortedNodes[x, y + 1] != null)
                {
                    WorldTile wt3 = sortedNodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }

                if (sortedNodes[x, y - 1] != null)
                {
                    WorldTile wt4 = sortedNodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
            else if (y == 0)
            {
                if (sortedNodes[x - 1, y] != null)
                {
                    WorldTile wt2 = sortedNodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }
                if (sortedNodes[x, y + 1] != null)
                {
                    WorldTile wt3 = sortedNodes[x, y + 1].GetComponent<WorldTile>();
                    if (wt3 != null) myNeighbours.Add(wt3);
                }
            }
            else if (y == height - 1)
            {
                if (sortedNodes[x - 1, y] != null)
                {
                    WorldTile wt2 = sortedNodes[x - 1, y].GetComponent<WorldTile>();
                    if (wt2 != null) myNeighbours.Add(wt2);
                }

                if (sortedNodes[x, y - 1] != null)
                {
                    WorldTile wt4 = sortedNodes[x, y - 1].GetComponent<WorldTile>();
                    if (wt4 != null) myNeighbours.Add(wt4);
                }
            }
        }

        return myNeighbours;
    }

    public WorldTile GetWorldTileByCellPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = floor.WorldToCell(worldPosition);
        WorldTile wt = null;
        for (int x = 0; x < gridBoundX; x++)
        {
            for (int y = 0; y < gridBoundY; y++)
            {
                if (sortedNodes[x, y] != null)
                {
                    WorldTile _wt = sortedNodes[x, y].GetComponent<WorldTile>();

                    // we are interested in walkable cells only
                    if (_wt.isWalkable && _wt.cellX == cellPosition.x && _wt.cellY == cellPosition.y)
                    {
                        wt = _wt;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        return wt;
    }
}
