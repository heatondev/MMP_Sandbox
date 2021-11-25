using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    PlayerActions playerActions;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    Animator animator;

    int isRunningHash;
    int isWalkingHash;

    CharacterController cc;

    public float runSpeed = 3.0f;
    float rotationFactorPerFrame = 15.0f;

    private void Awake()
    {
        playerActions = new PlayerActions();
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

       // cc.detectCollisions = true;

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        playerActions.CharacterControls.Move.started += onMovementInput;
        playerActions.CharacterControls.Move.canceled += onMovementInput;
        playerActions.CharacterControls.Move.performed += onMovementInput;
        playerActions.CharacterControls.Run.started += onRun;
        playerActions.CharacterControls.Run.canceled += onRun;
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            currentRunMovement.x = currentMovementInput.x * runSpeed;
            currentRunMovement.z = currentMovementInput.y * runSpeed;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }
    void handleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }
   
    void handleAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        if (isMovementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        } else if (!isMovementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        if((!isMovementPressed || !isRunPressed) && isRunning){
            animator.SetBool(isRunningHash, false);
        }
       
    }

    void handleGravity()
    {
        if (cc.isGrounded)
        {
            float groundedGravity = -0.05f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y += gravity;
            currentRunMovement.y += gravity;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isRunPressed)
        {
            cc.Move(currentRunMovement * Time.deltaTime);

        }
        else { cc.Move(currentMovement * Time.deltaTime); }
        handleAnimation();
        handleRotation();
        handleGravity();

    }

    void OnEnable()
    {
        playerActions.CharacterControls.Enable();
    }

    void OnDiasble() {
        playerActions.CharacterControls.Disable();
    }
}
