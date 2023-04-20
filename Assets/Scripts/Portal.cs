using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    bool m_SceneLoaded;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && m_SceneLoaded == false)
        {
            SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
            m_SceneLoaded = true;
        }

        if (m_SceneLoaded == true)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene2"));
        }
    }
}
