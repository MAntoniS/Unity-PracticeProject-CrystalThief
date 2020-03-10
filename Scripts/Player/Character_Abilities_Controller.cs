using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Abilities_Controller : MonoBehaviour
{
    [SerializeField]private int crystals;
    [SerializeField]private bool canUseAbility;
    [SerializeField] private SpecialAbility ability;



    private void Start()
    {
        crystals = 0;
        canUseAbility = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            canUseAbility = true;
        }
        
    }
    private void FixedUpdate()
    {
        if (canUseAbility)
        {
            UseSpecialAbililty(ability);
            canUseAbility = false;
        }
        
    }

    public void AddCrystal()
    {
        crystals++;
    }
    public void UseSpecialAbililty(SpecialAbility ability) 
    {
        crystals -= ability.getCost(); ;
        ability.useAbility();
    }
}
