using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBumble : MonoBehaviour
{
    private Rigidbody2D bumbleRb;
    // Start is called before the first frame update
    void Start()
    {
        bumbleRb = GetComponent<Rigidbody2D>();
        bumbleRb.AddForce(20.0f * transform.right, ForceMode2D.Impulse);
    }
}
