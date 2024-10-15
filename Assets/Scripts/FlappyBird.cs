using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float jumpForce = 100;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public AudioClip successSound;
    public AudioClip flap;
    
    public AudioClip hit;
    public AudioClip fall;


    private AudioSource audioSource;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (rb.velocity.y < 0)
            {
                audioSource.PlayOneShot(flap);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            //animations
            if (rb.velocity.y > 0)
            {

                transform.rotation = Quaternion.Euler(0, 0, 30);
            }
            else if (rb.velocity.y < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -30);
            }
        }



    }

    void OnTriggerExit2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString("D4");
        audioSource.PlayOneShot(successSound);
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.PlayOneShot(hit);
        audioSource.PlayOneShot(fall);
        scoreManager.ShowScoreBoard(score);
        Invoke("Die", 0.5f);
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
