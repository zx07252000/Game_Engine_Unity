using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryPanel;
    
    public bool[] fullCheck;
    public GameObject[] slots;
    
    
    // Start is called before the first frame update
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x-2,
            player.transform.position.y-2,
            player.transform.position.z );
        
    }
}
