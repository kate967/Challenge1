using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Door;
    public GameObject Player;
    public float speed;

    public Text countText;
    public Text scoreText;
    public Text livesText;
    public Text winText;
    public Text loseText;

    private Rigidbody rb;

    private int count;
    private int score;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        score = 0;
        lives = 3;

        SetScoreText();
        SetCountText();
        SetLivesText();

        winText.text = "";
        loseText.text = "";
    }

    void Update()
    {
        //make teleporter active at score 12
        if(score>=12)
        {
            Door.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //teleports player to lvl 2
        if (other.gameObject.CompareTag("Door"))
        {
            transform.position = new Vector3(100, 2, -13);
        }

        /*have pick up setactive false on collision
          and +1 to both score and counter*/
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            score = score + 1;
            SetScoreText();
        }
        /*similiar to pick up, except the enemy
          will +1 to the count and -1 from the score.
          will also -1 from players lives*/
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            score = score - 1;
            SetScoreText();
            lives = lives - 1;
            SetLivesText();
        }
    }

    //functions for all three counters: count, score, and lives
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetScoreText()
    {
        scoreText.text = "POINTS: " + score.ToString();

        if (score >= 20)
         {
             winText.text = "YAY! YOU WIN!!!";
         }
    }

    void SetLivesText()
    {
        livesText.text = "Health: " + lives.ToString();

        //destroys player object when lives 0 is reached
        if (lives == 0)
        {
            GameObject.Destroy(Player);
            loseText.text = "WOW. YOU DIED.";
        }
    }

}


