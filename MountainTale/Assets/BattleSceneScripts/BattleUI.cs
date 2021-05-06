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

    public void SetData(Character crt)
    {
        name.text = crt.name;
        hpBar.SetHp((float)(crt.MaxHP / crt.currHP));
    }
}