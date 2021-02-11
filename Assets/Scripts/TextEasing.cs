using System;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEasing : MonoBehaviour
{
    public TextMeshProUGUI EasingText;

    public int MaxSize = 24;
    public int MinSize = 14;
    public int CurrentSize = 24;

    bool hasPeaked = true;
    bool hasLowed = false;

    float timer;

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.02f)
        {
            if (hasPeaked && !hasLowed)
            {
                CurrentSize--;
            }
            else if (!hasPeaked && hasLowed)
            {
                CurrentSize++;
            }

            if (CurrentSize >= MaxSize)
            {
                hasPeaked = true;
                hasLowed = false;
            }

            if (CurrentSize <= MinSize)
            {
                hasPeaked = false;
                hasLowed = true;
            }
            timer = 0f;
        }
        timer += Time.deltaTime;
        EasingText.fontSize = CurrentSize;
        
    }
}
