using System;
using System.Security.Cryptography;
using UnityEngine;

public class TurretBulletScript : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject sparkles;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        rb.AddForce(transform.up * 20f, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer != 16) return;
        var collisionPoint = other.contacts[0].point;
        rb.Sleep();
        anim.SetTrigger("Die");
    }
}
