using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbeatPattern : MonoBehaviour
{
    public Boss_Pattern04 boss_Pattern04;

    private void Awake()
    {
        boss_Pattern04 = GameObject.Find("Pattern04_boss").GetComponent<Boss_Pattern04>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            boss_Pattern04.unbeatCount++;
            Destroy(this.gameObject);
        }
    }
}
