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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            menuSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            menuSound.PlayOneShot(myClip);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            menuSound.Stop();
        }
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

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            menuSound.Play();
        }
    }

}
