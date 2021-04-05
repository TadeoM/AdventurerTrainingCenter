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
    private WorldTile prevTile;

    // animation data
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteObject;
    private bool facingLeft = true;
    private void Start()
    {
    }

    void FixedUpdate()
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
                    if (reachedPathTiles.Contains(path[i]))
                    {
                        continue;
                    }
                    else 
                    {
                        if (path[i].hasUnit == false)
                        {
                            reachedPathTiles.Add(path[i]);
                            path[i].hasUnit = true;
                            WorldTile wt = reachedPathTiles[reachedPathTiles.Count - 1];
                        }
                        break;
                    }
                }
            }
            else
            {
                direction = Vector2.zero;
            }
        }
    }
    public void Move()
    {
        if(reachedPathTiles.Count > 0)
        {
            if (Vector3.Distance(transform.position, reachedPathTiles[reachedPathTiles.Count - 1].transform.position) <= .001f) {
                if(path.Count > 1)
                {
                    reachedPathTiles[reachedPathTiles.Count - 1].hasUnit = false;
                }
                reachedPathTiles.RemoveAt(reachedPathTiles.Count - 1);
                PerformMovement();
            }
            else if(entity.Attacking != true)
            {
                Vector2 moveTo = Vector2.MoveTowards(transform.position, reachedPathTiles[reachedPathTiles.Count - 1].transform.position, (entity.currentMovementSpeed) * Time.deltaTime);
                transform.position = moveTo;
                entity.AnimationState = AnimationState.Walking;
            }
            AnimateEntity();
        }
        else
        {
            PerformMovement();
        }
    }
    private void AnimateEntity()
    {
        if (entity.Attacking == true)
        {
            Vector2 direction = Vector2.right;
            Vector2 posDiff = (entity.target.transform.position - transform.position).normalized;
            int val = Mathf.RoundToInt(Vector2.Dot(posDiff, direction));
            facingLeft = val < 0 ? true : false;
        }
        else
        {
            switch (entity.AnimationState)
            {
                case AnimationState.Walking:
                    Vector2 direction = Vector2.right;
                    Vector2 posDiff = (reachedPathTiles[reachedPathTiles.Count - 1].transform.position - transform.position).normalized;
                    int val = Mathf.RoundToInt(Vector2.Dot(posDiff, direction));
                    if(val != 0)
                    {
                        facingLeft = val < 0 ? true : false;
                    }
                    break;
                default:
                    break;
            }
        }
        spriteObject.flipX = facingLeft;
        //if((int)entity.AnimationState != animator.GetInteger())
        animator.SetInteger("AnimationState", (int)entity.AnimationState);
    }
}
