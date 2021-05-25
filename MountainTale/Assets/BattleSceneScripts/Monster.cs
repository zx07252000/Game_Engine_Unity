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
        STR = 20;
        DEF = 10;
    }
}