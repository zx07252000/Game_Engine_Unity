using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public GameObject healthpoint;
    
    void Start()
    {
        healthpoint.transform.localScale = new Vector3(1.0f, 1.0f);
    }

    public void SetHp(float hpNormalized)
    {
        healthpoint.transform.localScale = new Vector3(hpNormalized, 1f);
    }
}
