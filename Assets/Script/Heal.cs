using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Player player;

    private void Awake()
    {
        player = GameObject.Find("Player_a").GetComponent<Player>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyTerm());
    }

    IEnumerator DestroyTerm()
    {
        yield return new WaitForSeconds(8f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.health++;
            Destroy(this.gameObject);
        }
    }
}
