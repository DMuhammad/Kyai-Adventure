using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // public AudioSource ButtonSound;

    public void Quitgame()
    {
        // AudioSource buttonSound = ButtonSound.GetComponent<AudioSource>();
        // buttonSound.PlayOneShot (buttonSound.clip);
        Application.Quit();
    }
}
