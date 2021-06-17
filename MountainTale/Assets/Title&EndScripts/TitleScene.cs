using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    public Button start;
    public Button help;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChangeHelp()
    {

    }

    public void SceneChangeStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Mountain Tale");
    }

    public void SceneChangeExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
