using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected string name;
    protected float MaxHP;
    protected float curHP;
    protected int STR;
    protected int DEF;

    protected Skill SK_1;
    protected Skill SK_2;
    protected Skill SK_3;
    protected Skill SK_4;

    public string GetName() { return name; }
    public float GetMaxHp() { return MaxHP; }
    public float GetCurHP() { return curHP; }
    public int GetSTR() { return STR; }
    public int GetDEF() { return DEF; }

    public void TakeDamage(int damage)
    {
        //기본 피해: 체력 - (적 공격력 - 방어력)
        curHP -= (damage - DEF);

        if(curHP <= 0) { curHP = 0; }
    }

    public void TakePiercingDamage(int damage)
    {
        //방어무시 피해: 체력 - 적 공격력
        curHP -= (damage);

        if (curHP <= 0) { curHP = 0; }
    }

    public void TakeProportionalDamage(int percentage)
    {
        //체력비례 피해, damage(%) = 0~100
        curHP -= MaxHP * (percentage / 100);

        if (curHP <= 0) { curHP = 0; }
    }
}
