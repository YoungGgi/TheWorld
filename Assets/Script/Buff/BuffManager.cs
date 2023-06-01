using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject buffPanel;                  // 버프 선택 창
    [SerializeField]
    private GameObject healPotion;
    [SerializeField]
    private Transform healSpawn;

    public Buffs playerSkill;                     // 버프 목록 스크립트

    public void ClickBtn(int index)
    {
        playerSkill.PlayerSkill[index] = 1;
        Time.timeScale = 1;
        if(Buffs.instance.PlayerSkill[0] == 1)
        {
            Instantiate(healPotion, healSpawn.position, Quaternion.identity);

        }

        buffPanel.gameObject.SetActive(false);
    }


}
