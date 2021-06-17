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

    public RuntimeAnimatorController amBoss;


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
                    reword = 20;

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
                    reword = 30;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new ProportionalAttack(this, 20);

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
                    reword = 40;

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
                    reword = 50;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new SlashAttack(this);

                    animator = amSkeleton;
                }
                break;
            case 4:
                {
                    RectTransform rct = GetComponent<RectTransform>();
                    rct.anchoredPosition = new Vector2(-12, 173);
                    monster.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                    name = "보스";
                    MaxHP = 200;
                    curHP = 200;
                    STR = 50;
                    DEF = 20;
                    reword = 100;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new SlashAttack(this);
                    SK_3 = new ProportionalAttack(this, 25);

                    animator = amBoss;
                }
                break;
        }

        monster.GetComponent<Animator>().runtimeAnimatorController = animator;
    }

    public int ChooseSkill()
    {
        if(name == "보스")
        {
            int probability = Random.Range(0, 11);

            if (probability > 8)
            {
                return 3;
            }
            else if (probability > 4)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            int probability = Random.Range(0, 10);

            if (probability > 6)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
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