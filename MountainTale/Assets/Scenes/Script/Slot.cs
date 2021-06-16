using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int i;
    private Inventory inventory;

    private void Awake() {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    private void Update() {
        if(transform.childCount <= 0) {
            inventory.fullCheck[i] = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            RemoveItem1();
        }
    }

    public void RemoveItem1() {
        for (int idx = 0; idx < transform.childCount; idx++) {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
}
