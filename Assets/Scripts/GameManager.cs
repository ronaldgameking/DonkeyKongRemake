using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Trick from Eddie to prevent use of FindObjectOfType<> and GameObject.Find()
    public static GameManager Instance;

    public Int32 Score { get; private set; } = 0;
    public Int32 Lives { get; private set; } = 3;

    void Start()
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

    public void ChanceLives(Int32 diff)
    {
        Lives += diff;
    }
    public void ChanceScore(Int32 diff)
    {
        Score += diff;
    }

}
