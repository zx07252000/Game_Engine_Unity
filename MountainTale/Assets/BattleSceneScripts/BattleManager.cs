using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Character player;
    public Monster enemy;

    public BattleDialog dialog;
    public Button[] buttons;

    private Animator playerAnim;
    private Animator enemyAnim;

    void Start()
    {
        DisableButtons();

        playerAnim = GetComponent<Animator>();

        int probability = Random.Range(0, 4);
        if (probability == 0) { enemy.SetMonster(0); }
        else if (probability == 1) { enemy.SetMonster(1); }
        else if (probability == 2) { enemy.SetMonster(2); }
        else if (probability == 3) { enemy.SetMonster(3); }

        dialog.PrintDialog(enemy.GetName() + "이 나타났다!");

        playerAnim = player.GetComponent<Animator>();
        enemyAnim = enemy.GetComponent<Animator>();

        Invoke("PlayerTurn", 2.0f);
    }

    private void PlayerTurn()
    {
        if (player.GetCurHP() <= 0)
        {
            dialog.PrintDialog(player.GetName() + "는 쓰러지고 말았다...");
            playerAnim.SetTrigger("Death");
        }
        else
        {
            dialog.PrintDialog(player.GetName() + "의 턴!");

            EnableButtons();
        }
    }

    IEnumerator EnemyTurn()
    {
        if (enemy.GetCurHP() <= 0)
        {
            dialog.PrintDialog(enemy.GetName() + "를 쓰러트렸다!");
            enemyAnim.SetTrigger("Death");
            StopAllCoroutines();
        }
        else
        {
            MonsterAttackDialog();

            yield return new WaitForSeconds(1);
            Attack_MonsterToPlayer();

            yield return new WaitForSeconds(1);
            PlayerTurn();
        }
    }

    private void Attack_PlayerToMonster()
    {
        playerAnim.SetTrigger("BasicAttack");
        enemy.TakeDamage(player.GetSTR());
        enemyAnim.SetTrigger("Damaged");
    }
    private void Attack_MonsterToPlayer()
    {
        enemyAnim.SetTrigger("BasicAttack");
        player.TakeDamage(enemy.GetSTR());
        playerAnim.SetTrigger("Damaged");
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

    public void BT_Attack() { StartCoroutine(BT_Attack_Clicked()); }
    IEnumerator BT_Attack_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "의 기본공격!");
       
        yield return new WaitForSeconds(1);
        Attack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_DoubleAttack() { StartCoroutine(BT_DoubleAttack_Clicked()); }
    IEnumerator BT_DoubleAttack_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "의 이단베기!");

        yield return new WaitForSeconds(1);
        Attack_PlayerToMonster();
        yield return new WaitForSeconds(1);
        Attack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_Slash() { StartCoroutine(BT_Slash_Clicked()); }
    IEnumerator BT_Slash_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "의 슬래쉬!");

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
        dialog.PrintDialog(player.GetName() + "는 도망쳤다!");
    }
}
