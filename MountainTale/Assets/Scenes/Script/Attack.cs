using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())

        {
            GameObject.Find("Player").GetComponent<PlayerControl>().Attack_p();
            
            
            Debug.Log("HP UP , SLOTNUMBER : "+(transform.parent.GetComponent<Slot>().num+1));
            Destroy(this.gameObject);
        }
    }
}
