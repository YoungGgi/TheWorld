using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_Pattern02 : MonoBehaviour
{
    [SerializeField]
    private GameObject WarningImg;       // 패턴 전 경고 이미지
    [SerializeField]
    private GameObject bigCircle;        // 경고 이미지 후 나오는 오브젝트
    [SerializeField]
    private Transform spawnPos;          // 장애물 소환 위치
    [SerializeField]
    private GameObject nextPattern;      // 이후 실행할 다음 패턴(첫번째 패턴)

    private void OnEnable()
    {
        nextPattern.gameObject.SetActive(false);
        StartCoroutine(PatternStart());
    }

    private void OnDisable()
    {
        StopCoroutine(PatternStart());
    }

    IEnumerator PatternStart()
    {
        yield return new WaitForSeconds(2f);

        float imageCycle = 2f;
        WarningImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(imageCycle);
        WarningImg.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        Instantiate(bigCircle, spawnPos.position, Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        nextPattern.gameObject.SetActive(true);
        

    }

}
