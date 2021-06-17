using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    void Start()
    {
        name = "김철수";
        MaxHP = 100;
        curHP = 100;
        STR = 30;
        DEF = 10;
        MaxExp = 100;
        curExp = 0;
        Level = 1;

        SK_1 = new BaseAttack(this);
        SK_2 = new DoubleAttack(this);
        SK_3 = new SlashAttack(this);
    }
}
