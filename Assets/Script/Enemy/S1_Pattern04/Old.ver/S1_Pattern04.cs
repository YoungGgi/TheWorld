using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_Pattern04 : MonoBehaviour
{
    [SerializeField]
    private GameObject warnningImg;
    [SerializeField]
    private GameObject spawnObj;
    [SerializeField]
    private Transform spawnPos;


    private void OnEnable()
    {
        StartCoroutine(PatternStart());
    }

    private void OnDisable()
    {
        StopCoroutine(PatternStart());
    }

    IEnumerator PatternStart()
    {
        yield return new WaitForSeconds(1.5f);

        float imageCycle = 2f;
        warnningImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(imageCycle);
        warnningImg.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        Instantiate(spawnObj, spawnPos.position, Quaternion.identity);
    }

}
