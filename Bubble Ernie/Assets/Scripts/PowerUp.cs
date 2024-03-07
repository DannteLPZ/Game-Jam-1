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
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;

    public void TakeIt()
    {
        if (type == PowerUpType.Speed)
        {
            StartCoroutine(SpeedPowerUp());
        }

        if (type == PowerUpType.Life)
        {
            if (playerController.CurrentHealth < 3)
            {
                playerController.CurrentHealth++;
                UpdateLife.Invoke();
            }
        }
        spriteRenderer.enabled = false;
        collider2d.enabled = false;
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
    }

    IEnumerator SpeedPowerUp()
    {
        float initSpeed = playerController.Speed;
        playerController.Speed += 5.0f;
        yield return new WaitForSeconds(3f);
        playerController.Speed = initSpeed;
    }
}
