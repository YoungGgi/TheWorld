using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern04_Border : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DestroyCool());
    }

    IEnumerator DestroyCool()
    {
        float coolTime = 7f;
        yield return new WaitForSeconds(coolTime);
        Destroy(this.gameObject);
    }
}
