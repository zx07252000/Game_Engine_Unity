using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.inputString==(transform.parent.GetComponent<Slot>().num+1).ToString() ){}
        {
            Debug.Log("HP UP ,SLOTNUMBER");
            Destroy(this.gameObject);
        }
    }
}
