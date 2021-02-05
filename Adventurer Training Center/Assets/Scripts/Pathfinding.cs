using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public GridCreation grid;
    public GameObject enemyList;
    public Movement[] enemies;
    public GameObject heroList;
    public Movement[] heroes;

    private void Start()
    {
        grid = GetComponent<GridCreation>();
        enemies = enemyList.GetComponentsInChildren<Movement>();
        heroes = heroList.GetComponentsInChildren<Movement>();
    }

    public void SetSpawnedEnemyParents()
    {
        var allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in allEnemies)
        {
            enemy.transform.parent = enemyList.transform;
        }

        var allHeroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (var hero in allHeroes)
        {
            hero.transform.parent = heroList.transform;
        }
    }
    private void Update()
    {
        foreach (var enemy in enemies)
        {
            if(enemy.entity.target != null)
            {
                enemy.path = FindPath(enemy.transform.position, enemy.entity.target.transform.position);
            }
        }
        foreach (var hero in heroes)    
        {
            if(hero.entity.target != null)
            {
                hero.path = FindPath(hero.transform.position, hero.entity.target.transform.position);
            }
        }
    }

    public List<WorldTile> FindPath(Vector3 startPosition, Vector3 endPosition)
    {
        WorldTile startNode = grid.GetWorldTileByCellPosition(startPosition);
        WorldTile targetNode = grid.GetWorldTileByCellPosition(endPosition);

        List<WorldTile> openSet = new List<WorldTile>();
        HashSet<WorldTile> closedSet = new HashSet<WorldTile>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            WorldTile currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            foreach (WorldTile neighbour in currentNode.neighbors)
            {
                if (!neighbour.isWalkable || closedSet.Contains(neighbour)) continue;

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                }
            }
        }

        return null;
    }

    public int GetDistance(WorldTile nodeA, WorldTile nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }

    public List<WorldTile> RetracePath(WorldTile startNode, WorldTile targetNode)
    {
        List<WorldTile> path = new List<WorldTile>();
        WorldTile currentNode = targetNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }
}
