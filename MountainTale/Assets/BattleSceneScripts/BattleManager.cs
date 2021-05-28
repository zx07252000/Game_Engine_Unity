using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Character player;
    public Character enemy;

    public BattleDialog dialog;
    public Button[] buttons;

    private Animator playerAnim;

    void Start()
    {
        DisableButtons();

        playerAnim = GetComponent<Animator>();

        dialog.PrintDialog(enemy.GetName() + "�� ��Ÿ����!");


        Invoke("PlayerTurn", 2.0f);
    }

    private void PlayerTurn()
    {
        EnableButtons();

        dialog.PrintDialog(player.GetName() + "�� ��!");
    }

    IEnumerator EnemyTurn()
    {
        MonsterAttackDialog();

        yield return new WaitForSeconds(1);
        Attack_MonsterToPlayer();

        yield return new WaitForSeconds(1);
        PlayerTurn();
    }

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
        dialog.PrintDialog(enemy.GetName() + "�� �⺻����!");
    }
    private void PlayerTurnDialog()
    {
        dialog.PrintDialog("����� ��!");
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

    public void BT_Attack() { StartCoroutine(BT_Attack_Clicked()); }
    IEnumerator BT_Attack_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "�� �⺻����!");
       
        yield return new WaitForSeconds(1);
        Attack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_DoubleAttack() { StartCoroutine(BT_DoubleAttack_Clicked()); }
    IEnumerator BT_DoubleAttack_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "�� �̴ܺ���!");

        yield return new WaitForSeconds(1);
        Attack_PlayerToMonster();
        yield return new WaitForSeconds(0.3f);
        Attack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_Slash() { StartCoroutine(BT_Slash_Clicked()); }
    IEnumerator BT_Slash_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "�� ������!");

        yield return new WaitForSeconds(1);
        Attack_PlayerToMonster();
        Attack_PlayerToMonster();
        Attack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_RunAway_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "�� �����ƴ�!");
    }
}
