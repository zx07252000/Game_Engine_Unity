using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Character
{
    public Mushroom()
    {
        name = "¹ö¼¸¸ó";
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
        name = "½ºÄÌ·¹Åæ";
        MaxHP = 100;
        curHP = 100;
        STR = 45;
        DEF = 0;

        SK_1 = new BaseAttack(this);
        SK_2 = new ProportionalAttack(this, 20);
    }
}

public class Slime : Character
{
    public Slime()
    {
        name = "½½¶óÀÓ";
        MaxHP = 30;
        curHP = 30;
        STR = 20;
        DEF = 0;

        SK_1 = new BaseAttack(this);
        SK_2 = new PiercingAttack(this);
    }
}