using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenPortal : MonoBehaviour
{
    public GameObject portal;
    public Transform spawnPoint;

    private bool hasInstantiated = false;

    public void OpenPort(SelectEnterEventArgs arg)
    {
        if (!hasInstantiated)
        {
            FindObjectOfType<AudioManager>().Play("Portal");

            GameObject spawnedPortal = Instantiate(portal, spawnPoint.position, spawnPoint.rotation);
            spawnedPortal.transform.position = spawnPoint.position;
            hasInstantiated = true;
        }
    }
}
