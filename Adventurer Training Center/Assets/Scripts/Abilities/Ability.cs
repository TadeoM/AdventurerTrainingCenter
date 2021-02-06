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
                break;
            case AbilityState.Casting:
                CastAbility();
                break;
            case AbilityState.Executing:
                ExecutingAbility();
                break;
            case AbilityState.CooldingDown:
                Cooldown();
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
