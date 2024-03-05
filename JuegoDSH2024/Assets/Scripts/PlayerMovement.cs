using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 PlayerDirection;
    public float PlayerSpeed;
    public GroundSpawnerScript groundSpawner;
    public float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject RestartMenu;

    private float highScore;

    void Start()
    {
        PlayerDirection = Vector3.left;
        RestartMenu.SetActive(false);

        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void Update()
    {
        playerController();
        transform.position += getPlayerDirection() * PlayerSpeed * Time.deltaTime;
        scoreText.text = "" + score;
    }

    public Vector3 getPlayerDirection()
    {
        return PlayerDirection;
    }

    private void playerController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        if (PlayerDirection.x == -1)
        {
            PlayerDirection = Vector3.forward;
        }
        else
        {
            PlayerDirection = Vector3.left;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            groundSpawner.RandonGround2();
            score += 1;

            // Check if the current score beats the high score
            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = "High Score: " + highScore.ToString();

                // Save the new high score to PlayerPrefs
                PlayerPrefs.SetFloat("HighScore", highScore);
                PlayerPrefs.Save();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            Time.timeScale = 0f;
            RestartMenu.SetActive(true);
        }
    }

    public void RestartBtn()
    {
        Time.timeScale = 1f;
        RestartMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
