using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Pattern04 : MonoBehaviour
{
    [SerializeField]
    private GameObject bossObj;                   // 보스 오브젝트
    [SerializeField]
    private Transform bossStartPos;
    [SerializeField]
    private Transform bossEndPos;
    [SerializeField]
    private float bossSpeed;                      // 보스 속도

    private Vector3 originPos = new Vector3(128, 5, 0);         // 보스 시작위치
    private Vector3 patternPos = new Vector3(110, 17, 0);       // 보스 이동위치

    [Header("UnbeatSpawnPos")]                 // 무적 오브젝트 소환 위치
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
    private GameObject unbeatObj;                // 무적 오브젝트
    [SerializeField]
    private GameObject heal;                     // 플레이어 힐 포션
    [SerializeField]
    private GameObject boom;                     // 폭탄(적 공격 무기)
    [SerializeField]
    private Transform healSpawnPos;              // 힐 포션 소환 위치
    [SerializeField]
    private Transform buffHealSpawnPos;          // 버프 선택 시 추가 소환되는 힐 포션 위치
    [SerializeField]
    private Transform boomSpawnPos;              // 폭탄 소환 위치
    
    [Header("UnbeatCount")]
    public int unbeatCount;                      // 플레이어가 무적 오브젝트 먹은 횟수(5가 되면 보스 패턴 실행 취소)

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
    private GameObject bossAttackCircle;         // 보스의 공격 오브젝트(화면 전체기)
    [SerializeField]
    private GameObject halfBossAttack;           // 체력 절반 시 시전하는 보스 공격 오브젝트
    public bool isCoolStart;

    [Header("PatternStart")]
    [SerializeField]
    private float patternStartCool;  //1f       패턴 시작 시 짧은 쿨타임
    [SerializeField]
    private float bossPatternCool;   //10f      보스 전멸기 시전 쿨타임(해당 타임동안 플레이어가 무적 오브젝트 다 먹어야 됨)
    public float currentCool;        //         현재 쿨타임

    [Header("PatternCancel")]
    [SerializeField]
    private float patternCancelCool; //9f       패턴 취소 시 짧은 쿨타임
    [SerializeField]
    private float poitionCool;  //2f            포션/폭탄 소환 시 짧은 쿨타임
    [SerializeField]
    private float nextPatternCool;  //          다음 패턴 넘아갈 시 짧은 쿨타임


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
        
        // 패턴 시작 전 짧은 쿨타임
        yield return new WaitForSeconds(patternStartCool);

        // 보스를 해당 위치로 바꿈
        bossObj.transform.position = patternPos;

        // 위치 이동후 짧은 쿨타임을 가진 후 무적 오브젝트 생성
        yield return new WaitForSeconds(patternStartCool);
        //unbeatObj.gameObject.SetActive(true);
        UnbeatObjSpawn();

        // 보스 쿨타임 
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
            // 쿨타임 도달 시 전체 공격기 시전
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

            //보스 오브젝트를 원래 위치로 바꿈
            bossObj.transform.position = originPos;

            // 다음 패턴 실행 시 까지 대기
            yield return new WaitForSeconds(nextPatternCool);

            // 패턴 종료, 다음 패턴 실행
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
        // 패턴 취소 코루틴 실행 시 시작 전 짧은 쿨타임
        yield return new WaitForSeconds(patternCancelCool);

        //보스 오브젝트를 원래 위치로 바꿈
        bossObj.transform.position = originPos;

        // 힐 포션 / 폭탄 소환 코루틴 실행
        StartCoroutine(potionSpawn());

        // 다음 패턴 실행 시 까지 대기
        yield return new WaitForSeconds(nextPatternCool);

        // 패턴 종료, 다음 패턴 실행
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
