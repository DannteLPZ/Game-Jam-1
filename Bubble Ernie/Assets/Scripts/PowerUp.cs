using System.Collections;
using UnityEngine;

public enum PowerUpType
{
    Speed,
    Life
}


public class PowerUp : MonoBehaviour, IPickable
{
    public PowerUpType type;
    PlayerHealth playerHealth;
    PlayerController playerController;
    [SerializeField] private GameEvent UpdateLife;

    public void TakeIt()
    {
        Destroy(gameObject);
        if (type == PowerUpType.Speed)
            StartCoroutine(SpeedPowerUp());
        if (type == PowerUpType.Life) { 
            if (playerHealth.CurrentHealth < 3)
            {
                playerHealth.Heal(1);
                UpdateLife.Invoke();
            }
        }
    }

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerController = FindObjectOfType<PlayerController>();
    }

    IEnumerator SpeedPowerUp()
    {
        playerController.Speed += 5.0f;
        yield return new WaitForSeconds(5.0f);
        playerController.Speed -= 5.0f;
    }
}
