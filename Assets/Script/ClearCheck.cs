using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject clearPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            clearPanel.gameObject.SetActive(true);
        }
    }
}
