using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator door;

    private void OnEnable()
    {
        Update();
    }

    private void Update()
    {
        door.SetBool("isDoor", true);
    }
}
