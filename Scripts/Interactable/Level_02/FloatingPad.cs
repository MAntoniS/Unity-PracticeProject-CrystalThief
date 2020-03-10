using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPad : MonoBehaviour
{

    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed;
    [SerializeField] private int goal;

    private float waitTime;
    public float startWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        goal = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[goal].position, speed * Time.deltaTime);
        if (waitTime <= 0)
        {
            switch (goal) 
            {
                case 0:
                    goal = 1;
                    break;
                case 1:
                    goal = 0;
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
            waitTime = startWaitTime;

        }
        else { waitTime -= Time.deltaTime; }
    }
}
