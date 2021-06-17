using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hp : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())

        {
            Debug.Log("HP UP , SLOTNUMBER : "+(transform.parent.GetComponent<Slot>().num+1));
            Destroy(this.gameObject);
        }
    }
}
