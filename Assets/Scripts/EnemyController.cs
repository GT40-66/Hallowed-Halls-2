using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float enemySpeed;
    public int goombaDamage = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        Vector2 point = currentPoint.position - transform.position; 
        if (currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(enemySpeed, 0); // if the enemy is at pointB which is on the right, apply movement in positive x
        }
        else
        {
            rb.velocity = new Vector2(-enemySpeed, 0);// if the enemy is at a point other pointB which is on the right, apply movement in negative x
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform) // when the enemy reaches the gameobject of pointB, set currentpoint to A
        {
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            currentPoint = PointB.transform;
        }
    }
}
