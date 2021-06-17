using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCreator : Character
{
    public Image imgEye;
    public Image imgMushroom;
    public Image imgGoblin;
    public Image imgSkeleton;

    public Sprite spEye;
    public Sprite spMushroom;
    public Sprite spGoblin;
    public Sprite spSkeleton;

    public Animator amEye;
    public Animator amMushroom;
    public Animator amGoblin;
    public Animator amSkeleton;

    public MonsterCreator(int type)
    {
        switch (type)
        {
            case 0:
                {
                    name = "ÀÌºí¾ÆÀÌ";
                    MaxHP = 50;
                    curHP = 50;
                    STR = 20;
                    DEF = 0;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new PiercingAttack(this);

                    image = imgEye;
                    sprite = spEye;
                    animator = amEye;
                }
                break;
            case 1:
                {
                    name = "¹ö¼¸¸ó";
                    MaxHP = 80;
                    curHP = 80;
                    STR = 20;
                    DEF = 10;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new DoubleAttack(this);

                    image = imgMushroom;
                    sprite = spMushroom;
                    animator = amMushroom;
                }
                break;
            case 2:
                {
                    name = "°íºí¸°";
                    MaxHP = 100;
                    curHP = 100;
                    STR = 30;
                    DEF = 20;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new PiercingAttack(this);

                    image = imgGoblin;
                    sprite = spGoblin;
                    animator = amGoblin;
                }
                break;
            case 3:
                {
                    name = "½ºÄÌ·¹Åæ";
                    MaxHP = 150;
                    curHP = 150;
                    STR = 45;
                    DEF = 0;

                    SK_1 = new BaseAttack(this);
                    SK_2 = new ProportionalAttack(this, 20);

                    image = imgSkeleton;
                    sprite = spSkeleton;
                    animator = amSkeleton;
                }
                break;

        }
    }
}

public class Mushroom : Character
{
    public Mushroom()
    {
        name = "¹ö¼¸¸ó";
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
        name = "½ºÄÌ·¹Åæ";
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
        name = "°íºí¸°";
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
        name = "ÀÌºí¾ÆÀÌ";
        MaxHP = 50;
        curHP = 50;
        STR = 20;
        DEF = 0;

        SK_1 = new BaseAttack(this);
        SK_2 = new PiercingAttack(this);
    }
}