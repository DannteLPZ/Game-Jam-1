using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameEvent GameWinEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameWinEvent.Invoke();
            AudioManager.Instance.Stop("SFX_PlayerJump");
            AudioManager.Instance.Stop("SFX_PlayerRun");
            AudioManager.Instance.Stop("SFX_TimeOut");
            Time.timeScale = 0.0f;
        }
    }
}
