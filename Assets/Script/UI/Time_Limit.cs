using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Limit : MonoBehaviour
{
    public static Time_Limit instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
            return;
    }

    public float time;

    [SerializeField]
    private Text time_Txt;
    [SerializeField]
    private GameObject battleDoor;
    [SerializeField]
    private GameObject pattern_Stage1;
    [SerializeField]
    private GameObject pattern_Stage02;
    [SerializeField]
    private GameObject pattern_04;

    void Start()
    {
        time_Txt.text = time.ToString();
    }

    private void OnEnable()
    {
        //StartCoroutine(TimeStart());
        Update();
        
    }
    private void OnDisable()
    {
        StopCoroutine(TimeStart());

    }

    private void Update()
    {
        StartCoroutine(TimeStart());
    }

    IEnumerator TimeStart()
    {
        float waitTime = 0.5f;
        yield return new WaitForSeconds(waitTime);

        if (time > 0)
            time -= Time.deltaTime;
        else if (time < 0)
        {
            pattern_Stage1.gameObject.SetActive(false);
            pattern_Stage02.gameObject.SetActive(false);
            battleDoor.gameObject.SetActive(false);
            pattern_04.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        if (time < 10)
            time_Txt.color = new Color(255, 0, 0);

        time_Txt.text = Mathf.Round(time).ToString();

    }

}
