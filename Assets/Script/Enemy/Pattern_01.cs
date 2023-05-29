using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_01 : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePre;

    [SerializeField]
    private int maxEnemySpawn;

    [SerializeField]
    private float spawnCircle;

    [SerializeField]
    private Transform[] spawnPos;

    [SerializeField]
    private GameObject nextPattern;

    

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
        float waitTime = 1f;
        yield return new WaitForSeconds(waitTime);

        int count = 0;
        //while(true)
        while(count < maxEnemySpawn)
        {
            
            int random = Random.Range(0, spawnPos.Length); //7
            Instantiate(circlePre, spawnPos[random].position, Quaternion.identity);

            yield return new WaitForSeconds(spawnCircle);

            count++;
        }

        gameObject.SetActive(false);
        nextPattern.gameObject.SetActive(true);

    }

}
