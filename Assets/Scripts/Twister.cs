using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twister : MonoBehaviour
{
    public float speed;
    public float runtime;

    private Rigidbody rb;

    public bool isGoing = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGoing)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        rb.velocity = transform.forward * speed;

        yield return new WaitForSeconds(runtime);

        rb.velocity = transform.forward * 0;

        isGoing = false;    
    }
}
