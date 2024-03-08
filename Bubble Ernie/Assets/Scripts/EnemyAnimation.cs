using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private const string DEATH = "Death";

    [Header("Orientation")]
    [SerializeField] private EnemyPatrol _enemyPatrol;
    [SerializeField] private BoxCollider2D boxTriggerCollider;
    [SerializeField] private SpriteRenderer sprite;

    [Header("Animation")]
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Color _deadColor;

    private void OnEnable() => _enemyPatrol.OnDeath += AnimateDeath;

    private void OnDisable() => _enemyPatrol.OnDeath -= AnimateDeath;

    private void AnimateDeath()
    {
        boxTriggerCollider.enabled = false;
        _enemyAnimator.SetTrigger(DEATH);
        sprite.color = _deadColor;
    }

    private void Update()
    {
        //Flip enemy sprite
        if (_enemyPatrol.movementDirection.x > 0)
        {
            sprite.flipX = true;
            boxTriggerCollider.offset = new Vector2(2.2f, boxTriggerCollider.offset.y);
        }
        else if (_enemyPatrol.movementDirection.x < 0)
        {
            sprite.flipX = false;
            boxTriggerCollider.offset = new Vector2(-2.2f, boxTriggerCollider.offset.y);
        }
    }
}
