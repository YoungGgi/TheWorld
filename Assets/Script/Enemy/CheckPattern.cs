using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject Pattern;
    [SerializeField]
    private GameObject timeLimit;
    [SerializeField]
    private GameObject doorAnim;
    [SerializeField]
    private GameObject stage1Text;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            doorAnim.gameObject.SetActive(true);
            Pattern.gameObject.SetActive(true);
            timeLimit.gameObject.SetActive(true);
            stage1Text.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
