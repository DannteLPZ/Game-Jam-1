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
        if (type == PowerUpType.Speed)
        {
            AudioManager.Instance.Play("SFX_Powerup");
            transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(SpeedPowerUp());
        }
        if (type == PowerUpType.Life) { 
            if (playerHealth.CurrentHealth < 3)
            {
                playerHealth.Heal(1);
                UpdateLife.Invoke();
                Destroy(gameObject);
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
        playerController.Speed += 8.0f;
        yield return new WaitForSeconds(10.0f);
        playerController.Speed -= 8.0f;
        Destroy(gameObject);
    }
}
