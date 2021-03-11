using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ArmouryUpgrade", menuName = "ScriptableObjects/Create Armoury Upgrade", order = 2)]
public class ArmouryUpgrade : FacilityUpgrade
{
    [SerializeField] protected int strength;
    [SerializeField] protected int dexterity;
    [SerializeField] protected int intelligence;

    public ArmouryUpgrade(string un, string ud, Sprite ut, bool sr, Vector3 sl) : base(un, ud, ut, sr, sl)
    {

    }
}
