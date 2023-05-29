using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBox : MonoBehaviour
{
    [SerializeField]
    private GameObject buffPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            buffPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }

}
