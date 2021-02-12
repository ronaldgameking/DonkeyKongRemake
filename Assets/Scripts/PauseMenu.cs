using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    public GameObject[] buttonObjects;
    public Image[] images;

    private void Awake()
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

    public void FadeChildObj(Single diff)
    {
        if (diff > 0)
        {
            for (int i = 0; i < buttonObjects.Length; i++)
            {
                buttonObjects[i].SetActive(true);
            }
        }
        for (int i = 0; i < images.Length; i++)
        {
            Color transitionColor = images[i].color;
            transitionColor.a += diff;
            images[i].color = transitionColor;
            if (transitionColor.a <= 0.01f) buttonObjects[i].SetActive(false);
        }
    }
}
