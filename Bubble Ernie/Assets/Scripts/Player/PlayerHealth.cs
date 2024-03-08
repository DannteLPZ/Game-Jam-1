using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _maxHealth;

    [SerializeField] private GameEvent healEvent;
    [SerializeField] private GameEvent gameLoseEvent;

    private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    public event Action OnDamaged;
    public event Action OnHealed;
    public event Action OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        if(amount < 0) OnDamaged?.Invoke();
        if (amount > 0) OnHealed?.Invoke();
        healEvent.Invoke();
        if(_currentHealth < 1)
        {
            AudioManager.Instance.Stop("SFX_PlayerJump");
            AudioManager.Instance.Stop("SFX_PlayerRun");
            Time.timeScale = 0.0f;
            OnDeath?.Invoke();
            StartCoroutine(GameLoseEvent());
        }
    }

    private IEnumerator GameLoseEvent()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        gameLoseEvent.Invoke();
    }
}
