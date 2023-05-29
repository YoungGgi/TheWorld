using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomControl : MonoBehaviour
{
    [SerializeField]
    private GameObject boom;
    [SerializeField]
    private Transform spawnPos;

    [SerializeField]
    private Boss_Pattern04 pattern04;
    
    // Update is called once per frame
    void Update()
    {
        if(pattern04.isPatternComplete == true)
        {
            Instantiate(boom, spawnPos.position, Quaternion.identity);
            pattern04.isPatternComplete = false;
        }
    }
}
