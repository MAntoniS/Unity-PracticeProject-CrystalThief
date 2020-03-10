using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour
{
    private Transform[] wayPoints;
    private float speed;
    private int random;
    private float waitTime;
    private float startWaitTime;
    private Transform playerPosition;

    public EnemyManager(Transform[] points, float speed, float startTime) 
    {
        this.wayPoints = points;
        this.speed = speed;
        this.startWaitTime =startTime;
    }

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = startWaitTime;
        random = Random.Range(0, wayPoints.Length);
    }



    //Patrol
    void Patrol()
    {
        if (Vector2.Distance(transform.position, wayPoints[random].position) < 0.2)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[random].position, speed * Time.deltaTime);
        }

        if (waitTime <= 0)
        {
            random = Random.Range(0, wayPoints.Length);
            waitTime = startWaitTime;

        }
        else { waitTime -= Time.deltaTime; }
    }

    //Move towards the player
    void MoveToPlayer()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) < 0.2)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        }   
        }

    public void Die() 
    {
        Destroy(this.gameObject);
    }
    //Attack that has to be implemented by every Enemy in a different way
    public abstract void Attack();
    public abstract void TakeDamage();


}
