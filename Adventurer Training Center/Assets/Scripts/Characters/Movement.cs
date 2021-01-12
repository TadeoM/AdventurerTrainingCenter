using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Entity entity;
    [SerializeField] private int viewRange;
    [SerializeField] private ContactFilter2D chasableTargets;
    private bool moveDone;
    private Vector3 lastDirection;
    [SerializeField] private Vector3 direction;

    public List<WorldTile> path;
    [SerializeField] List<WorldTile> reachedPathTiles = new List<WorldTile>(); // TODO: Change this to Vector3, entity just needs a location to go to, this way, we can fuck with the location they'll go


    void Start()
    {
        
    }

    void Update()
    {
        GetClosestPlayer();
        Move();
    }

    private void GetClosestPlayer()
    {
        List<RaycastHit2D> results = new List<RaycastHit2D>();
        int resultCount = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y), viewRange, Vector2.up, chasableTargets, results);

        float closestDistance = viewRange + 1;

        foreach (var possibleTarget in results)
        {
            float testDistance = Vector2.Distance(transform.position, possibleTarget.transform.position);

            if (testDistance < closestDistance)
            {
                entity.target = possibleTarget.transform.GetComponent<Entity>();
                closestDistance = testDistance;
            }
        }
    }

    void PerformMovement()
    {
        if (path != null)
        {
            if (path.Count > 1)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    if (reachedPathTiles.Contains(path[i])) continue;
                    else reachedPathTiles.Add(path[i]); break;
                }
                WorldTile wt = reachedPathTiles[reachedPathTiles.Count - 1];
            }
            else
            {
                direction = Vector2.zero;
            }
        }
    }
    void Move()
    {
        if(reachedPathTiles.Count > 0)
        {
            if (Vector3.Distance(transform.position, reachedPathTiles[reachedPathTiles.Count - 1].transform.position) <= .001f) {
                reachedPathTiles.RemoveAt(reachedPathTiles.Count - 1);
                PerformMovement();
            }
            else
            {
                Vector2 moveTo = Vector2.MoveTowards(transform.position, reachedPathTiles[reachedPathTiles.Count - 1].transform.position, (entity.currentMovementSpeed) * Time.deltaTime);
                transform.position = moveTo;
            }
        }
        else
        {
            PerformMovement();
        }
        
    }
}
