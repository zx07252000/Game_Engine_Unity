using System;
using System.Collections;
using System.Collections.Generic;
using MiscUtil.Extensions.TimeRelated;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject prfGageBar;
    public GameObject canvas;

    private Animator anim; // Animator�� �ҷ����� ���� ����

    Rigidbody2D rigid;

    public float Monster_Gage = 0;

    private RectTransform Gage_Bar;

    public float height = 1.7f;
    //---------------------------------------------------[Override Function]
    //Initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        // anim ���� ����
        anim = GetComponent<Animator>();

        Gage_Bar = Instantiate(prfGageBar, canvas.transform).GetComponent<RectTransform>();

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
        
        if (inputX > 0) transform.localScale = new Vector3(5,5,0);
        else if (inputX < 0) transform.localScale = new Vector3(-5, 5, 0);
        
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
}
