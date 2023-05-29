using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_Pattern02 : MonoBehaviour
{
    [SerializeField]
    private GameObject WarningImg;       // ���� �� ��� �̹���
    [SerializeField]
    private GameObject bigCircle;        // ��� �̹��� �� ������ ������Ʈ
    [SerializeField]
    private Transform spawnPos;          // ��ֹ� ��ȯ ��ġ
    [SerializeField]
    private GameObject nextPattern;      // ���� ������ ���� ����(ù��° ����)

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
