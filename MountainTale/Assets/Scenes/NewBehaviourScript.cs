using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 1f;

    private Animator anim; // Animator�� �ҷ����� ���� ����

    Rigidbody2D rigid;

    //---------------------------------------------------[Override Function]
    //Initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        // anim ���� ����
        anim = GetComponent<Animator>();
    }

    //Graphic & Input Updates	
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        // -1 ~ 1

        Vector3 velocity = new Vector3(inputX, inputZ , 0 );
        velocity *= moveSpeed;
        rigid.velocity = velocity;

        // ���ϸ��̼� MoveX, MoveY
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
