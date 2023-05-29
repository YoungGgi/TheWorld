using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    

    [SerializeField]
    private GameObject buffPanel;                  // 버프 선택 창

    public Buffs playerSkill;                     // 버프 목록 스크립트

    public void ClickBtn(int index)
    {
        playerSkill.PlayerSkill[index] = 1;
        Time.timeScale = 1;
        buffPanel.gameObject.SetActive(false);
    }

}
