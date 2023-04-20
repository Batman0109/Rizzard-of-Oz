using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartTwister : MonoBehaviour
{
    public GameObject twister;
    public Transform spawnPoint;

    private bool hasInstantiated = false;

    public void StartTwist(SelectEnterEventArgs arg)
    {
        if (!hasInstantiated)
        {
            GameObject spawnedTwister = Instantiate(twister, spawnPoint.position, spawnPoint.rotation);
            spawnedTwister.transform.position = spawnPoint.position;
            hasInstantiated = true;
        }
    }
}
