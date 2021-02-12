using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Trick from Eddie (International Game Jam Dev, Sweden)
    //to prevent use of FindObjectOfType<> and GameObject.Find()
    public static GameManager Instance;

    //Stats
    public Int32 Score { get; private set; } = 0;
    public Int32 Lives { get; private set; } = 3;
    public Int32 gamesPlayed { get; private set; } = 0;

    [ReadOnly] public bool isPaused = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.Instance.isTransitioning) return;
            isPaused = !isPaused;
            if (isPaused)
            {
                UIManager.Instance.DoPauseTransition();
            }
            else
            {
                UIManager.Instance.DoResumeTransition();
            }
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
