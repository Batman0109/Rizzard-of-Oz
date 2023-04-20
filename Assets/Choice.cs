using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 10000f;

    float desiredAngle = 45.0f;

    public bool ifDecided = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Decision(SelectEnterEventArgs arg)
    {
        StartCoroutine(ChoiceToMake());
    }

    IEnumerator ChoiceToMake()
    {
        yield return new WaitForSeconds(10);

        HeldOn();
    }

    public void HeldOn()
    {
        if (!ifDecided)
        {
            SceneManager.LoadScene("Scene3", LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene3"));
        }
    }

    public void LetGo(SelectExitEventArgs arg)
    {
        FindObjectOfType<AudioManager>().Play("SVC13");

        ifDecided = true; 

        float desiredAngleRad = Mathf.Deg2Rad * desiredAngle;

        Vector3 dir = new Vector3(Mathf.Cos(desiredAngleRad), Mathf.Sin(desiredAngleRad), 0.0f);

        dir = Quaternion.AngleAxis(transform.rotation.eulerAngles.z - 90, Vector3.down) * dir;

        rb.AddForce(dir * speed);

        StartCoroutine(ReturnBedroom());
    }

    IEnumerator ReturnBedroom()
    {

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene1"));
    }
}
