using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public RuntimeAnimatorController animator;
    protected AnimationClip animClip;
    protected Sprite sprite;

    protected string name;
    protected float MaxHP;
    protected float curHP;
    protected float STR;
    protected float DEF;

    public int Level;
    public float MaxExp;
    public float curExp;
    public float reword;
    public int curStage;

    public float posX;
    public float posY;

    public Skill SK_1;
    public Skill SK_2;
    public Skill SK_3;

    public string GetName() { return name; }
    public float GetMaxHp() { return MaxHP; }
    public float GetCurHP() { return curHP; }
    public float GetSTR() { return STR; }
    public float GetDEF() { return DEF; }

    public void TakeDamage(float damage)
    {
        //기본 피해: 체력 - (적 공격력 - 방어력)
        curHP -= (damage - DEF);

        if(curHP <= 0) { curHP = 0; }
    }

    public void TakePiercingDamage(float damage)
    {
        //방어무시 피해: 체력 - 적 공격력
        curHP -= (damage);

        if (curHP <= 0) { curHP = 0; }
    }

    public void TakeProportionalDamage(float percentage)
    {
        //체력비례 피해, damage(%) = 0~100
        curHP -= MaxHP * (percentage / 100);

        if (curHP <= 0) { curHP = 0; }
    }

    public void GetExp(Character enemy)
    {
        curExp += enemy.reword;

        if(curExp >= MaxExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level += 1;

        MaxHP += 20;
        curHP += 20;
        STR += 10;
        DEF += 5;

        curExp -= MaxExp;
        MaxExp += 100;
    }
}
