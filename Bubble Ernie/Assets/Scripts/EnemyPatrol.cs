using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform wayPoint1, wayPoint2;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D boxTriggerCollider;

    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private Vector3 targetWayPoint;

    private void Start()
    {
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

        //Run animator?
        
        //Flip enemy sprite
        if(movementDirection.x > 0)
        {
            sprite.flipX = true;
            boxTriggerCollider.offset = new Vector2(2.2f, boxTriggerCollider.offset.y);
        }
        else if(movementDirection.x < 0) 
        { 
            sprite.flipX = false;
            boxTriggerCollider.offset = new Vector2(-2.2f, boxTriggerCollider.offset.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = 10f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = 4f;
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
