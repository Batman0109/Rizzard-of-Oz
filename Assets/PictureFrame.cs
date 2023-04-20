using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PictureFrame : MonoBehaviour
{
    public GameObject diary;

    public Transform diarySpawn;

    private bool hasInstantiated = false;
    private bool hasSaid = false;   

    public void Trigger(SelectEnterEventArgs arg)
    {
        if (!hasSaid)
        {
            StartCoroutine(Voiceline());
            hasSaid = true;
        }
    }

    public void SpawnDiary(SelectExitEventArgs arg)
    {
        if (!hasInstantiated)
        {
            GameObject spawnedDiary = Instantiate(diary, diarySpawn.position, diarySpawn.rotation);
            spawnedDiary.transform.position = diarySpawn.position;

            hasInstantiated = true;
        }
    }

    IEnumerator Voiceline()
    {
        FindObjectOfType<AudioManager>().Play("TVC1");

        yield return new WaitForSeconds(5);

        FindObjectOfType<AudioManager>().Play("TVC2");
    }
}
