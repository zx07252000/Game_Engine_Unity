using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject Player;

    Vector3 StartingPos;
    Quaternion StartingRotate;
    bool isStarted = false;
    static bool isEnded = false;

    static int stageLevel = 0;

    void Awake()
    {
        Time.timeScale = 0f;
    }
    void Start()
    {
        StartingPos = GameObject.FindGameObjectWithTag("Start").transform.position;
        StartingRotate = GameObject.FindGameObjectWithTag("Start").transform.rotation;
        if (stageLevel > 0) StartGame();
        
    }
    
    void OnGUI()
    {
        //Stage GUI
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        if (stageLevel < 3)
            GUILayout.Label(" Stage" + (stageLevel + 1));
        else
            GUILayout.Label(" Stage End");
        GUILayout.Space(5);
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

        if (!isStarted && stageLevel == 0)
        { 
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        GUILayout.Label("Are you Ready?! :)");

        if (GUILayout.Button("Start!"))
        {
            isStarted = true;
            StartGame();
        }

        GUILayout.Space(100);
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();       
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

        else if (isEnded && stageLevel == 3)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            GUILayout.Label("Clear! :D");

            if (GUILayout.Button("ReStart?"))
            {
                
                isEnded = false;
                stageLevel = 0;
                UnityEngine.SceneManagement.SceneManager.LoadScene(0, LoadSceneMode.Single);
         

            }

            GUILayout.Space(100);
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

        }
    }
    

    void StartGame()
    {
        Time.timeScale = 1f;

        GameObject standingCamera = GameObject.FindGameObjectWithTag("PlayerCamera");
        standingCamera.SetActive(false);

        StartingPos = new Vector3(StartingPos.x, StartingPos.y + 2f, StartingPos.z);
        Instantiate(Player, StartingPos, StartingRotate);
    }

    public static void EndGame()
    {
        Time.timeScale = 0f;

        stageLevel++;

        if (stageLevel == 3)
        {
            isEnded = true;
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);
            
        }
            
    }
    
}
