using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    [SerializeField] private Entity entity;
    [SerializeField] private Ability[] abilities; // from highest priority to lowest priority

    // Update is called once per frame
    void FixedUpdate()
    {
        if(entity.target != null)
        {
            for (int i = 0; i < abilities.Length; i++)
            {
                if (abilities[i].IsReadyAndInRange())
                {
                    abilities[i].SetToCasting();
                    break;
                }
            }
        }
    }
}
