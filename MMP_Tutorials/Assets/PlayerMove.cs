using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    CharacterController _character;
    InputActions playerInput;
    public float moveSpeed = 3f;

    
   public float jumpHeight;
    float gravityValue = -5f;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    
    void Awake()
    {
        playerInput = new InputActions();

        playerInput.Player.Move.started += OnMovementInput; 
        playerInput.Player.Move.canceled += OnMovementInput;
        playerInput.Player.Move.performed += OnMovementInput;

        _character = GetComponent<CharacterController>();
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void HandleGravity()
    {
        if (_character.isGrounded)
        {
            float groundGravity = -.05f;
            currentMovement.y = groundGravity;
        } else
        {
            
            currentMovement.y = gravityValue;
        }
    }

    void OnJump()
    {
        Debug.Log("Jump pressed");
        if (_character.isGrounded)
        {
            //currentMovement.y += jumpHeight;
            currentMovement = new Vector3(0, jumpHeight, 0);
            
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
    void Update()
    {
        _character.Move(currentMovement * Time.deltaTime * moveSpeed);
        HandleGravity();
    }
}
