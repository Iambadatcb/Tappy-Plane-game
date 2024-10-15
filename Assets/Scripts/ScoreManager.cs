using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{

    public GameObject scoreBoard;

    public Image medal;

    public Sprite[] medals;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScoreText;
    
    // public AudioClip failSound;


    // private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.SetActive(false);
        // audioSource = GetComponent<AudioSource>();
    }

    public void ShowScoreBoard(int score)
    {
        // audioSource.PlayOneShot(failSound);
        scoreBoard.SetActive(true);
        scoreText.text = score.ToString("D4");

        var best = PlayerPrefs.GetInt("HighScore", 0);
        var secondBest = PlayerPrefs.GetInt("SecondBest", 0);
        if (score > best && score > secondBest)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.SetInt("SecondBest", best);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("D4");
            medal.sprite = medals[0];
        }
        else if (score > secondBest)
        {
            PlayerPrefs.SetInt("SecondBest", score);
            PlayerPrefs.Save();
            highScoreText.text = best.ToString("D4");
            medal.sprite = medals[1];
        }
        else
        {
            
            highScoreText.text = best.ToString("D4");
            medal.sprite = medals[2];
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
