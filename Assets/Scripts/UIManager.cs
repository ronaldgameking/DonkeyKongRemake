using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;

    public GameObject pauseGameObj;
    public Image pauseImage;

    public int targetAlpha = 20;

    public bool isTransitioning { get; private set; } = false;

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

    public void UpdateScore()
    {
        scoreText.text = GameManager.Instance.Score.ToString("D5");
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
            PauseMenu.Instance.FadeChildObj(-0.01f);
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
