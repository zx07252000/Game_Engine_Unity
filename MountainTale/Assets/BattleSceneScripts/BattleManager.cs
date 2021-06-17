using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public Character player;
    public Monster enemy;

    public BattleDialog dialog;
    public Button[] buttons;

    private Animator playerAnim;
    private Animator enemyAnim;

    private int probability;

    // ������ ���޿�
    private int result;
    private float pMHP;
    private float pHP;
    private float pSTR;
    private float pDEF;
    private string name;
    private int pLV;
    private float pMEXP;
    private float pEXP;
    private float pPosX;
    private float pPosY;

    public PlayerControl pData;

    void Start()
    {
        DisableButtons();

        playerAnim = GetComponent<Animator>();

        switch(player.curStage)
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

        if (probability == 0) { enemy.SetMonster(0); }          // �̺����
        else if (probability == 1) { enemy.SetMonster(1); }     // ����
        else if (probability == 2) { enemy.SetMonster(2); }     // ���
        else if (probability == 3) { enemy.SetMonster(3); }     // ���̷���
        else if (probability == 4) { enemy.SetMonster(4); }     // ����

        dialog.PrintDialog(enemy.GetName() + "�� ��Ÿ����!");

        playerAnim = player.GetComponent<Animator>();
        enemyAnim = enemy.GetComponent<Animator>();

        Invoke("PlayerTurn", 2.0f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad7))
        {
            player.CheatHP();
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            player.PowerOverWhelming();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            enemy.CheatHP();
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            enemy.PowerOverWhelming();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            enemy.SetMonster(4);
        }

    }

    private void PlayerTurn()
    {
        if (player.GetCurHP() <= 0)
        {
            dialog.PrintDialog(player.GetName() + "�� �������� ���Ҵ�...");
            playerAnim.SetTrigger("Death");
            result = 0;
            ChangeSceneEnd();
        }
        else
        {
            dialog.PrintDialog(player.GetName() + "�� ��!");

            EnableButtons();
        }
    }

    IEnumerator EnemyTurn()
    {
        if (enemy.GetCurHP() <= 0)
        {
            StopAllCoroutines();

            dialog.PrintDialog(enemy.GetName() + "�� ����Ʈ�ȴ�!");
            player.GetExp(enemy);

            enemyAnim.SetTrigger("Death");

            result = 1;

            if(enemy.GetName() == "����")
            {
                ChangeSceneEnd();
            }
            else
            {
                ChangeSceneStage();
            }
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
        dialog.PrintDialog(enemy.GetName() + "�� " + skName + "!");
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
        dialog.PrintDialog(player.GetName() + "�� ����!");
       
        yield return new WaitForSeconds(1);
        BasicAttack_PlayerToMonster();
        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_DoubleAttack() { StartCoroutine(BT_DoubleAttack_Clicked()); }
    IEnumerator BT_DoubleAttack_Clicked()
    {
        DisableButtons();
        dialog.PrintDialog(player.GetName() + "�� �̴ܰ���!");

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
        dialog.PrintDialog(player.GetName() + "�� ������!");

        yield return new WaitForSeconds(1);
        SlashAttack_PlayerToMonster();

        yield return new WaitForSeconds(1);
        StartCoroutine(EnemyTurn());
    }

    public void BT_RunAway_Clicked()
    {
        DisableButtons();
        player.TakeProportionalDamage(15);
        dialog.PrintDialog(player.GetName() + "�� �����ƴ�!");
        ChangeSceneStage();
    }

    void ChangeSceneEnd()
    {
        SaveData();

        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }

    void ChangeSceneStage()
    {
        SaveData();

        switch(player.curStage)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MountainTale");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Stage2");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Stage3");
                break;
        }
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("Win", result);
        //PlayerPrefs.SetFloat("MHP", player.GetMaxHp());
        //PlayerPrefs.SetFloat("HP", player.GetCurHP());
        //PlayerPrefs.SetFloat("STR", player.GetSTR());
        //PlayerPrefs.SetFloat("DEF", player.GetDEF());
        //PlayerPrefs.SetInt("LV", player.Level);
        //PlayerPrefs.SetInt("Stage", player.curStage);
        //PlayerPrefs.SetFloat("MEXP", player.MaxExp);
        //PlayerPrefs.SetFloat("EXP", player.curExp);
        //PlayerPrefs.SetFloat("POSX", player.posX);
        //PlayerPrefs.SetFloat("POSY", player.posY);
        //PlayerPrefs.SetString("Name", player.GetName());

        pData.pName = player.GetName();
        pData.maxHp = player.GetMaxHp();
        pData.nowHp = player.GetCurHP();
        pData.Attack = player.GetSTR();
        pData.DEF = player.GetDEF();
        pData.MaxExp = player.MaxExp;
        pData.curExp = player.curExp;
        pData.Level = player.Level;
        pData.stage = player.curStage;
        pData.transform.position = new Vector3(player.posX, player.posY, 0);
    }
}
