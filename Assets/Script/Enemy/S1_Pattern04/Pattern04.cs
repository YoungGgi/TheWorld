using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern04 : MonoBehaviour
{
    [SerializeField]
    private GameObject warnningImg1;
    [SerializeField]
    private GameObject warnningImg2;
    
    [SerializeField]
    private GameObject ObstaclePrefab1;
    [SerializeField]
    private GameObject ObstaclePrefab2;

    [SerializeField]
    private Transform spawnPos;
    [SerializeField]
    private Transform spawnPos2;


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

        // 첫 번째 장애물 등장
        float imageCycle = 2f;
        warnningImg1.gameObject.SetActive(true);
        yield return new WaitForSeconds(imageCycle);
        warnningImg1.gameObject.SetActive(false);

        Instantiate(ObstaclePrefab1, spawnPos.position, Quaternion.identity);

        yield return new WaitForSeconds(1.1f);

        // 두 번째 장애물 등장
        warnningImg2.gameObject.SetActive(true);
        yield return new WaitForSeconds(imageCycle);
        warnningImg2.gameObject.SetActive(false);

        Instantiate(ObstaclePrefab2, spawnPos2.position, Quaternion.identity);

        yield return new WaitForSeconds(1.3f);

    }

}
