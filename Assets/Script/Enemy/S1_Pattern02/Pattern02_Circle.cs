using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern02_Circle : MonoBehaviour
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
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

}
