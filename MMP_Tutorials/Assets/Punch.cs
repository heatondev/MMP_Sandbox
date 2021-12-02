using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public AudioSource audio;

    public Transform hitbox;
    public float hitRadius;
    public LayerMask rocks;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PunchObject(hitbox.position, hitRadius);
        }
    }

    void PunchObject(Vector3 hit, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(hit, radius, rocks);
        foreach (var hitCollider in hitColliders)
        {
            audio.Play();
            Destroy(hitCollider.gameObject);
        }
    }
    
}
