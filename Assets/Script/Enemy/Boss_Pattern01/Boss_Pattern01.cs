using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Pattern01 : MonoBehaviour
{
    [SerializeField]
    private Transform targetPos;                  // Ÿ��(�÷��̾�) ��ġ
    [SerializeField]
    private GameObject warningImg;                // ��� �̹���
    [SerializeField]
    private GameObject spawnExplosion;            // ���� ������
    [SerializeField]
    private float spawnCycle;                     // ��ȯ �ֱ�
    [SerializeField]
    private int maxCount;                         // �ִ� ��ȯ ����
    [SerializeField]
    private int buffMaxCount;
    [SerializeField]
    private GameObject nextPattern;               // ������ ������ ����
    [SerializeField]
    private GameObject gaugeGroup;
    [SerializeField]
    private GameObject bossPatternTxt;

    private void OnEnable()
    {
        gaugeGroup.gameObject.SetActive(false);
        bossPatternTxt.gameObject.SetActive(false);
        StartCoroutine(PatternStart());
    }

    private void OnDisable()
    {
        StopCoroutine(PatternStart());
    }

    IEnumerator PatternStart()
    {
        yield return new WaitForSeconds(1f);

        int count = 0;
        if(Boss.instance.HP.value <= 500f)
        {
            while (count < buffMaxCount)
            {
                StartCoroutine(SpawnEx());

                count++;

                yield return new WaitForSeconds(spawnCycle);
            }
        }
        else
        {
            while (count < maxCount)
            {
                StartCoroutine(SpawnEx());

                count++;

                yield return new WaitForSeconds(spawnCycle);
            }
        }

        gameObject.SetActive(false);
        nextPattern.gameObject.SetActive(true);

    }

    IEnumerator SpawnEx()
    {
        GameObject warnningClone = Instantiate(warningImg, targetPos.transform.position, Quaternion.identity);
        //warnningClone.transform.localScale = Vector3.one;

        yield return new WaitForSeconds(0.8f);

        GameObject explosion = Instantiate(spawnExplosion, warnningClone.transform.position, Quaternion.identity);
        Destroy(warnningClone);
        Destroy(explosion, 0.1f);
    }



}
