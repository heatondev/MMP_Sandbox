using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{

    public Rigidbody sphereRB;
    float moveInput;

    InputActions playerInput;

    Vector2 currentMovementInput;
    Vector3 currentMovement;

    Vector2 movementVector;

    public float forwardSpeed;
    public float reverseSpeed;

    public float turnSpeed;
    bool isBoostPressed;
    public float boostAmount = 5f;

    public float airDrag;
    public float groundDrag;

    bool isCarGrounded;
    public LayerMask groundLayer;

    private void Awake()
    {
        playerInput = new InputActions();

        playerInput.Player.Jump.started += OnJump;
       playerInput.Player.Jump.canceled += OnJump;

    }
    void Start()
    {
        sphereRB.transform.parent = null; 
    }
    private void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
        currentMovement.x = movementVector.x;
        currentMovement.z = movementVector.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        isBoostPressed = context.ReadValueAsButton();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isBoostPressed)
        {
            forwardSpeed = boostAmount;

        }
        else {forwardSpeed = 100f; }

        
        moveInput = currentMovement.z;
        moveInput *= moveInput > 0 ? forwardSpeed : reverseSpeed;

        transform.position = sphereRB.transform.position;
        float newRotation = currentMovement.x * turnSpeed * Time.deltaTime * currentMovement.z;
        transform.Rotate(0, newRotation, 0, Space.World);

        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);

        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        if (isCarGrounded)
        {
            sphereRB.drag = groundDrag;
           
        }
        else
        {
            sphereRB.drag = airDrag;
            
        }
    }

    private void FixedUpdate()
    {
        
        if (isCarGrounded)
        {
            sphereRB.drag = groundDrag;
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            sphereRB.drag = airDrag;
            sphereRB.AddForce(transform.up * -20f);
        }
    }
    private void OnEnable()
    {
        playerInput.Player.Enable();
    }
    private void OnDisable()
    {
        playerInput.Player.Disable();
    }
}
