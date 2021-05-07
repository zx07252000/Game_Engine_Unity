using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Character player;
    public Character enemy;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.currHP = enemy.currHP - (player.dmg - enemy.def);
        }
    }
}
