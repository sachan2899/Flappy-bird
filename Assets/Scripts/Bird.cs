﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    public float Speed = 100.0f;
    private int score = 0;
    public Text HighScoreText;
    public GameObject GameoverPanel;
    public AudioSource BackgroundAudioSource;
    public static bool IsAlive = true;
    public Text scoreText;
    //sound
    public AudioClip DieSound;

    private AudioSource audioSource;
    void Start()
    {
        IsAlive = true;
        rigidBody2D = GetComponent<Rigidbody2D>();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidBody2D.velocity = Vector2.up * Time.deltaTime * Speed;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsAlive = false;
        audioSource.clip = DieSound;
        audioSource.Play();
        OnGameOver();
    }
    private void OnGameOver()
    {
        var Highscore = PlayerPrefs.GetInt("HighScore");
        Highscore = score > Highscore ? score : Highscore;
        PlayerPrefs.SetInt("HighScore", Highscore);
        GameoverPanel.SetActive(true);
        BackgroundAudioSource.enabled = false;

}
public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
