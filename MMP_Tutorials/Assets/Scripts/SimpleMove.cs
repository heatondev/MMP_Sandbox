using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    //Movement
    Vector3 moveDirection;
    float moveX;
    float moveZ;
       public float speed;

    //Turning


        //Jumping and Gravity


    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

        if(direction.magnitude > 0.1f)
        {

        }

    }

    private void FixedUpdate()
    {
        
    }
}
