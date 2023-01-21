using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Score { set; get; }
    public bool IsInit { get; set; }

    private string scoreInfo = "ScoreInfo";

    public int ScoreInfo
    {
        get 
        {
            return PlayerPrefs.GetInt(scoreInfo, 0);
        }
        set 
        {
            PlayerPrefs.SetInt(scoreInfo, value);
        }
    }
    private void Awake()
    {
        if(Instance == null) 
        {
            Instance = this;
            Initate();
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
            Destroy(gameObject);
    }

    private void Initate()
    {
        Score = 0;
        IsInit = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame() 
    {
        SceneManager.LoadScene(1);
    }
    
}
