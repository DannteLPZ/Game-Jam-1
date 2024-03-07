using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //Animator parameter constants
    private const string VELOCITY_X = "VelocityX";
    private const string VELOCITY_Y = "VelocityY";
    private const string JUMPED = "Jumped";
    private const string LANDED = "Landed";
    private const string SHOT = "Shot";
    private const string DEATH = "Death";

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerShooter _playerShooter;
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Animator _playerAnimator;

    private void Start() => _playerAnimator = GetComponent<Animator>();

    private void OnEnable()
    {
        _playerController.OnJumped += AnimateJump;
        _playerController.OnLanded += AnimateLand;
        _playerShooter.OnShot += AnimateShot;
    }

    private void OnDisable()
    {
        _playerController.OnJumped -= AnimateJump;
        _playerController.OnLanded -= AnimateLand;
        _playerShooter.OnShot -= AnimateShot;
    }
    private void Update()
    {
        _playerAnimator.SetFloat(VELOCITY_X, Mathf.Abs(_playerRb.velocity.x));
        _playerAnimator.SetFloat(VELOCITY_Y, _playerRb.velocity.y);
        if (_playerRb.velocity.x > 0.1f) transform.parent.localEulerAngles = 180.0f * Vector2.up;
        else if (_playerRb.velocity.x < -0.1f) transform.parent.localEulerAngles = Vector2.zero; ;
    }

    private void AnimateJump() => _playerAnimator.SetTrigger(JUMPED);
    private void AnimateLand() => _playerAnimator.SetTrigger(LANDED);
    private void AnimateShot() => _playerAnimator.SetTrigger(SHOT);

    public void AnimateDeath() => _playerAnimator.SetBool(DEATH, true);
}
