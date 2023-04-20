using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Voiceline());
    }

    IEnumerator Voiceline()
    {
        yield return new WaitForSeconds(2);

        FindObjectOfType<AudioManager>().Play("SVC12");
    }

}
