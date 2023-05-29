using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Player movement2D;

    void Awake()
    {
        movement2D = GetComponent<Player>();
    }

    /*
    void Update()
    {
        UpdateMove();
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.MoveTo(x);
    }

    */

}
