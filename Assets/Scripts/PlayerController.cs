using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //
    public PlayerInputAction playerInputAction;
    public Joystick joystick;
    Vector3 currenInput;
    public GameObject projectilePrelab;

    //
    private Rigidbody rigidbody;
    //private Animator animator;

    //
    float horizontal;
    float vertical;
    float currentSpeed = 10.0f;
    Vector3 currentJump = new Vector3(0, 7.5f, 0);
    public Transform groundCheck;
    public LayerMask ground;
    Vector3 lookDirection = new Vector3(0, 0, 1);
    //public float maxProjectile = 1;
    //private float currentProjectile = 0;

    public float timeInvincible = 2.0f;

    bool isInvincible;

    float invincibleTimer;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();

        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();


        playerInputAction.Player.Movement.performed += onMovement;
        playerInputAction.Player.Movement.canceled += onMovement;
        playerInputAction.Player.Shoot.performed += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x = position.x + currentSpeed * horizontal * Time.deltaTime;
        //position.y = position.y + currentSpeed * vertical * Time.deltaTime;
        position.z = position.z + currentSpeed * vertical * Time.deltaTime;
        //rigidbody.MovePosition(position);
        transform.position = position;


        //animator.SetTrigger("Walk");

        //Vector3 move = new Vector3(horizontal, vertical);

        //if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f) || !Mathf.Approximately(move.z, 0.0f))
        //{
        //    lookDirection.Set(move.x, move.y, move.z);
        //    lookDirection.Normalize();
        //}
    }

    private void onMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currenInput = context.ReadValue<Vector2>();
        }

        if (context.canceled)
        {
            currenInput = Vector2.zero;
        }
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (isInvincible)
        {
            return;
        }
        isInvincible = true;
        invincibleTimer = timeInvincible;

        GameObject projectileObject = Instantiate(projectilePrelab, rigidbody.position + new Vector3(0,0,1) * 2f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300f, timeInvincible);
    }

    public void Jump()
    {
        if(IsGrounded())
        {
            rigidbody.AddForce(currentJump, ForceMode.Impulse);
        }
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
   
}
