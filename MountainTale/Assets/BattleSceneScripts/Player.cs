using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    bool test;

    void Start()
    {
        test = true;
        if(test == true)
        {
            name = "플레이어";
            MaxHP = 100;
            curHP = 100;
            STR = 30;
            DEF = 10;
            MaxExp = 100;
            curExp = 0;
            Level = 1;
        }
        else
        {
            LoadData();
        }

        SK_1 = new BaseAttack(this);
        SK_2 = new DoubleAttack(this);
        SK_3 = new SlashAttack(this);
    }

    void LoadData()
    {
        name = PlayerPrefs.GetString("Name");
        Level = PlayerPrefs.GetInt("LV");
        MaxHP = PlayerPrefs.GetFloat("MHP");
        curHP = PlayerPrefs.GetFloat("HP");
        STR = PlayerPrefs.GetFloat("STR");
        DEF = PlayerPrefs.GetFloat("DEF");
        MaxExp = PlayerPrefs.GetFloat("MEXP");
        curExp = PlayerPrefs.GetFloat("EXP");
        transform.position = new Vector3(PlayerPrefs.GetFloat("POSX"), PlayerPrefs.GetFloat("POSY"), 0);
    }
}
