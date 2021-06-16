using System;
using System.Collections;
using System.Collections.Generic;
using MiscUtil.Extensions.TimeRelated;
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
    public float Attack = 1;
    public float nowHp = 100;
    public float maxHp = 100;
    public float nowGage = 0;

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
            // 여기다 전투씬 대입
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
}
