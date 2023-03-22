using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenPortal : MonoBehaviour
{
    public GameObject portal;
    public Transform spawnPoint;

    public void OpenPort(ActivateEventArgs arg)
    {
        GameObject spawnedPortal = Instantiate(portal, spawnPoint.position, spawnPoint.rotation); 
        spawnedPortal.transform.position = spawnPoint.position;
    }
}
