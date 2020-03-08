using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 6f;

    public float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    private float speedSmoothVelocity;
    private float currentSpeed;

    private Animator anim;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        var inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            var targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref
                                        turnSmoothVelocity, turnSmoothTime);
        }

        var running = Input.GetKey(KeyCode.LeftShift);
        var targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(targetSpeed * Time.deltaTime * transform.forward, Space.World);

        var animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        anim.SetFloat(Speed, animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }
}
    
