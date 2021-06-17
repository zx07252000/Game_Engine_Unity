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
        //�⺻ ����: ü�� - (�� ���ݷ� - ����)
        curHP -= (damage - DEF);

        if(curHP <= 0) { curHP = 0; }
    }

    public void TakePiercingDamage(float damage)
    {
        //���� ����: ü�� - �� ���ݷ�
        curHP -= (damage);

        if (curHP <= 0) { curHP = 0; }
    }

    public void TakeProportionalDamage(float percentage)
    {
        //ü�º�� ����, damage(%) = 0~100
        curHP -= MaxHP * (percentage / 100);

        if (curHP <= 0) { curHP = 0; }
    }
}
