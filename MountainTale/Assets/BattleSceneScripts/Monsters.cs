using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Character
{
    public Mushroom()
    {
        name = "������";
        MaxHP = 70;
        curHP = 70;
        STR = 30;
        DEF = 10;

        SK_1 = new BaseAttack(this);
        SK_2 = new DoubleAttack(this);
    }
}

public class Skeleton : Character
{
    public Skeleton()
    {
        name = "���̷���";
        MaxHP = 100;
        curHP = 100;
        STR = 45;
        DEF = 0;

        SK_1 = new BaseAttack(this);
        SK_2 = new DoubleAttack(this);
    }
}