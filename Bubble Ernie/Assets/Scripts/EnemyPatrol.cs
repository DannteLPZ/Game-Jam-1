using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 4f;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D enemyRb;

    private int waypointIndex = 0;
    
    void Update()
    {
        if (Vector2.Distance(waypoints[waypointIndex].transform.position, transform.position) < .1f)
        {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }


    }
}
