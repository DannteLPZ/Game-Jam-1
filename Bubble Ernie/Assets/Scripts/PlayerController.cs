using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private float horizontalInput;
    public bool isOnGround = true;
    private Rigidbody2D playerRigidBody;
    public int health;

    

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        health = 3;
    }

    void Update()
    {
        PlayerMovements();
    }

    private void PlayerMovements()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            playerRigidBody.AddForce(Vector2.right * speed * horizontalInput);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
