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
    PlayerController playerController;
    [SerializeField] private GameEvent UpdateLife;

    public void TakeIt()
    {
        Destroy(gameObject);
        if (type == PowerUpType.Speed)
            StartCoroutine(SpeedPowerUp());
        if (type == PowerUpType.Life) { 
            if (playerController.CurrentHealth < 3)
            {
                playerController.CurrentHealth++;
                UpdateLife.Invoke();
            }
        }
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    IEnumerator SpeedPowerUp()
    {
        playerController.Speed += 5.0f;
        yield return new WaitForSeconds(5.0f);
        playerController.Speed -= 5.0f;
    }
}
