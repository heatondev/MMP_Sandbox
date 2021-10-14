using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    Vector3 moveDirection;
    float moveX;
    float moveZ;

    public float speed;

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
        Debug.Log(moveX);
        moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0.0f, moveZ).normalized;
    }

    private void FixedUpdate()
    {
        cc.Move(moveDirection * Time.deltaTime * speed);
    }
}
