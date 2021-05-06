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
        currHP = 70;
        dmg = 20;
        def = 0;
    }
}