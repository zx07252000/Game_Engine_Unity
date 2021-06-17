using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public Text text1;

    public int win;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        if(win == 1)
        {
            text1.text = "GAME CLEAR";
            text1.color = Color.blue;
        }
        else
        {
            text1.text = "YOU DIED";
            text1.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneChange();
        }
    }

    public void SceneChange()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    void LoadData()
    {
        win = PlayerPrefs.GetInt("Win");
    }
}
