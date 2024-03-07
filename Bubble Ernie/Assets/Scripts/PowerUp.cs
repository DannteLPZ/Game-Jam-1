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
            if (playerController.health < 3)
            {
                playerController.health++;
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
        playerController.speed += 5;
        yield return new WaitForSeconds(5f);
        playerController.speed -= 5;
    }
}
