using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   Inventory _inventory;
   public int num;

   private void Start()
   {
      _inventory = GameObject.Find("Player").GetComponent<Inventory>();
      num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));
   }

   private void Update()
   {
      if (transform.childCount <= 0)
      {
         _inventory._slots[num].isEmpty = true;
      }
   }
}
