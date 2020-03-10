using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAttack : MonoBehaviour
{

    private bool isAttacking;
    [SerializeField]private float attackRange = 0.5f;
    private Player_Manager manager;
    public LayerMask enemyLayers;
    void Start()
    {
        manager = GetComponentInParent<Player_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            isAttacking = true;
        }
        
    }
    private void FixedUpdate()
    {
        Attack(isAttacking);
        isAttacking = false;
    }

    private void Attack(bool isAttacking)
    {
        if (isAttacking) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<Chomper>().TakeDamage();
            }
            manager.StaffAttack(isAttacking);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
}
