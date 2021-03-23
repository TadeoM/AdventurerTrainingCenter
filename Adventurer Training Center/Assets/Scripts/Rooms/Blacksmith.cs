using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : MonoBehaviour
{
    [SerializeField]
    private int currLevel;

    public int cost;

    public int chanceToCreateWeapons;

    public List<Weapon> weaponsAbleToProduce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
