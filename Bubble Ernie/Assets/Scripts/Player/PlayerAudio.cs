using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerShooter _playerShooter;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Rigidbody2D _playerRb;

    private bool _isPlayingSteps;
    private void OnEnable()
    {
        _playerController.OnJumped += JumpSound;
        _playerController.OnLanded += LandSound;
        _playerShooter.OnShot += ShotSound;
        _playerHealth.OnDamaged += HitSound;
        _playerHealth.OnHealed += HealSound;
        _playerHealth.OnDeath += DeathSound;
    }

    private void OnDisable()
    {
        _playerController.OnJumped -= JumpSound;
        _playerController.OnLanded -= LandSound;
        _playerShooter.OnShot -= ShotSound;
        _playerHealth.OnDamaged -= HitSound;
        _playerHealth.OnHealed -= HealSound;
        _playerHealth.OnDeath -= DeathSound;
    }

    private void JumpSound() => AudioManager.Instance.Play("SFX_PlayerJump");
    private void LandSound() => AudioManager.Instance.Play("SFX_PlayerLand");
    private void ShotSound() => AudioManager.Instance.Play("SFX_PlayerShot");
    private void HitSound() => AudioManager.Instance.Play("SFX_PlayerHit");
    private void HealSound() => AudioManager.Instance.Play("SFX_PlayerHeal");
    private void DeathSound() => AudioManager.Instance.Play("SFX_PlayerDied");
}
