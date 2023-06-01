using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Text : MonoBehaviour
{
    [SerializeField]
    private GameObject stageText;

    private void OnEnable()
    {
        StartCoroutine(TextAnim());
    }

    IEnumerator TextAnim()
    {
        stageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        stageText.gameObject.SetActive(false);

    }

}
