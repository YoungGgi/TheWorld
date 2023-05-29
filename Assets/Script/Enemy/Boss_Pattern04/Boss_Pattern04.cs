using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Pattern04 : MonoBehaviour
{
    [SerializeField]
    private GameObject bossObj;                   // ���� ������Ʈ
    [SerializeField]
    private Transform bossStartPos;
    [SerializeField]
    private Transform bossEndPos;
    [SerializeField]
    private float bossSpeed;                      // ���� �ӵ�

    private Vector3 originPos = new Vector3(128, 5, 0);         // ���� ������ġ
    private Vector3 patternPos = new Vector3(110, 17, 0);       // ���� �̵���ġ

    [Header("UnbeatSpawnPos")]                 // ���� ������Ʈ ��ȯ ��ġ
    [SerializeField]
    private Transform unbeatSpawnPos;
    [SerializeField]
    private Transform unbeatSpawnPos1;
    [SerializeField]
    private Transform unbeatSpawnPos2;
    [SerializeField]
    private Transform unbeatSpawnPos3;
    [SerializeField]
    private Transform unbeatSpawnPos4;

    [Header("50% SpawnPos")]
    [SerializeField]
    private Transform unbeatSpawnPos5;
    [SerializeField]
    private Transform unbeatSpawnPos6;


    [Header("Unbeat, Boom, Heal")]
    [SerializeField]
    private GameObject unbeatObj;                // ���� ������Ʈ
    [SerializeField]
    private GameObject heal;                     // �÷��̾� �� ����
    [SerializeField]
    private GameObject boom;                     // ��ź(�� ���� ����)
    [SerializeField]
    private Transform healSpawnPos;              // �� ���� ��ȯ ��ġ
    [SerializeField]
    private Transform buffHealSpawnPos;          // ���� ���� �� �߰� ��ȯ�Ǵ� �� ���� ��ġ
    [SerializeField]
    private Transform boomSpawnPos;              // ��ź ��ȯ ��ġ
    
    [Header("UnbeatCount")]
    public int unbeatCount;                      // �÷��̾ ���� ������Ʈ ���� Ƚ��(5�� �Ǹ� ���� ���� ���� ���)

    [Header("BossUI")]
    [SerializeField]
    private GameObject gaugeGroup;
    [SerializeField]
    private Image gaugeRed;
    [SerializeField]
    private GameObject patternText;
    private float skillTime = 0;

    [Header("BossAttack")]
    [SerializeField]
    private GameObject bossAttackCircle;         // ������ ���� ������Ʈ(ȭ�� ��ü��)
    [SerializeField]
    private GameObject halfBossAttack;           // ü�� ���� �� �����ϴ� ���� ���� ������Ʈ
    public bool isCoolStart;

    [Header("PatternStart")]
    [SerializeField]
    private float patternStartCool;  //1f       ���� ���� �� ª�� ��Ÿ��
    [SerializeField]
    private float bossPatternCool;   //10f      ���� ����� ���� ��Ÿ��(�ش� Ÿ�ӵ��� �÷��̾ ���� ������Ʈ �� �Ծ�� ��)
    public float currentCool;        //         ���� ��Ÿ��

    [Header("PatternCancel")]
    [SerializeField]
    private float patternCancelCool; //9f       ���� ��� �� ª�� ��Ÿ��
    [SerializeField]
    private float poitionCool;  //2f            ����/��ź ��ȯ �� ª�� ��Ÿ��
    [SerializeField]
    private float nextPatternCool;  //          ���� ���� �Ѿư� �� ª�� ��Ÿ��


    [SerializeField]
    private GameObject nextPattern;

    public bool isPatternComplete;

    private void OnEnable()
    {
        unbeatCount = 0;
        skillTime = 0;
        patternText.gameObject.SetActive(true);
        StartCoroutine(textSetAcitve());
        StartCoroutine(PatternStart());
    }

    private void OnDisable()
    {
        //StopCoroutine(PatternStart());
        StopAllCoroutines();
    }

    private void Update()
    {
        if(isCoolStart == true)
        {
            StartCoroutine(GaugeUI());
        }
        else
        {
            gaugeRed.fillAmount = 0;
            currentCool = 0;
            gaugeGroup.gameObject.SetActive(false);
        }
          
    }

    IEnumerator textSetAcitve()
    {
        yield return new WaitForSeconds(5f);
        patternText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        patternText.gameObject.SetActive(false);
    }

    IEnumerator PatternStart()
    {
        
        // ���� ���� �� ª�� ��Ÿ��
        yield return new WaitForSeconds(patternStartCool);

        // ������ �ش� ��ġ�� �ٲ�
        bossObj.transform.position = patternPos;

        // ��ġ �̵��� ª�� ��Ÿ���� ���� �� ���� ������Ʈ ����
        yield return new WaitForSeconds(patternStartCool);
        //unbeatObj.gameObject.SetActive(true);
        UnbeatObjSpawn();

        // ���� ��Ÿ�� 
        isCoolStart = true;
        //StartCoroutine(GaugeUI());
        yield return new WaitForSeconds(bossPatternCool);

        if(unbeatCount == 5)
        {
            gaugeGroup.gameObject.SetActive(false);
            StartCoroutine(PatternCancel());
        }
        else
        {
            // ��Ÿ�� ���� �� ��ü ���ݱ� ����
            if(Boss.instance.HP.value <= 0.5f)
            {
                halfBossAttack.gameObject.SetActive(true);

                yield return new WaitForSeconds(1f);

                halfBossAttack.gameObject.SetActive(false);
            }
            else
            {

                bossAttackCircle.gameObject.SetActive(true);

                yield return new WaitForSeconds(1f);

                bossAttackCircle.gameObject.SetActive(false);
            }
            
            gaugeGroup.gameObject.SetActive(false);

            //���� ������Ʈ�� ���� ��ġ�� �ٲ�
            bossObj.transform.position = originPos;

            // ���� ���� ���� �� ���� ���
            yield return new WaitForSeconds(nextPatternCool);

            // ���� ����, ���� ���� ����
            gameObject.SetActive(false);
            isCoolStart = false;
            nextPattern.gameObject.SetActive(true);
            isPatternComplete = true;
        }

        

    }
    IEnumerator GaugeUI()
    {
        yield return null;
        gaugeGroup.gameObject.SetActive(true);

        skillTime += Time.deltaTime;

        float time = skillTime / bossPatternCool;
        gaugeRed.fillAmount = time;
    }

    public void UnbeatObjSpawn()
    {
        Instantiate(unbeatObj, unbeatSpawnPos.position, Quaternion.identity);
        Instantiate(unbeatObj, unbeatSpawnPos1.position, Quaternion.identity);
        Instantiate(unbeatObj, unbeatSpawnPos2.position, Quaternion.identity);
        Instantiate(unbeatObj, unbeatSpawnPos3.position, Quaternion.identity);
        Instantiate(unbeatObj, unbeatSpawnPos4.position, Quaternion.identity);
    }

    IEnumerator PatternCancel()
    {
        StopCoroutine(GaugeUI());
        gaugeGroup.gameObject.SetActive(false);
        // ���� ��� �ڷ�ƾ ���� �� ���� �� ª�� ��Ÿ��
        yield return new WaitForSeconds(patternCancelCool);

        //���� ������Ʈ�� ���� ��ġ�� �ٲ�
        bossObj.transform.position = originPos;

        // �� ���� / ��ź ��ȯ �ڷ�ƾ ����
        StartCoroutine(potionSpawn());

        // ���� ���� ���� �� ���� ���
        yield return new WaitForSeconds(nextPatternCool);

        // ���� ����, ���� ���� ����
        gameObject.SetActive(false);
        nextPattern.gameObject.SetActive(true);
        isPatternComplete = true;

    }

    IEnumerator potionSpawn()
    {
        yield return new WaitForSeconds(poitionCool);

        BoomSpawn();
        healSpawn();

    }

    public void BoomSpawn()
    {
        Instantiate(boom, boomSpawnPos.position, Quaternion.identity);
    }

    public void healSpawn()
    {
        Instantiate(heal, healSpawnPos.position, Quaternion.identity);

        if (Buffs.instance.PlayerSkill[4] == 1)
            Instantiate(heal, buffHealSpawnPos.position, Quaternion.identity);
    }

}
