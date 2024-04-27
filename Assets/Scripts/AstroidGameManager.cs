using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AstroidGameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public ParticleSystem deathParticle;

    private bool IsPlayerAlive;

    private int score = 0;

    private void Start()
    {
        IsPlayerAlive = true;
        scoreText.text = "Score : " + score;
    }

    public void OnPlayerDeath(Vector3 pos)
    {
        IsPlayerAlive = false;
        
        // Show death particle
        Instantiate(deathParticle, pos, Quaternion.identity);
        
        // add delay to restart the game 
        Invoke(nameof(Restart), 3);
        
        scoreText.text = "Game Over! Score : " + score;
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }


    public void IncrementScore()
    {
        if (IsPlayerAlive)
        {
            score++;
            scoreText.text = "Score : " + score;
        }
    }
}
