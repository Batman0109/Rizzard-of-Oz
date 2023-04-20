using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Radio : MonoBehaviour
{
    public bool hasPlayed = false;

    public void PlaySound(SelectEnterEventArgs arg)
    {
        if (!hasPlayed)
        {
            FindObjectOfType<AudioManager>().Play("Bitches");
            hasPlayed = true;
        }
    }
}
