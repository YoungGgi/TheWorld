using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    

    [SerializeField]
    private GameObject buffPanel;                  // ���� ���� â

    public Buffs playerSkill;                     // ���� ��� ��ũ��Ʈ

    public void ClickBtn(int index)
    {
        playerSkill.PlayerSkill[index] = 1;
        Time.timeScale = 1;
        buffPanel.gameObject.SetActive(false);
    }

}
