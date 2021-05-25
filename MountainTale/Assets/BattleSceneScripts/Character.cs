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

    public string GetName() { return name; }
    public float GetMaxHp() { return MaxHP; }
    public float GetCurHP() { return curHP; }
    public int GetSTR() { return STR; }
    public int GetDEF() { return DEF; }

    public void TakeDamage(int damage)
    {
        curHP -= (damage - DEF);

        if(curHP <= 0) { curHP = 0; }
    }
}
