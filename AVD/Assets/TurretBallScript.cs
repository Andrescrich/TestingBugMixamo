using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TurretBallScript : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject sparkles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {    
        rb.AddForce(transform.forward * 5f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer != 8) return;
        rb.Sleep();
        var collisionPoint = other.contacts[0].point;
        Instantiate(turret, collisionPoint, turret.transform.rotation);
        Instantiate(sparkles, collisionPoint, sparkles.transform.rotation);
        Destroy(gameObject);
    }
}
