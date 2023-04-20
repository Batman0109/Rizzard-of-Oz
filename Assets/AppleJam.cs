using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleJam : MonoBehaviour
{
    public GameObject twister;
    public GameObject scarecrow;

    public Transform twisterSpawn;
    public Transform scareSpawn;

    private bool hasInstantiatedTwister = false;
    private bool hasInstantiatedScare = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Table" & !hasInstantiatedTwister & !hasInstantiatedScare)
        {
            Destroy(GameObject.FindWithTag("Scarecrow1"));

            GameObject spawnedTwister = Instantiate(twister, twisterSpawn.position, twisterSpawn.rotation);
            spawnedTwister.transform.position = twisterSpawn.position;

            hasInstantiatedTwister = true;

            GameObject spawnedScare = Instantiate(scarecrow, scareSpawn.position, scareSpawn.rotation);
            spawnedScare.transform.position = scareSpawn.position;

            hasInstantiatedScare = true;

            StartCoroutine(Voiceline());

        }
    }

    IEnumerator Voiceline()
    {
        yield return new WaitForSeconds(5);

        FindObjectOfType<AudioManager>().Play("SVC9");

        yield return new WaitForSeconds(6);

        FindObjectOfType<AudioManager>().Play("SVC10");
    }
}
