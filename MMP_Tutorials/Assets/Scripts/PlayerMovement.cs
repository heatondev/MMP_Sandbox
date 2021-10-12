using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float _movementX;
    float _movementY;
    public float speed = 1;
    public float jumpHeight = 1;

   [SerializeField]
    AudioSource pickUpAudio;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    int count;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);


    }
    private void FixedUpdate()
    {
        
        Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);
        rb.AddForce(movement*speed);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
       

        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    public void OnJump()
    {
        Vector3 jumpUp = new Vector3(0.0f, jumpHeight, 0.0f);
        //rb.velocity = jumpUp;
        rb.AddForce(0.0f,jumpHeight,0.0f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            pickUpAudio.Play();
            count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

}
