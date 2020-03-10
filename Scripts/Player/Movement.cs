using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Player_Manager manager;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private float mov;
    [SerializeField]
    private bool isRunning;
    private void Start()
    {
        manager = GetComponentInParent<Player_Manager>();
    }

    private void Update()
    {
        mov = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { isRunning = false; }
    }

    private void FixedUpdate()
    {
        manager.Movement(mov,isJumping,isRunning);
        isJumping = false;
    }


}
