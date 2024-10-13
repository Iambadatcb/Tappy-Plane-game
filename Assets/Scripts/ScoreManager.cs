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
    public TextMeshProUGUI[] topScores;
    public AudioClip failSound;


    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowScoreBoard(int score)
    {
        audioSource.PlayOneShot(failSound);
        scoreBoard.SetActive(true);
        scoreText.text = score.ToString("D4");

        var best = PlayerPrefs.GetInt("HighScore", 0);
        if (score > best)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("D4");
            for (int i = 1; i<topScores.Length; i++)
            {
                if (Convert.ToInt32(topScores[i].text) < score)
                {
                    topScores[i].text = score.ToString("D4");
                    break;
                }
                
                
            }
            topScores[0].text = score.ToString("D4");
            medal.sprite = medals[0];
        }
        else
        {
            topScores[0].text = best.ToString("D4");
            highScoreText.text = best.ToString("D4");
            medal.sprite = medals[1];
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
