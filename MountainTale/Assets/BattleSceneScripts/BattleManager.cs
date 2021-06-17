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

    public int stage;
    private int probability;

    void Start()
    {
        DisableButtons();

        playerAnim = GetComponent<Animator>();

        stage = 1;

        switch(stage)
        {
            case 1:
                probability = Random.Range(0, 2);
                break;
            case 2:
                probability = Random.Range(1, 3);
                break;
            case 3:
                probability = Random.Range(2, 4);
                break;
            case 4:
                probability = 4;
                break;
        }

        if (probability == 0) { enemy.SetMonster(0); }          // 이블아이
        else if (probability == 1) { enemy.SetMonster(1); }     // 버섯
        else if (probability == 2) { enemy.SetMonster(2); }     // 고블린
        else if (probability == 3) { enemy.SetMonster(3); }     // 스켈레톤
        else if (probability == 4) { enemy.SetMonster(4); }     // 보스

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
            StopAllCoroutines();
            dialog.PrintDialog(enemy.GetName() + "를 쓰러트렸다!");
            player.GetExp(enemy);
            enemyAnim.SetTrigger("Death");
        }
        else
        {
            switch(enemy.ChooseSkill())
            {
                case 1:
                    {
                        MonsterAttackDialog(enemy.SK_1.GetName());
                        yield return new WaitForSeconds(1);
                        Skill1_MonsterToPlayer();

                    }
                    break;
                case 2:
                    {
                        MonsterAttackDialog(enemy.SK_2.GetName());
                        yield return new WaitForSeconds(1);
                        Skill2_MonsterToPlayer();
                    }
                    break;
                case 3:
                    {
                        MonsterAttackDialog(enemy.SK_3.GetName());
                        yield return new WaitForSeconds(1);
                        Skill3_MonsterToPlayer();
                    }
                    break;
            }

            yield return new WaitForSeconds(1);
            PlayerTurn();
        }
    }

    private void BasicAttack_PlayerToMonster()
    {
        playerAnim.SetTrigger("BasicAttack");
        player.SK_1.Action(enemy);
        enemyAnim.SetTrigger("Damaged");
    }
    private void DoubleAttack_PlayerToMonster()
    {
        playerAnim.SetTrigger("BasicAttack");
        player.SK_2.Action(enemy);
        enemyAnim.SetTrigger("Damaged");
    }
    private void SlashAttack_PlayerToMonster()
    {
        playerAnim.SetTrigger("BasicAttack");
        player.SK_3.Action(enemy);
        enemyAnim.SetTrigger("Damaged");
    }

    private void Skill1_MonsterToPlayer()
    {
        enemyAnim.SetTrigger("BasicAttack");
        enemy.SK_1.Action(player);
        playerAnim.SetTrigger("Damaged");
    }
    private void Skill2_MonsterToPlayer()
    {
        enemyAnim.SetTrigger("Skill");
        enemy.SK_2.Action(player);
        playerAnim.SetTrigger("Damaged");
    }
    private void Skill3_MonsterToPlayer()
    {
        enemyAnim.SetTrigger("Skill2");
        enemy.SK_3.Action(player);
        playerAnim.SetTrigger("Damaged");
    }

    private void MonsterAttackDialog(string skName)
    {
        dialog.PrintDialog(enemy.GetName() + "의 " + skName + "!");
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
        BasicAttack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_DoubleAttack() { StartCoroutine(BT_DoubleAttack_Clicked()); }
    IEnumerator BT_DoubleAttack_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "의 이단베기!");

        yield return new WaitForSeconds(1);
        DoubleAttack_PlayerToMonster();
        yield return new WaitForSeconds(1);
        DoubleAttack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_Slash() { StartCoroutine(BT_Slash_Clicked()); }
    IEnumerator BT_Slash_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "의 슬래쉬!");

        yield return new WaitForSeconds(1);
        SlashAttack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_RunAway_Clicked()
    {
        DisableButtons();
        player.TakeProportionalDamage(15);
        dialog.PrintDialog(player.GetName() + "는 도망쳤다!");
    }
}
