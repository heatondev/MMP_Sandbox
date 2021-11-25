using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    [SerializeField]
    float forceMagnitude;

    bool punch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            punch = true;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Rigidbody rigidbody = hit.collider.attachedRigidbody;

        //if (rigidbody != null)
        //{
        //    Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
        //    forceDirection.y = 0;
        //    forceDirection.Normalize();

        //    rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        //}

        if (hit.gameObject.tag == "Rock"&&punch)
        {
            Destroy(hit.gameObject);
        }
    }
}
