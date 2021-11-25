using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public AudioSource audio;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
        Debug.Log("Punched");
             if (!audio.isPlaying)
            {
             audio.Play();
            }
            Destroy(collision.gameObject);
        }
       
    }
}
