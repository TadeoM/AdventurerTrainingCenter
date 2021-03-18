using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    private void Start()
    {
        cooldownTime = 2.0f / user.Dexterity();
    }

    protected override void CastAbility()
    {
        UpdateState(AbilityState.Executing);
    }
    
    protected override void ExecutingAbility()
    {
        if (user.target != null)
        {
            float damage = user.Strength();
            user.DealDamageToTarget(damage);
            UpdateState(AbilityState.CooldingDown);
        }
        else
        {
            Debug.Log("Can't attack because there is no target");
        }
    }
}
