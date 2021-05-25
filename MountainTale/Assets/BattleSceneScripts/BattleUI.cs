using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public Text name;
    public HpBar hpBar;
    public Character character;

    void Start()
    {
        SetData(character);
    }

    void Update()
    {
        SetData(character);
    }

    public void SetData(Character character)
    {
        name.text = character.GetName();
        hpBar.SetHp(character.GetCurHP() / character.GetMaxHp());
    }
}