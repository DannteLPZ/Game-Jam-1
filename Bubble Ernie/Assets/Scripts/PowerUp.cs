using UnityEngine;

public enum PowerUpType
{
    Speed,
    Life
}

public class PowerUp : MonoBehaviour, IPickable
{
    public PowerUpType type;
    public void TakeIt()
    {
       Destroy(gameObject);
        if (type == PowerUpType.Speed)
            Debug.Log("add player speed");
        if (type == PowerUpType.Life)
            Debug.Log("Add player live");
    }   
}
