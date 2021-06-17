using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Box : MonoBehaviour
{
    
    private int a_RandNum = Random.Range(0, 3);
   
    public GameObject box;
    public GameObject[] Potion;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")//tag로 줄일수있다.
        {
            Instantiate(Potion[0],box.transform,false);
            Destroy(this.gameObject);
            
        }
    }

 
}
