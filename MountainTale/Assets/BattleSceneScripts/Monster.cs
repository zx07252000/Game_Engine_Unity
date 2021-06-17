using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : Character
{
    public GameObject monster;

    //public Sprite spEye;
    public RuntimeAnimatorController amEye;
    //public AnimationClip acEye;

    //public Sprite spMushroom;
    public RuntimeAnimatorController amMushroom;
    //public AnimationClip acMushroom;

    //public Sprite spGoblin;
    public RuntimeAnimatorController amGoblin;
    //public AnimationClip acGoblin;

    //public Sprite spSkeleton;
    public RuntimeAnimatorController amSkeleton;
    //public AnimationClip acSkeleton;


    public void SetMonster(int type)
    {
        //transform.position = new Vector3(121, 68, 0);

        switch (type)
        {
            case 0:
                {
                    name = "이블아이";
                    MaxHP = 50;
                    curHP = 50;
                    STR = 20;
                    DEF = 0;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new PiercingAttack(this);

                    animator = amEye;
                }
                break;
            case 1:
                {
                    name = "버섯몬";
                    MaxHP = 80;
                    curHP = 80;
                    STR = 20;
                    DEF = 10;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new DoubleAttack(this);

                    animator = amMushroom;
                }
                break;
            case 2:
                {
                    name = "고블린";
                    MaxHP = 100;
                    curHP = 100;
                    STR = 30;
                    DEF = 20;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new PiercingAttack(this);

                    animator = amGoblin;
                }
                break;
            case 3:
                {
                    name = "스켈레톤";
                    MaxHP = 150;
                    curHP = 150;
                    STR = 45;
                    DEF = 0;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new ProportionalAttack(this, 20);

                    animator = amSkeleton;
                }
                break;
        }

        monster.GetComponent<Animator>().runtimeAnimatorController = animator;
        print("가나다라");
    }
}

public class Mushroom : Character
{
    public Mushroom()
    {
        name = "버섯몬";
        MaxHP = 80;
        curHP = 80;
        STR = 20;
        DEF = 10;

        SK_1 = new BaseAttack(this);
        SK_2 = new DoubleAttack(this);
    }
}

public class Skeleton : Character
{
    public Skeleton()
    {
        name = "스켈레톤";
        MaxHP = 150;
        curHP = 150;
        STR = 45;
        DEF = 0;

        SK_1 = new BaseAttack(this);
        SK_2 = new ProportionalAttack(this, 20);
    }
}

public class Goblin : Character
{
    public Goblin()
    {
        name = "고블린";
        MaxHP = 100;
        curHP = 100;
        STR = 30;
        DEF = 20;

        SK_1 = new BaseAttack(this);
        SK_2 = new PiercingAttack(this);
    }
}

public class FlyingEye : Character
{
    public FlyingEye()
    {
        name = "이블아이";
        MaxHP = 50;
        curHP = 50;
        STR = 20;
        DEF = 0;

        SK_1 = new BaseAttack(this);
        SK_2 = new PiercingAttack(this);
    }
}