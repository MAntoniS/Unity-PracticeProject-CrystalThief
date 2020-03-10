using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    [SerializeField] private int abilityCost;


    public void useAbility()
    {
        Debug.Log("Ability used");
    }
    public int getCost() 
    {
        return abilityCost;
    }
}
