using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Character player;
    public Character enemy;

    public BattleDialog dialog;
    public Button[] buttons = new Button[4];

    private bool PlayerTurn;

    void Start()
    {
        PlayerTurnStart();
        dialog.PrintDialog("당신의 턴!");
    }

    void Update()
    {
        if(PlayerTurn == true)
        {
            EnableButtons();
        }
        else
        {
            DisableButtons();
            dialog.PrintDialog(enemy.GetName() + "의 턴!");

            Invoke("MonsterAttackDialog", 1.0f);
            Invoke("Attack_MonsterToPlayer", 1.0f);

            Invoke("PlayerTurnDialog", 1.0f);
            PlayerTurnStart();
        }
    }

    private void PlayerTurnStart() { PlayerTurn = true; }
    private void PlayerTurnEnd() { PlayerTurn = false; }

    private void Attack_PlayerToMonster()
    {
        enemy.TakeDamage(player.GetSTR());
    }
    private void Attack_MonsterToPlayer()
    {
        player.TakeDamage(enemy.GetSTR());
    }
    private void MonsterAttackDialog()
    {
        dialog.PrintDialog(enemy.GetName() + "의 기본공격!");
    }
    private void PlayerTurnDialog()
    {
        dialog.PrintDialog("당신의 턴!");
    }

    private void EnableButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons[i].interactable = true;
        }
    }
    private void DisableButtons()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void BT_Attack_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "의 기본공격!");
        Attack_PlayerToMonster();

        Invoke("PlayerTurnEnd", 1.0f);
    }

    public void BT_DoubleAttack_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "의 이단베기!");
        Attack_PlayerToMonster();
        Invoke("Attack_PlayerToMonster", 0.3f);

        Invoke("PlayerTurnEnd", 1.0f);
    }

    public void BT_Slash_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "의 슬래쉬!");
        Attack_PlayerToMonster();
        Attack_PlayerToMonster();
        Attack_PlayerToMonster();

        Invoke("PlayerTurnEnd", 1.0f);
    }

    public void BT_RunAway_Clicked()
    {
        dialog.PrintDialog(player.GetName() + "는 도망쳤다!");
    }
}
