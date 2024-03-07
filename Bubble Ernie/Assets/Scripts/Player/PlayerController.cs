using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceJump;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundRadius;
    [SerializeField] private LayerMask _whatIsGround;
    
    private float horizontalInput;
    private bool isOnGround;
    private bool _wasOnGround;
    private bool _hasJumped;

    public int health;
    public float speed;

    private Rigidbody2D playerRigidBody;

    //DL : Added events for animation
    public event Action OnJumped;
    public event Action OnLanded;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        health = 3;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && _hasJumped == false)
            _hasJumped = true;
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.CircleCast(_groundCheck.position, _groundRadius, Vector2.down, _groundRadius, _whatIsGround);
        if (_wasOnGround == false && isOnGround == true)
        {
            OnLanded?.Invoke();
            _hasJumped = false;
        }
        _wasOnGround = isOnGround;
        PlayerMovements();
    }

    private void PlayerMovements()
    {
        if (_hasJumped == true && isOnGround == true)
        {
            playerRigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            OnJumped?.Invoke();
        }

        playerRigidBody.AddForce(Vector2.right * speed * horizontalInput);
    }
}
