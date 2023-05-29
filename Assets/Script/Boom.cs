using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private float speed;

    public Boss boss;

    private void Awake()
    {
        boss = GameObject.Find("Boss").GetComponent<Boss>();
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
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Touch");
            rigid.velocity = Vector2.right * speed;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            boss.GetDamage();
            Destroy(this.gameObject);
        }
    }
}
