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
}
    
