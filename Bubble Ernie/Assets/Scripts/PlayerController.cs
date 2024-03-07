using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private float horizontalInput;
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
            Debug.Log("VERTICAL");
            playerRigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            // TODO(Johny): handle the jump
            Debug.Log("HORIZONTAL");
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
            //playerRigidBody.velocity = new Vector2(horizontalInput, playerRigidBody.velocity.y);
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
