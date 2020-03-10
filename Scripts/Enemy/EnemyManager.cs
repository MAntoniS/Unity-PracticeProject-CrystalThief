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

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = startWaitTime;
    }



    //Patrol
    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[0].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[0].position) < 0.2) { transform.position = transform.position; }
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
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
    }
    //Attack that has to be implemented by every Enemy in a different way
    public abstract void Attack();

}
