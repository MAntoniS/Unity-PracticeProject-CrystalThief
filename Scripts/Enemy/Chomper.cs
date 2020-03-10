using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    [SerializeField] private int maxhealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] movePoints;
    private Transform player;
    private Transform temp;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private bool isAttacking;
    
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private int random;

    private float waitTime;
    public float startWaitTime = 4f;
    
    private void Start()
    {
        waitTime = startWaitTime;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        random = Random.Range(0,movePoints.Length);
        currentHealth = maxhealth;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position,player.position) < 5) 
        { temp = player; }
        else
        { temp = movePoints[random]; }

        if (Time.time >= nextAttackTime)
        {
            if (Vector2.Distance(transform.position, player.position) < 5)
            {
                isAttacking = true;
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void FixedUpdate()
    {
        Patrol(temp);
        Attack();
        isAttacking = false;
    }

   
    void Patrol(Transform goal) 
    {
        transform.position = Vector2.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goal.position) <0.2) { transform.position = transform.position; }
          if(waitTime <= 0)
        {
            random = Random.Range(0, movePoints.Length);
            waitTime = startWaitTime;

        } else { waitTime -= Time.deltaTime; }
    }

    public void TakeDamage()
    {
        currentHealth -= 20;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die() 
    {
        Destroy(this.gameObject);
    }


    private void Attack()
    {
        
            if (isAttacking)
            {
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, playerMask);

                foreach (Collider2D player in hitEnemies)
                {
                    Debug.Log("We hit " + player.name);
                    player.GetComponent<Chomper>().TakeDamage();
                }
              
            }
        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
