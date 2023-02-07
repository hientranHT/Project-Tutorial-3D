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

    //
    private Rigidbody rigidbody;
    //private Animator animator;

    //
    float horizontal;
    float vertical;
    float currentSpeed = 10.0f;
    Vector3 currentJump = new Vector3(0, 7.5f, 0);
    bool playerIsOnPlane = true;
    public Transform groundCheck;
    public LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();

        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();


        playerInputAction.Player.Movement.performed += onMovement;
        playerInputAction.Player.Movement.canceled += onMovement;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
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
