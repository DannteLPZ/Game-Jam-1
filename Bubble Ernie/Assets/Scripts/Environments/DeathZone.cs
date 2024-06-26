using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [SerializeField] private GameEvent gameOverEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameOverEvent.Invoke();
            AudioManager.Instance.Play("SFX_PlayerDied");
        }
    }
}
