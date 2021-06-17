using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Inventory inven = other.GetComponent<Inventory>();
            for (int i = 0; i < inven._slots.Count; i++)
            {
                if (inven._slots[i].isEmpty)
                {
                    Instantiate(slotItem, inven._slots[i].slotObj.transform, false);
                    inven._slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }
            
        }
    }
}
