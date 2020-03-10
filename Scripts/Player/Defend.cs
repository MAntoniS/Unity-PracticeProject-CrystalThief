using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    [SerializeField]
    private bool isDefending;
    private Player_Manager manager;

    private void Start()
    {
        manager = GetComponentInParent<Player_Manager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            isDefending = true;
        }
    }

    private void FixedUpdate()
    {
        manager.Defend(isDefending, transform);
        isDefending = false;
       
    }


}
