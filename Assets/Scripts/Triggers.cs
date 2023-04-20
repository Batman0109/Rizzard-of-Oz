using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameObject scarecrow;

    public Transform scareSpawn;

    public bool hasTrigger1 = false;
    public bool hasDoor = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "VC1" &! hasTrigger1)
        {
            StartCoroutine(VoiceLine1());

            hasTrigger1 = true;
        }

        if (collision.gameObject.tag == "Door" &! hasDoor)
        {
            Destroy(GameObject.FindWithTag("Scarecrow"));

            GameObject spawnedScare = Instantiate(scarecrow, scareSpawn.position, scareSpawn.rotation);
            spawnedScare.transform.position = scareSpawn.position;

            StartCoroutine(VoiceLine2());

            hasDoor = true;
        }
    }

    IEnumerator VoiceLine1()
    {
        FindObjectOfType<AudioManager>().Play("SVC1");

        yield return new WaitForSeconds(4);

        FindObjectOfType<AudioManager>().Play("TVC3");

        yield return new WaitForSeconds(3);

        FindObjectOfType<AudioManager>().Play("SVC2");
    }

    IEnumerator VoiceLine2()
    {
        FindObjectOfType<AudioManager>().Play("SVC3");

        yield return new WaitForSeconds(3);

        FindObjectOfType<AudioManager>().Play("TVC4");

        yield return new WaitForSeconds(3);

        FindObjectOfType<AudioManager>().Play("SVC4");

        yield return new WaitForSeconds(4);

        FindObjectOfType<AudioManager>().Play("TVC5");

        yield return new WaitForSeconds(5);

        FindObjectOfType<AudioManager>().Play("SVC5");

        yield return new WaitForSeconds(3);

        FindObjectOfType<AudioManager>().Play("SVC6");
    }
}
