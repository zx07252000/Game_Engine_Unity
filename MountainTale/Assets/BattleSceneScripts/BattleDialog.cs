using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialog : MonoBehaviour
{
    public Text battletext;

    public void SetDialog(string dialog)
    {
        battletext.text = dialog;
    }

}
