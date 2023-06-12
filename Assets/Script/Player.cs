using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Move Horizontal")]
    [SerializeField]
    private float speed;
    //[SerializeField]
    //private float buffSpeed;

    [Header("Jump")]
    [SerializeField]
    private float jumpPower;
    

    [Header("Collision")]
    private bool isGround;
    //[SerializeField]
    //private Transform pos;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask groundLayer;

    [Header("Health")]
    public int health;
    public int maxHealth;
    [SerializeField]
    private Image[] health_Img;
    [SerializeField]
    private Sprite health_fill;
    [SerializeField]
    private Sprite health_empty;

    [Header("UI_Object")]
    [SerializeField]
    private GameObject GameOverObj;

    [SerializeField]
    private float notDamageDuration;
    [SerializeField]
    private float buffNotDamageDuration;
    private Color originColor;

    
    private Rigidbody2D rigid2D;
    private new Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool isNotDamage = false;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        originColor = spriteRenderer.color;
    }

    private void Update()
    {
        //isGround = Physics2D.OverlapCircle(pos.position, checkRadius, groundLayer);
        
        if(Input.GetButtonDown("Jump") && !anim.GetBool("isJump"))
        {
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
        }
        
        if(Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (Mathf.Abs(rigid2D.velocity.x) < 0.3)
            anim.SetBool("isRun", false);
        else
            anim.SetBool("isRun", true);

        
        if (health > maxHealth)
            health = maxHealth;

        for(int i = 0; i < health_Img.Length; i++)
        {
            if (i < health)
                health_Img[i].sprite = health_fill;
            else
                health_Img[i].sprite = health_empty;


            if (i < maxHealth)
                health_Img[i].enabled = true;
            else
                health_Img[i].enabled = false;
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if(Buffs.instance.PlayerSkill[1] == 1)
        {
            rigid2D.velocity = new Vector2(x * (float)(speed + 2.1), rigid2D.velocity.y);
        }
        else
        {
            rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
        }


        if (rigid2D.velocity.y < 0)
        {
            Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

            if(rayHit.collider != null)
            {
                if (rayHit.distance < 0.8f)
                {
                    anim.SetBool("isJump", false);
                    //Debug.Log(rayHit.collider.name);
                }
                    
            }
        }

    }

    IEnumerator NotDamage()
    {
        isNotDamage = true;

        float current = 0;
        float percent = 0;
        float colorSpeed = 10;

        while(percent <1)
        {
            current += Time.deltaTime;
            if(Buffs.instance.PlayerSkill[2] == 1)
            {
                percent = current / buffNotDamageDuration;
            }
            else
            {
                percent = current / notDamageDuration;
            }
            
            spriteRenderer.color = Color.Lerp(originColor, Color.red, Mathf.PingPong(Time.time * colorSpeed, 1));

            yield return null;
        }

        spriteRenderer.color = originColor;
        isNotDamage = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if(!isNotDamage)
            {
                health--;
                StartCoroutine(NotDamage());
            }
            
            if(health <= 0)
            {
                Time.timeScale = 0;
                GameOverObj.gameObject.SetActive(true);
            }
        }

        if(collision.tag == "BuffEnemy")
        {
            if(!isNotDamage)
            {
                health -= 4;
            }

            if (health <= 0)
            {
                Time.timeScale = 0;
                GameOverObj.gameObject.SetActive(true);
            }

        }

    }

    

}
