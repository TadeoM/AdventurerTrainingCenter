using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    Idle,
    Walking
}

public class Entity : MonoBehaviour
{
    public Entity target;

    public string entityName;
    public string description;
    public int level;

    [SerializeField] protected float strength;
    [SerializeField] protected float dexterity;
    [SerializeField] protected float intelligence;

    [SerializeField] protected int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] protected int maxMana;
    [SerializeField] public int currentMana;
    [SerializeField] protected int armor;

    [SerializeField] protected int baseMovemenSpeed;
    [SerializeField] public int currentMovementSpeed;

    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float dodgeChance;

    protected AnimationState animationState;
    [SerializeField] private bool attacking;

    public bool Attacking
    {
        get { return attacking; }
        set { attacking = value; }
    }


    public AnimationState AnimationState
    {
        get { return animationState; }
        set { animationState = value; }
    }


    public void DealDamageToTarget(float damage)
    {
        target.TakeDamage(damage);
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= (int)(damage - armor);
        if(currentHealth <= 0)
        {
            //Destroy(gameObject);
        }
    }

    public void UseMana(int manaUsed)
    {
        currentMana -= manaUsed;
    }

    public virtual Entity Init()
    {
        InitStats();
        return this;
    }

    public virtual Entity Init(Entity entity)
    {
        level = entity.level;
        entityName = entity.name;
        strength = entity.strength;
        dexterity = entity.dexterity;
        intelligence = entity.intelligence;
        InitStats();
        return this;
    }

    public virtual void InitStats()
    {
        currentHealth = maxHealth = (int)(strength * 10);
        currentMovementSpeed = baseMovemenSpeed = 2;
        currentMana = maxMana = (int)(intelligence * 10);
    }

    public float Strength()
    {
        return strength;
    }
    public float Dexterity()
    {
        return dexterity;
    }
    public float Intelligence()
    {
        return intelligence;
    }

    public void SetStrength(int val)
    {
        strength += val;
    }
    public void SetDexterity(int val)
    {
        dexterity += val;
    }
    public void SetIntelligence(int val)
    {
        intelligence += val;
    }


    public virtual string GetImagePath()
    {
        return "";
    }
}
