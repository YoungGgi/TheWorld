using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    [SerializeField]
    private Boss_Pattern04 bossPattern04;
    [SerializeField]
    private GameObject patternCancelTxt;

    private void Start()
    {
        bossPattern04 = GameObject.Find("Pattern04_boss").GetComponent<Boss_Pattern04>();
    }

    private void OnEnable()
    {
        patternCancelTxt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(bossPattern04.unbeatCount == 5)
        {
            patternCancelTxt.gameObject.SetActive(true);
        }

        if(bossPattern04.isCoolStart == false)
        {
            patternCancelTxt.gameObject.SetActive(false);
        }
    }


}
