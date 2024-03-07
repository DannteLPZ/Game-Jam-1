using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string VELOCITY_X = "VelocityX";
    private const string VELOCITY_Y = "VelocityY";
    private const string JUMP = "Jump";
    private const string LANDED = "Landed";
    private const string SHOT = "Shot";
    private const string DEATH = "Jump";

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerShooter _playerShooter;
    [SerializeField] private Rigidbody _playerRb;

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
        _playerAnimator.SetFloat(VELOCITY_X, _playerRb.velocity.x);
        _playerAnimator.SetFloat(VELOCITY_Y, _playerRb.velocity.y);
    }

    private void AnimateJump() => _playerAnimator.SetTrigger(JUMP);
    private void AnimateLand() => _playerAnimator.SetTrigger(LANDED);
    private void AnimateShot() => _playerAnimator.SetTrigger(SHOT);

    public void AnimateDeath() => _playerAnimator.SetBool(DEATH, true);
}
