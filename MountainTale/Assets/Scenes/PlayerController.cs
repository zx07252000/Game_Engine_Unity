using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 1f;

	private Animator anim; // Animator�� �ҷ����� ���� ����

	Rigidbody2D rigid;

	Vector3 movement;
	bool isJumping = false;

	//---------------------------------------------------[Override Function]
	//Initialization
	void Start()
	{
		rigid = gameObject.GetComponent<Rigidbody2D>();
		// anim ���� ����
		anim = GetComponent<Animator>();

	
	}

	//Graphic & Input Updates	
	void Update()
	{
	// ����, ���������� �����̱�
	if (Input.GetAxisRaw("Horizontal") < 0f) 
		{
			transform.localScale = new Vector3(-5, 5, 5);
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f)); 
		} 
	else if(Input.GetAxisRaw("Horizontal") > 0f)
        {
			transform.localScale = new Vector3(5, 5, 5);
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
		}
	// ��, �Ʒ��� �����̱�
		if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f) 
		{ 
			transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f)); 
		}
		// ���ϸ��̼� MoveX, MoveY
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));


	}


}
