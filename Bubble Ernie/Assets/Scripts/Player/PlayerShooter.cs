using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float firingRate;
    private float firingTimer;
    //DL : Added events for animation
    public event Action OnShot;

    private void Start()
    {
        firingTimer = 1.0f / firingRate;
    }

    private void Update()
    {
        firingTimer -= Time.deltaTime;
        if ( firingTimer < 0.0f )
        {
            firingTimer = 0.0f;
        }
        if (Input.GetMouseButtonDown(0) && firingTimer == 0.0f)
        {
            OnShot?.Invoke();
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Destroy(projectile, 2.0f);
            firingTimer = 1.0f / firingRate;
        }
    }
}
