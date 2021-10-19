using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move2D : MonoBehaviour
{
    Rigidbody2D rb;

    float moveX;
    public float speed = 10f;
    public float jumpHeight;

    public LayerMask whatIsGround;
    public Transform groundPoint;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
    }

    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX*speed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed&& isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
}
