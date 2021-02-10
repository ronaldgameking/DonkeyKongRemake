using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Trick from Eddie (International Game Jam Dev, Sweden)
    //to prevent use of FindObjectOfType<> and GameObject.Find()
    public static GameManager Instance;

    public Int32 Score { get; private set; } = 0;
    public Int32 Lives { get; private set; } = 3;

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
