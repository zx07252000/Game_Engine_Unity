using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    protected Image image;
    protected Sprite sprite;
    protected Animator animator;

    protected string name;
    protected float MaxHP;
    protected float curHP;
    protected float STR;
    protected float DEF;

    protected Skill SK_1;
    protected Skill SK_2;
    protected Skill SK_3;
    protected Skill SK_4;

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
}
