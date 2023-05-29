using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_Prefab2 : MonoBehaviour
{
    [SerializeField]
    private float speed;

    
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigid.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            StartCoroutine(DestroyCool());
        }
    }

    IEnumerator DestroyCool()
    {
        rigid.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.2f);

        Destroy(this.gameObject);
    }
}
