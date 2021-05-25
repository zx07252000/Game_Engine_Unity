using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Character player;
    public Character enemy;

    public BattleDialog dialog;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.TakeDamage(player.GetSTR());
        }
    }

    private void Attack_PlayerToMonster()
    {
        enemy.TakeDamage(player.GetSTR());
    }

    public void BT_Attack_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "의 기본공격!");
        Attack_PlayerToMonster();
    }

    public void BT_DoubleAttack_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "의 이단베기!");
        Attack_PlayerToMonster();
        Invoke("Attack_PlayerToMonster", 0.3f);
    }

    public void BT_Slash_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "의 슬래쉬!");
        Attack_PlayerToMonster();
        Attack_PlayerToMonster();
        Attack_PlayerToMonster();
    }

    public void BT_RunAway_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "는 도망쳤다!");
    }
}
