using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public TMP_Text score;
    public TMP_Text bestText;
    public TMP_Text bestScore;

    public float timeAnimation;
    public AnimationCurve animationCurve;

    public AudioClip audioClip;

    
    private void Awake()
    {
        bestScore.text = GameManager.Instance.ScoreInfo.ToString();

        if (!GameManager.Instance.IsInit)
        {
            score.gameObject.SetActive(false);
            bestScore.gameObject.SetActive(false);
        }
        else 
        {
            StartCoroutine(ShowScore());
        }
    }

    IEnumerator ShowScore() 
    {
        int temp = 0;

        score.text = temp.ToString();

        int _currentScore = GameManager.Instance.Score;
        int _bestScore=GameManager.Instance.ScoreInfo;

        if (_bestScore < _currentScore)
        {
            bestScore.gameObject.SetActive(true);
            GameManager.Instance.ScoreInfo = _currentScore;
        }
        else 
        {
            bestScore.gameObject.SetActive(false);
        }

        float speed = 1 / timeAnimation;
        float time = 0f;

        while (time < 1f) 
        {
            time += speed * Time.deltaTime;
            temp = Convert.ToInt32(animationCurve.Evaluate(time) * _currentScore);

            score.text = temp.ToString();

            yield return null;
        }

        temp = _currentScore;

        score.text = temp.ToString();
    }

    public void AudioPlay() 
    {
        SoundManager.Instance.PlaySound(audioClip);
        GameManager.Instance.LoadGame();
    }

}
