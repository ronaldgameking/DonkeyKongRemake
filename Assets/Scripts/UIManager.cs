using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject pauseGameObj;
    public Image pauseImage;

    public int targetAlpha = 20;
    public bool isTransitioning { get; private set; } = false;

    private bool instanceLost;

    // Start is called before the first frame update
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

    private void Update()
    {
        if (Instance == null && !instanceLost)
        {
            Debug.LogWarning("Instance not set, did the editor Reload?");
            instanceLost = true;
            return;
        }
    }

    public void UpdateScore()
    {
        scoreText.text = GameManager.Instance.Score.ToString("D5");
    }

    public void UpdateHighScore()
    {
        highScoreText.text = GameManager.Instance.HighScore.ToString("D5");
    }


    public void DoPauseTransition()
    {
        StartCoroutine(PauseTransition());
    }

    public IEnumerator PauseTransition()
    {   
        isTransitioning = true;
        for (int i = 0; i < targetAlpha; i++)
        {
            Color transitionColor = pauseImage.color;
            transitionColor.a += 0.01f * Time.deltaTime * 150;
            pauseImage.color = transitionColor;
            if (i >= 1) PauseMenu.Instance.FadeChildObj(0.01f);
            yield return new WaitForSeconds(0.001f * Time.deltaTime * 100);
        }
        isTransitioning = false;
    }   

    public void DoResumeTransition()
    {
        StartCoroutine(ResumeTransition());
    }

    public IEnumerator ResumeTransition()
    {
        isTransitioning = true;
        for (int i = 0; i < targetAlpha; i++)
        {
            Color transitionColor = pauseImage.color;
            transitionColor.a -= 0.01f * Time.deltaTime * 150;
            pauseImage.color = transitionColor;
            yield return new WaitForSeconds(0.001f * Time.deltaTime * 100);    
        }
        PauseMenu.Instance.FadeChildObj(-0.01f);
        foreach (var item in PauseMenu.Instance.buttonObjects)
        {
            item.SetActive(false);
        }
        isTransitioning = false;
    }
}
