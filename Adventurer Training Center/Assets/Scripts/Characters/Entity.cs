using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroClass
{
    Ranger,
    Warrior,
    Mage
}
public enum AnimationState
{
    Idle,
    Walking,
    Attack
}
public struct Hero
{
    public int level;
    public string name;
    public HeroClass heroClass;
    public Hero(Entity entity)
    {
        level = entity.level;
        name = entity.name;
        heroClass = entity.heroClass;
    }
}
public class Entity : MonoBehaviour
{
    public Entity target;

    public string entityName;
    public string description;
    public HeroClass heroClass;
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

    public Entity Init()
    {
        switch (heroClass)
        {
            case HeroClass.Ranger:
                strength = 1;
                dexterity = 3;
                intelligence = 2;
                break;
            case HeroClass.Warrior:
                strength = 3;
                dexterity = 2;
                intelligence = 1;
                break;
            case HeroClass.Mage:
                strength = 1;
                dexterity = 2;
                intelligence = 3;
                break;
            default:
                break;
        }

        InitStats();
        return this;
    }

    public Entity Init(Hero hero)
    {
        level = hero.level;
        heroClass = hero.heroClass;
        entityName = hero.name;
        return Init();
    }
    public Entity Init(Entity entity)
    {
        level = entity.level;
        heroClass = entity.heroClass;
        entityName = entity.name;
        strength = entity.strength;
        dexterity = entity.dexterity;
        intelligence = entity.intelligence;
        InitStats();
        return this;
    }

    public void InitStats()
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


    public string GetImagePath()
    {
        switch (heroClass)
        {
            case HeroClass.Ranger:
                return "FlowerElf";
            case HeroClass.Warrior:
                return "OrangeKnight";
            case HeroClass.Mage:
                return "Wizard";
            default:
                return "";
        }
    }
}
