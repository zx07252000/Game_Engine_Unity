using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Character
{
    void Start()
    {
        name = "버섯몬";
        MaxHP = 70;
        curHP = 70;
        STR = 30;
        DEF = 10;

        //SK_1 = 기본공격
        //SK_1 = 방어
        //SK_1 = 강화공격
        //SK_1 = 필살기
    }
}