using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pot : MonoBehaviour
{
    public GameObject jam;

    public GameObject[] gameObjects;

    //public GameObject twister;

    public Transform jamSpawn;
    //public Transform twisterSpawn;

    public AudioSource audioSource;

    public bool hasApple = false;
    public bool hasSugar = false;
    public bool hasCinnamon = false;
    public bool hasAll = false;
    public bool hasJam = false;

    public MeshCollider spoonMC;

    private bool hasInstantiatedJam = false;
    //private bool hasInstantiatedTwister = false;

    void start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Apple")
        {
            hasApple = true;
            FindObjectOfType<AudioManager>().Play("SVC7");
        }

        if (collision.gameObject.tag == "Sugar")
        {
            hasSugar = true;
        }

        if (collision.gameObject.tag == "Cinnamon")
        {
            hasCinnamon = true;
        }

        if (collision.gameObject.tag == "Spoon" && hasApple && hasSugar && hasCinnamon)
        {

            MeshCollider SpoonMC = GameObject.FindWithTag("Spoon").GetComponent<MeshCollider>();
            SpoonMC.enabled = false;

            Destroy(GameObject.FindWithTag("Apple"));
          
            Destroy(GameObject.FindWithTag("Cinnamon"));

            gameObjects = GameObject.FindGameObjectsWithTag("Sugar");

            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            Destroy(GameObject.FindWithTag("Pot"));
            Destroy(gameObject);

            GameObject spawnedJam = Instantiate(jam, jamSpawn.position, jamSpawn.rotation);
            spawnedJam.transform.position = jamSpawn.position;

            FindObjectOfType<AudioManager>().Play("SVC8");

            hasInstantiatedJam = true;

            hasJam = true;

            audioSource.Stop();

        }

    }
}

    /*
    public void StartTwist(SelectEnterEventArgs arg)
    {
            if (hasJam & !hasInstantiatedTwister)
            {
                GameObject spawnedTwister = Instantiate(twister, twisterSpawn.position, twisterSpawn.rotation);
                spawnedTwister.transform.position = twisterSpawn.position;

                hasInstantiatedTwister = true;
            }
    }
    */


