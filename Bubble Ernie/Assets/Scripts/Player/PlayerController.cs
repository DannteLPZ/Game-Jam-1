using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } set {  _speed = value; } }

    [Header("Jumping")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private float _horizontalInput;
    private bool isOnGround;
    private bool _wasOnGround;
    private bool _hasJumped;


    private Rigidbody2D _playerRigidBody;

    //DL : Added events for animation
    public event Action OnJumped;
    public event Action OnLanded;

    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) == true && _hasJumped == false)
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
            _playerRigidBody.AddForce(Vector2.up * (_jumpForce - _playerRigidBody.velocity.y), ForceMode2D.Impulse);
            OnJumped?.Invoke();
        }
        float horizontalForce = (_speed * _horizontalInput) - _playerRigidBody.velocity.x;
        _playerRigidBody.AddForce(horizontalForce * Vector2.right);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }
}
