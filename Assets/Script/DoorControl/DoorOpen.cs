using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    [SerializeField]
    private Animator doorClose;
    
    void Update()
    {
        if (Time_Limit.instance.time == 0)
        {
            doorClose.SetTrigger("isClose");
        }
    }
}
