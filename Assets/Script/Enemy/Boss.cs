using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public static Boss instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public Slider HP;

    [SerializeField]
    private float maxHp;
    [SerializeField]
    private float buffMaxHp;
    [SerializeField]
    private float currentHp;
    [SerializeField]
    private float boomDam;
    [SerializeField]
    private float buffBoomDam;
    [SerializeField]
    private GameObject bossPattern;
    [SerializeField]
    private GameObject bossHpBar;
    [SerializeField]
    private GameObject completeDoor;
    [SerializeField]
    private GameObject bossDestroyTxt;

    public BossDestroy bossDestroy;

    private void Start()
    {
        HP.value = currentHp / maxHp;
        bossDestroy = GameObject.Find("DestroyCheck").GetComponent<BossDestroy>();
    }

    private void Update()
    {
        if (Buffs.instance.PlayerSkill[3] == 1)
            maxHp = buffMaxHp;
        
        if(Buffs.instance.PlayerSkill[3] == 1)
        {
            HP.value = Mathf.Lerp(HP.value, currentHp / buffMaxHp, Time.deltaTime * 5f);
        }
        else
        {
            HP.value = Mathf.Lerp(HP.value, currentHp / maxHp, Time.deltaTime * 5f);
        }

    }

    public void GetDamage()
    {
        if(Buffs.instance.PlayerSkill[5] == 1)
        {
            currentHp -= buffBoomDam;
        }
        else
        {
            currentHp -= boomDam;
        }

        if (currentHp <= 0)
        {
            bossDestroy.isCheck = true;
            bossPattern.gameObject.SetActive(false);
            bossHpBar.gameObject.SetActive(false);

            completeDoor.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

        

    }


}
