using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected string name;
    protected float power;
    protected int repeat;

    public string GetName()
    {
        return name;
    }
    public float GiveDamage()
    {
        return power * repeat;
    }
}
