using System;
using System.Collections;
using System.Collections.Generic;
//using MiscUtil.Extensions.TimeRelated;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject prfGageBar;
    public GameObject canvas;
    public GameObject inventoryPanel;
    bool activeInventory = true;
    
    private Animator anim; // Animator

    Rigidbody2D rigid;
    
    
    public GameObject player;
    public float Monster_Gage = 0;
    public float Attack = 30;
    public float nowHp = 100;
    public float maxHp = 100;
    public float nowGage = 0;

    public string pName = "플레이어";
    public float DEF = 10;
    public float MaxExp = 100;
    public float curExp = 0;
    public int Level = 1;

    public int stage = 1;

    private RectTransform Gage_Bar;

    private Inventory inven;
    
    public float height = 1.7f;

    public Image now_Gagebar;
    //---------------------------------------------------[Override Function]
    //Initialization
    private void Awake()
    {
        inven = GetComponent<Inventory>();
    }

    void Start()
    {
        LoadData(); // 여기서 불러오는게 맞는건지 모르겠음..
        rigid = GetComponent<Rigidbody2D>();
        // anim ���� ����
        anim = GetComponent<Animator>();

        Gage_Bar = Instantiate(prfGageBar, canvas.transform).GetComponent<RectTransform>();

        now_Gagebar = Gage_Bar.transform.GetChild(0).GetComponent<Image>();
        inventoryPanel.SetActive(activeInventory);
        
    }
    
    //Graphic & Input Updates	
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        Vector3 velocity = new Vector3(inputX, inputZ, 0);
        velocity *= moveSpeed;
        rigid.velocity = velocity;

        Vector3 GageBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));

        Gage_Bar.position = GageBarPos;

        nowGage += 0.01f;
        now_Gagebar.fillAmount = (float) nowGage / (float) maxHp;
        if (inputX > 0)
        {
            nowGage += 0.05f;
            transform.localScale = new Vector3(5, 5, 0);
        }
        else if (inputX < 0)
        {
            nowGage += 0.05f;
            transform.localScale = new Vector3(-5, 5, 0);
        }

        if (nowGage > 100.0f)
        {
            nowGage = 0.0f;
            // 전투신으로 전환
            ChangeBattleScene();
        }
        
        Vector3 InvenPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y - height, 0));
        inventoryPanel.transform.position = InvenPos;
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        
        
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
       

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BOX")
        {
            print("OnTriggerEnter2D");
            Destroy(col.gameObject);
        }

        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
            maxHp += 10;
        
        //gameObject.SetActive(false);
        
        if (other.gameObject.tag == "Finish")
        {
            other.enabled = false;
            SceneManager.EndGame();
        }

    }

    void SaveData()
    {
        // 플레이어 정보를 전투씬으로 넘겨줌
        PlayerPrefs.SetFloat("MHP", maxHp);
        PlayerPrefs.SetFloat("HP", nowHp);
        PlayerPrefs.SetFloat("STR", Attack);
        PlayerPrefs.SetFloat("DEF", DEF);
        PlayerPrefs.SetFloat("MEXP", MaxExp);
        PlayerPrefs.SetFloat("EXP", curExp);
        PlayerPrefs.SetFloat("POSX", transform.position.x); // 플레이어가 현재 그려지고 있는 위치 posX
        PlayerPrefs.SetFloat("POSY", transform.position.y); // 플레이어가 현재 그려지고 있는 위치 posY
        PlayerPrefs.SetInt("LV", Level);
        PlayerPrefs.SetInt("LV", Level);
        PlayerPrefs.SetString("Name", pName);
    }

    void LoadData()
    {
        // 전투씬 끝나고 되돌아올때 플레이어 정보들 불러옴, 전투씬->이동씬 전환 후 1회 호출
        Attack = PlayerPrefs.GetFloat("STR");
        nowHp = PlayerPrefs.GetFloat("HP");
        maxHp = PlayerPrefs.GetFloat("MHP");

        pName = PlayerPrefs.GetString("Name");
        DEF = PlayerPrefs.GetFloat("DEF");
        MaxExp = PlayerPrefs.GetFloat("MEXP");
        curExp = PlayerPrefs.GetFloat("EXP");
        Level = PlayerPrefs.GetInt("LV");

        // POSX, POSY 두개 불러와서 전투씬 넘어가기 전 플레이어 위치를 다시 불러옴
        transform.position = new Vector3(PlayerPrefs.GetFloat("POSX"), PlayerPrefs.GetFloat("POSY"), 0);
    }

    void ChangeBattleScene()
    {
        SaveData(); // 씬 전환 전 정보 전달

        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }
}
