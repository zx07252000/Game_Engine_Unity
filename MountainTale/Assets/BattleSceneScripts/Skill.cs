using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected string name;

    protected int power;
    protected int percentage;

    public string GetName()
    {
        return name;
    }
}

public class BaseAttack : Skill
{
    public BaseAttack(Character character)
    {
        name = "기본 공격";
        power = character.GetSTR();
    }

    IEnumerator Action(Character target)
    {
        target.TakeDamage(power);
        yield return 0;
    }
}

public class DoubleAttack : Skill
{
    public DoubleAttack(Character character)
    {
        name = "이단 공격";
        power = character.GetSTR();
    }

    IEnumerator Action(Character target)
    {
        target.TakeDamage(power);
        yield return new WaitForSeconds(0.3f);
        target.TakeDamage(power);
    }
}

public class PiercingAttack : Skill
{
    public PiercingAttack(Character character)
    {
        name = "관통 공격";
        power = character.GetSTR();
    }

    IEnumerator Action(Character target)
    {
        target.TakePiercingDamage(power);
        yield return 0;
    }
}

public class ProportionalAttack : Skill
{
    public ProportionalAttack(Character character, int percentage)
    {
        name = "체력 비례 공격";
        power = character.GetSTR();
    }

    IEnumerator Action(Character target)
    {
        target.TakePiercingDamage(percentage);
        yield return 0;
    }
}