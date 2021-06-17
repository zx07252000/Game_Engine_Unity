using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryPanel;
    
    //public bool[] fullCheck;
    //public GameObject[] slots;

    public List<SlotData> _slots = new List<SlotData>();
    private int maxSlot = 4;
    public GameObject slotPrefab;
    
    // Start is called before the first frame update
    private void Start()
    {
        GameObject slotPanel = GameObject.Find("Panel");

        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_"+i;
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = go;
            _slots.Add(slot);
        }
    }

    // Update is called once per frame
    /*private void Update()
    {
        transform.position = new Vector3(player.transform.position.x-2,
            player.transform.position.y-2,
            player.transform.position.z );
        
    }*/
}
