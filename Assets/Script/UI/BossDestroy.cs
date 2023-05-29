using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroy : MonoBehaviour
{

    [SerializeField]
    private GameObject bossDestroyTxt;

    public bool isCheck;

    // Update is called once per frame
    void Update()
    {
        if(isCheck)
        {
            StartCoroutine(destroyTxt());
        }
    }

    IEnumerator destroyTxt()
    {
        bossDestroyTxt.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        bossDestroyTxt.gameObject.SetActive(false);

        isCheck = false;
    }
}
