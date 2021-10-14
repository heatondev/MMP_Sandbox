using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayAudio : MonoBehaviour
{
    public AudioSource playAudio;

    void OnJump()
    {
        playAudio.Play();
    }
}
