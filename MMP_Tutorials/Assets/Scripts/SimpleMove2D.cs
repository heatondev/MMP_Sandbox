using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove2D : MonoBehaviour
{
    public GameObject army;

    Vector3 startLocation;
    Vector3 destination;
    Vector3 finalLocation;

    float moveSpeed;


    void OnMouseDown()
    {
        startLocation = army.transform.position;
        destination = new Vector3(MoveTowards(startLocation, finalLocation, moveSpeed));
    }



    Rigidbody2D rb;

    float moveX;
    float moveY;
    public float speed = 5;

  

    public float jumpHeight = 5;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");


      

        
       // moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, 0.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0.0f, jumpHeight);
           
        }
    }

    private void OnMouseDown()
    {
        
    }
    private void FixedUpdate()
    {
        // rb.AddForce(movement * speed * Time.deltaTime);
        rb.velocity = new Vector2(moveX, 0.0f) * speed * Time.deltaTime;
    }
}
