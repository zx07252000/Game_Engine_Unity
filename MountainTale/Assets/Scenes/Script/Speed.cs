using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())

        {
            GameObject.Find("Player").GetComponent<PlayerControl>().Speed_p();
            
            
            Debug.Log("HP UP , SLOTNUMBER : "+(transform.parent.GetComponent<Slot>().num+1));
            Destroy(this.gameObject);
        }
    }
}
