using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private bool GameOver;

    public TMP_Text scoreText;

    private float score;
    private float scoreTemp;
    private int currentLevel;

    public List<int> levelTemp, levelMax;

    private void Awake()
    {
        GameManager.Instance.IsInit = true;

        score = 0;
        currentLevel = 0;
        scoreText.text = (Convert.ToInt32(score)).ToString();

        scoreTemp = levelTemp[currentLevel];
    }

    public void GameFinish() 
    {
        GameOver = true;
        GameManager.Instance.Score = (Convert.ToInt32(score));

        StartCoroutine(TheEnd());
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.LoadMenu();
    }

    private void Update()
    {
        if (GameOver) 
        {
            return;
        }

        score += scoreTemp * Time.deltaTime;

        scoreText.text = (Convert.ToInt32(score)).ToString();

        if (score > levelMax[Mathf.Clamp(currentLevel, 0, levelMax.Count - 1)]) 
        {
            currentLevel = Mathf.Clamp(currentLevel + 1, 0, levelMax.Count - 1);
            scoreTemp=levelTemp[currentLevel];
        }
    }
}
