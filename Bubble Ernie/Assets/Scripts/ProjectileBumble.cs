using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBumble : MonoBehaviour
{
    [SerializeField] private float _firingForce;
    [SerializeField] private GameObject _particleSystem;
    private Rigidbody2D _bumbleRb;
    // Start is called before the first frame update
    void Start()
    {
        _bumbleRb = GetComponent<Rigidbody2D>();
        _bumbleRb.AddForce(_firingForce * transform.right, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        GameObject particles = Instantiate(_particleSystem, transform.position, transform.rotation);
        Destroy(particles, 0.5f);
        Destroy(gameObject);
    }
}
