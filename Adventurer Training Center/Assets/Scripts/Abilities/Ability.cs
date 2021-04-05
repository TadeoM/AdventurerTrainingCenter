using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected Entity user;

    [SerializeField] protected float cooldownTime;
    [SerializeField] protected float range;
    [SerializeField] protected float castTime;
    [SerializeField] protected float duration;
    private float timerToIdleAnimation;
    
    protected enum AbilityState {  Idle, Casting, Executing, CooldingDown }
    private AbilityState abilityState;
    private Coroutine executeRoutine;
    private Coroutine cooldownRoutine;
    private Coroutine castAbilityRoutine;

    private void Awake()
    {
        user = GetComponentInParent<Entity>();
    }

    protected void UpdateState(AbilityState newState)
    {
        abilityState = newState;

        switch (abilityState)
        {
            case AbilityState.Idle:
                if(timerToIdleAnimation <= 0)
                {
                    user.Attacking = false;
                }
                else
                {
                    timerToIdleAnimation -= Time.deltaTime;
                }
                break;
            case AbilityState.Casting:
                user.Attacking = true;
                CastAbility();
                break;
            case AbilityState.Executing:
                ExecutingAbility();
                break;
            case AbilityState.CooldingDown:
                Cooldown();
                timerToIdleAnimation = 0.07f;
                break;
            default:
                break;
        }
    }

    protected virtual void Cooldown()
    {
        cooldownRoutine = StartCoroutine(CooldownCoroutine());

        IEnumerator CooldownCoroutine()
        {
            float cd = cooldownTime;
            while(cd > 0)
            {
                cd -= Time.deltaTime;
                yield return null;
            }
            UpdateState(AbilityState.Idle);
            cooldownRoutine = null;
        }
    }

    protected abstract void ExecutingAbility();

    protected abstract void CastAbility();

    public bool IsReady()
    {
        return abilityState == AbilityState.Idle;
    }
    public bool IsInRange()
    {
        float distance = Vector2.Distance(user.transform.position, user.target.transform.position);
        return distance <= range;
    }
    public bool IsReadyAndInRange()
    {
        return IsReady() && IsInRange();
    }

    public void SetToCasting()
    {
        UpdateState(AbilityState.Casting);
    }
}
