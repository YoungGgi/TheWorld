using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHelp : MonoBehaviour
{
    [SerializeField]
    private GameObject nextObject;
    [SerializeField]
    private GameObject backObject;


    public void PageRight()
    {
        nextObject.gameObject.SetActive(true);
        backObject.gameObject.SetActive(false);
    }

    public void PageLeft()
    {
        backObject.gameObject.SetActive(true);
        nextObject.gameObject.SetActive(false);
    }

}
