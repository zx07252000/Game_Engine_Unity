using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    void Start()
    {
        name = "김철수";
        MaxHP = 100;
        currHP = 100;
        dmg = 30;
        def = 10;
    }
}
