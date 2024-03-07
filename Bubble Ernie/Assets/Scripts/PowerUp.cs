using System.Collections;
using Unity.VisualScripting;
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
    public void TakeIt()
    {
        Destroy(gameObject);
        if (type == PowerUpType.Speed)
           StartCoroutine(SpeedPowerUp());
        if (type == PowerUpType.Life)
            playerController.health++;
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
