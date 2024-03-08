using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform wayPoint1, wayPoint2;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private Vector3 targetWayPoint;

    private BoxCollider2D _enemyCollider;

    public Vector3 movementDirection;

    public event Action OnDeath;

    private void Start()
    {
        _enemyCollider = GetComponent<BoxCollider2D>();
        targetWayPoint = wayPoint1.position;
        CalculateAndMoveDirection();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, targetWayPoint) < .1f)
        {
            targetWayPoint = targetWayPoint == wayPoint1.position ? wayPoint2.position : wayPoint1.position;   
        }
    }

    private void FixedUpdate()
    {
        CalculateAndMoveDirection();
    }

    private void CalculateAndMoveDirection()
    {
        //Calculate direction
        movementDirection = (targetWayPoint - transform.position).normalized;
        
        //Apply movement to direction
        enemyRb.velocity = movementDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile") == true)
        {
            enemyRb.velocity = Vector2.zero;
            enemyRb.gravityScale = 0.0f;
            _enemyCollider.enabled = false;
            OnDeath?.Invoke();
            Destroy(collision.gameObject);
            enabled = false;
        }else if (collision.CompareTag("Player"))
        {
            speed = 10.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = 4.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.TryGetComponent(out Rigidbody2D playerRb);
            if(playerRb != null)
            {
                Vector2 normal = collision.contacts[0].normal;
                playerRb.AddForce(-10.0f * normal, ForceMode2D.Impulse);
            }
            collision.collider.TryGetComponent(out PlayerHealth player);
            if(player != null)
            {
                player.Heal(-1);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawLine(wayPoint1.position, wayPoint2.position);
    }
}
