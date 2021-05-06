using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 1f;

	private Animator anim; // Animator를 불러오기 위한 변수

	Rigidbody2D rigid;

	Vector3 movement;
	bool isJumping = false;

	//---------------------------------------------------[Override Function]
	//Initialization
	void Start()
	{
		rigid = gameObject.GetComponent<Rigidbody2D>();
		// anim 변수 선언
		anim = GetComponent<Animator>();

	
	}

	//Graphic & Input Updates	
	void Update()
	{
	// 왼쪽, 오른쪽으로 움직이기
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
	// 위, 아래로 움직이기
		if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f) 
		{ 
			transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f)); 
		}
		// 에니메이션 MoveX, MoveY
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));


	}


}
