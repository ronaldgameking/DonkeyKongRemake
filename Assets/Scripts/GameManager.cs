﻿using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Trick from Eddie (International Game Jam Dev, Sweden)
    //to prevent use of FindObjectOfType<>
    public static GameManager Instance;

    public DKDJ donkey;

    //Stats
    public Int32 Score { get; private set; } = 0;
    public Int32 HighScore { get; private set; } = 0;
    public Int32 Lives { get; private set; } = 3;
    public Int32 gamesPlayed { get; private set; } = 0;

    [ReadOnly] public bool isPaused = false;

    //Warnings
    bool instanceLost = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            HighScore = PlayerPrefs.GetInt(nameof(HighScore), 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Instance == null && !instanceLost)
        {
            Debug.LogWarning("Instance not set, did the editor Reload?");
            instanceLost = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.Instance.isTransitioning) return;
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseMenu.Instance.FadeChildObj(-0.01f);
                UIManager.Instance.DoPauseTransition();
                DKDJ.Instance.Pause(true);
            }
            else
            {
                UIManager.Instance.DoResumeTransition();
                DKDJ.Instance.Pause(false);
            }
        }
    }

    public void HighScoreManagment()
    {
        if (Score > HighScore)
        {
            PlayerPrefs.SetInt(nameof(HighScore), HighScore);
        }
    }

    public void ChangeLives(Int32 diff)
    {
        Lives += diff;
    }
    public void ChangeScore(Int32 diff)
    {
        Score += diff;
        UIManager.Instance.UpdateScore();
    }
    public void ChangeScoreD(Int32 val)
    {
        Score = val;
        UIManager.Instance.UpdateScore();
    }
}
