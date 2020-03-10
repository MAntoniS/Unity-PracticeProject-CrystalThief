using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player_Manager : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool groundCheck;
    private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    private Vector3 m_Velocity = Vector3.zero;
    public float jumpForce = 190f;
    public float movSpeed = 5f;
    public SpriteRenderer flip;
    [SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.

    public Animator animator;
    public Transform shieldPrefab;
    public bool isFacingRight = true;
    private bool m_Grounded;            // Whether or not the player is grounded.
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded



    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Movement(float mov, bool isJumping, bool isRunning)
    {

        Vector3 targetVelocity;

        if (isRunning && mov!=0)
        {
            animator.SetBool("IsRunning",true);
            targetVelocity =  new Vector2(mov * movSpeed *2, rb.velocity.y);
        }
        else
        {
            animator.SetFloat("Movement", Mathf.Abs(mov));
            targetVelocity  = new Vector2(mov * movSpeed, rb.velocity.y);
            animator.SetBool("IsRunning", false);

        }
        if (mov > 0 && !isFacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (mov < 0 && isFacingRight)
        {
            // ... flip the player.
            Flip();
        }


        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (m_Grounded && isJumping)
        {
            animator.SetBool("IsJumping",true);
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("Player is Jumping");

        }

    }

    public void Defend(bool defend, Transform spawnPoint)
    {
        if (defend) {
            animator.SetTrigger("Defend");
            Instantiate(shieldPrefab, spawnPoint.position, Quaternion.identity);
        }
        }

    public void StaffAttack(bool IsAttacking)
    {
        if (IsAttacking)
        {
            animator.SetTrigger("Staff");
        }
       

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
      
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

}
