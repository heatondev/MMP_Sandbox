using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSimple3D : MonoBehaviour
{
    CharacterController character;

    public AudioSource menuSound;
    public AudioClip myClip;

    float moveX;
    float moveZ;

    Vector3 movement;

    public float speed = 5;
    public float gravityValue;
    public float jumpHeight = 10f;
    
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        // -1 for left, +1 for right
        moveZ = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveX, 0.0f, moveZ);

       
    }
    void handlegravity()
    {
        if (character.isGrounded)
        {
            float groundgravity = -.05f;
            movement.y = groundgravity;
        }
        else
        {

            movement.y = gravityValue;
        }
    }

    private void FixedUpdate()
    {
        character.Move(movement * speed*Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collision");
            menuSound.Play();
       // Destroy(collision.gameObject);
        
    }

}
