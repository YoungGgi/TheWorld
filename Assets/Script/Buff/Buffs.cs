using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public static Buffs instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public List<int> PlayerSkill = new List<int>();            // ���� ����Ʈ ����
}
