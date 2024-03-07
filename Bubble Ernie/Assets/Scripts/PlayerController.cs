using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private float horizontalInput;
    public bool isOnGround = true;
    private Rigidbody2D playerRigidBody;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovements();
    }

    private void PlayerMovements()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //isOnGround = false;
            Debug.Log("VERTICAL");
            playerRigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            // TODO(Johny): handle the jump
            Debug.Log("HORIZONTAL");
            playerRigidBody.AddForce(Vector2.right * speed * horizontalInput);
            //transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
            //playerRigidBody.velocity = new Vector2(horizontalInput, playerRigidBody.velocity.y);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    // TODO(Johny): implement the next methods 

    //private void OnPowerup()
    //{

    //}

    //private void OnChangeWeapon()
    //{

    //}

}
