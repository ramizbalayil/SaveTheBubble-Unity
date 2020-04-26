using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameObject HUD;
    public GameObject GSM;
    public GameObject GameTimer;

    public float moveSpeed = 10f;

    Rigidbody2D rb;
    Vector2 direction;
    bool dead = false;
    int score = 0;
    int high_score = 0;
    int score_increment = 10;
    TextMeshProUGUI score_text;

    // Use this for initialization
    void Start()
    {
        high_score = PlayerPrefs.GetInt("HighScore", 0);
        rb = GetComponent<Rigidbody2D>();
        score_text = HUD.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        score_text.SetText(score.ToString());
    }

    void GetAccelerometerReading()
    {
        direction.x = -Input.acceleration.x * moveSpeed;
        direction.y = -Input.acceleration.y * moveSpeed;
    }

    void GetKeyboardReading()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction.x = -3;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction.x = 3;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction.y = 3;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction.y = -3;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameTimer.GetComponent<Timer>().timer_running) { return; }

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1.0f)
        {
            GSM.GetComponent<GameStateManager>().PauseGame();
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0.0f)
        {
            GSM.GetComponent<GameStateManager>().ResumeGame();
            return;
        }

        if (dead)
        {
            return;
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            GetAccelerometerReading();
        }
        else
        {
            GetKeyboardReading();
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y);
    }

    void FixedUpdate()
    {
        if (!dead)
        {
            rb.velocity = new Vector2(direction.x, direction.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AudioManager.instance.PlaySound("bubble_pop");
            animator.SetBool("Dead", true);
            dead = true;
        }
        else if (collision.tag == "Collectibles")
        {
            AudioManager.instance.PlaySound("coin_collect");
            score += score_increment;
            score_text.SetText(score.ToString());
            Destroy(collision.gameObject);
        }
    }

    public void KillPlayer()
    {
        if(score > high_score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        GSM.GetComponent<GameStateManager>().ShowNewHighScore(score > high_score);
        GSM.GetComponent<GameStateManager>().GameOver();
        Destroy(gameObject);
    }
}
