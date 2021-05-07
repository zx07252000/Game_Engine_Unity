using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public float MaxHP;
    public float currHP;
    public int dmg;
    public int def;

    public string GetName() { return name; }
    public float GetMaxHp() { return MaxHP; }
    public int GetDmg() { return dmg; }
    public int GetDef() { return def; }
}
