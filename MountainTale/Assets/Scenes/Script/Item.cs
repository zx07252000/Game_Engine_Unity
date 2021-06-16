using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemStat;
    public Sprite itemIcon;

    private Inventory Iv;
    public GameObject itemObject;
    private Slot slot;

    private void Awake()
    {
        Iv = GameObject.FindObjectOfType<Inventory>();
        slot = GameObject.FindObjectOfType<Slot>();
    }

    void AddItem()
    {
        //if(!Iv.AddItem(this))
        //Debug.Log("아이템이 꽉 참");
        //else
        //{
        //gameObject.SetActive(false);
        //}
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            for (int i = 0; i < Iv.slots.Length; i++)
            {
                if (Iv.fullCheck[i] == false)
                {
                    Iv.fullCheck[i] = true;
                    transform.position = new Vector3(0,
                        -0.2f,
                        0 );
                    Instantiate(itemObject, Iv.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
    
