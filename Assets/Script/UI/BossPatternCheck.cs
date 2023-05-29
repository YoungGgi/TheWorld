using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject bossPattern;
    [SerializeField]
    private GameObject bossHp;
    [SerializeField]
    private Transform bossHpSpawnPos;
    [SerializeField]
    private GameObject doorAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            doorAnim.gameObject.SetActive(true);
            LeanTween.move(bossHp, bossHpSpawnPos, 1.0f);
            bossPattern.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
