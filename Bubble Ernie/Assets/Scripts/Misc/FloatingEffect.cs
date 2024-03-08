using UnityEngine;

public class FloatingEffect: MonoBehaviour
{
    public float floatStrength = .2f; 
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + new Vector2(0, Mathf.Sin(Time.time) * floatStrength);
    }
}
