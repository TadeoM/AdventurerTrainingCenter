using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroClass
{
    Ranger,
    Warrior,
    Mage
}

public class Entity : MonoBehaviour
{
    public Entity target;

    public string entityName;
    public string description;
    public HeroClass heroClass;

    [SerializeField] protected int strength;
    [SerializeField] protected int dexterity;
    [SerializeField] protected int intelligence;

    [SerializeField] protected int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] protected int maxMana;
    [SerializeField] public int currentMana;
    [SerializeField] protected int armor;

    [SerializeField] protected int baseMovemenSpeed;
    [SerializeField] public int currentMovementSpeed;

    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float dodgeChance;

    public void DealDamageToTarget(int damage)
    {
        target.TakeDamage(damage);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= (damage - armor);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void UseMana(int manaUsed)
    {
        currentMana -= manaUsed;
    }

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth = (strength * 4);
        currentMovementSpeed = baseMovemenSpeed = 2;
        currentMana = maxMana = intelligence;
    }

    public int Strength()
    {
        return strength;
    }
    public int Dexterity()
    {
        return dexterity;
    }
    public int Intelligence()
    {
        return intelligence;
    }
}
