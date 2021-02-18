using System;
using System.Collections;
using UnityEngine;
using MyNumerics;

public class GameManager : MonoBehaviour
{
    //Trick from Eddie (International Game Jam Dev, Sweden)
    //to prevent use of FindObjectOfType<>
    public static GameManager Instance;

    public DKDJ donkey;

    //Stats
    public Int64 Score { get; private set; } = 0;
    public Int64 HighScore { get; private set; } = 0;
    public Int32 Lives { get; private set; } = 3;
    public Int32 gamesPlayed { get; private set; } = 0;

    //PlayerPrefs compliant
    public Int32 HighScoreA { get; private set; } = 0;
    public Int32 HighScoreB { get; private set; } = 0;

    [ReadOnly] public bool isPaused = false;
    [Range(0,4)]
    public float timeSpeed = 1f;

    //Warnings
    bool instanceLost = false;

    void Awake()
    {
        //EVERYTHING IN THIS REGION IS FOR TESTING PURPOSES
        #region Testing

        //Testing long reconstruction
        Int64 gh = (Int64)Int32.MaxValue * 2;
        Debug.Log(string.Format("Original Long: {0}", gh));
        Int32[] gi = IntegerUtil.Long2doubleInt(gh);
        Debug.Log(string.Format("Long in int: {0}, {1}", gi[0], gi[1]));
        Int64 gj = IntegerUtil.DoubleInt2Long(gi[0], gi[1]);
        Debug.Log(string.Format("Reconstructed Long: {0}", gj));
        //END

        //Testing int reconstruction
        Int32 hh = (Int32)Int16.MaxValue * 2;
        Debug.Log(string.Format("Original Int32: {0}", hh));
        Int16[] hi = IntegerUtil.Int2doublrShort(hh);
        Debug.Log(string.Format("Int32 in Short: {0}, {1}", hi[0], hi[1]));
        Int32 hj = IntegerUtil.DoubleShort2Int(hi[0], hi[1]);
        Debug.Log(string.Format("Reconstructed Int32: {0}", hj));
        //END
        #endregion

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScoreA", 0);
        HighScore = PlayerPrefs.GetInt("HighScoreB", 0);

        if (UIManager.Instance == null)
        {
            FindObjectOfType<UIManager>().UpdateHighScore();
        }
        else
        {
            UIManager.Instance.UpdateHighScore();
        }
    }

    private void Update()
    {
        Time.timeScale = timeSpeed;
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
            HighScore = Score;
            Int32[] HighScoreInt = IntegerUtil.Long2doubleInt(HighScore);
            PlayerPrefs.SetInt("HighScoreA", HighScoreInt[0]);
            PlayerPrefs.SetInt("HighScoreB", HighScoreInt[1]);
            if (!PlayerPrefs.HasKey("HighScoreA"))
            {
                Debug.LogError("Failed saving score Fragment A");
            }
            if (!PlayerPrefs.HasKey("HighScoreB"))
            {
                Debug.LogError("Failed saving score Fragment A");
            }
            UIManager.Instance.UpdateHighScore();
        }
    }

    public void ChangeLives(Int32 diff)
    {
        Lives += diff;
    }
    public void ChangeScore(Int64 diff)
    {
        Score += diff;
        HighScoreManagment();
        UIManager.Instance.UpdateScore();

    }   
    public void ChangeScoreD(Int64 val)
    {
        Score = val;
        HighScoreManagment();
        UIManager.Instance.UpdateScore();
    }

    public void ResetLoaderBoard()
    {
        HighScore = 0;
        HighScoreA = 0;
        HighScoreB = 0;
    }
}
