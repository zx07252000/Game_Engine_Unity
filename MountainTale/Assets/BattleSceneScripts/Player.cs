using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    bool test;

    void Start()
    {
        test = false;

        if(test == true)
        {
            name = "테스트";
            MaxHP = 100;
            curHP = 100;
            STR = 30;
            DEF = 10;
            MaxExp = 100;
            curExp = 0;
            Level = 1;
            curStage = 1;
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
        curStage = PlayerPrefs.GetInt("Stage");
        MaxHP = PlayerPrefs.GetFloat("MHP");
        curHP = PlayerPrefs.GetFloat("HP");
        STR = PlayerPrefs.GetFloat("STR");
        DEF = PlayerPrefs.GetFloat("DEF");
        MaxExp = PlayerPrefs.GetFloat("MEXP");
        curExp = PlayerPrefs.GetFloat("EXP");
        posX = PlayerPrefs.GetFloat("POSX");
        posY = PlayerPrefs.GetFloat("POSY");
    }
}
