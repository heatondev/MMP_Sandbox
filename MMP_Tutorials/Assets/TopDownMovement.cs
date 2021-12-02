using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveX;
    Vector2 movement;
    float speed = 50f;
    Animator animator;
    bool walking;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Debug.Log(movement.x);
        if(movement.x > 0)
        {
            walking = true;
        }else if (movement.x == 0)
        {
            walking = false;
        }
        if (walking)
        {
            animator.SetBool("isWalking", true);
        }else if (!walking) { animator.SetBool("isWalking", false); }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed * Time.deltaTime);
    }
}
