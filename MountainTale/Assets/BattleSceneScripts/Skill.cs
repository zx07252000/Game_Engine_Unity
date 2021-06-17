using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected string name;

    protected Character owner;
    protected int percentage;

    public string GetName()
    {
        return name;
    }

    public virtual void Action(Character target)
    {

    }
}

public class BaseAttack : Skill
{
    public BaseAttack(Character character)
    {
        name = "�⺻ ����";
        owner = character;
    }

    public override void Action(Character target)
    {
        target.TakeDamage(owner.GetSTR());
    }
}

public class DoubleAttack : Skill
{
    public DoubleAttack(Character character)
    {
        name = "�̴� ����";
        owner = character;
    }

    public override void Action(Character target)
    {
        target.TakeDamage(owner.GetSTR() * 0.8f);
    }
}

public class SlashAttack : Skill
{
    public SlashAttack(Character character)
    {
        name = "������";
        owner = character;
    }

    public override void Action(Character target)
    {
        target.TakeDamage(owner.GetSTR() * 1.5f );
    }
}

public class PiercingAttack : Skill
{
    public PiercingAttack(Character character)
    {
        name = "���� ����";
        owner = character;
    }

    public override void Action(Character target)
    {
        target.TakePiercingDamage(owner.GetSTR());
    }
}

public class ProportionalAttack : Skill
{
    public ProportionalAttack(Character character, int per)
    {
        name = "ü�� ��� ����";
        owner = character;
        percentage = per;
    }

    public override void Action(Character target)
    {
        target.TakeProportionalDamage(percentage);
    }
}