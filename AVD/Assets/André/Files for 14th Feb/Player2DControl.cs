using System;
using Cinemachine;
using UnityEngine;

public class Player2DControl : MonoBehaviour
{
    public float speed = 20f;
    private float horizontalMove;
    private bool jump;
    private bool crouch;
    private CharacterController2D controller;
    private Animator anim;
    public GameObject bullet;
    public Transform shootPoint;
    private CinemachineImpulseSource cis;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        cis = GetComponent<CinemachineImpulseSource>();
    }
    
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        anim.SetFloat("Speed", Math.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Crouch"))
            crouch = true;
        else
            crouch = false;
        
        if(Input.GetButtonDown("Fire1"))
            Fire();
    }

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }
    
    public void OnCrouching(bool isCrouching) {
        anim.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void Fire()
    {
        cis.GenerateImpulse(Vector2.right);
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
