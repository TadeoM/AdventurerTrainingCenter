using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Entity target;

    public string entityName;
    public string description;

    [SerializeField] protected int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] protected int maxMana;
    [SerializeField] public int currentMana;
    [SerializeField] protected int armor;

    [SerializeField] protected int strength;
    [SerializeField] protected int dexterity;
    [SerializeField] protected int intelligence;

    [SerializeField] protected int baseMovemenSpeed;
    [SerializeField] public int currentMovementSpeed;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void UseMana(int manaUsed)
    {
        currentMana -= manaUsed;
    }

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth = strength;
        currentMovementSpeed = baseMovemenSpeed = dexterity;
        currentMana = maxMana = intelligence;
    }
}
