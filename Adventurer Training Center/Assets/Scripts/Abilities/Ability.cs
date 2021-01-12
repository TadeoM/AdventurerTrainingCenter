using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    private Entity user;

    [SerializeField] protected float coolDownTime = 1f;
    [SerializeField] protected float castTime = 0f;
    [SerializeField] protected float damage = 1f;
    protected enum AbilityState {  Idle, Casting, Executing, CooldingDown }
    private AbilityState abilityState;
    private Coroutine executeRoutine;
    private Coroutine cooldDownRoutine;
    private Coroutine castAbilityRoutine;

    private void Cooldown()
    {
        
    }
}
