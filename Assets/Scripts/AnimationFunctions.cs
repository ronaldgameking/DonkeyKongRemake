using System;

using UnityEngine;

public class AnimationFunctions : MonoBehaviour
{
    public Animator menuAnim;

    public GameObject[] settingOptions;

    public void z_NextAnimStage()
    {
        Debug.Log("Nex stage");
        menuAnim.SetInteger("showSettings", 2);
    }

    public void z_ResetStage()
    {
        menuAnim.SetInteger("showSettings", 0);
    }

    public void z_ShowSettingButtons()
    {
        Debug.Log("Showing setting buttons");
        foreach (GameObject go in settingOptions)
        {
            go.SetActive(true);
        }
    }
    public void z_HideSettingButtons()
    {
        Debug.Log("Hiding setting buttons");
        foreach (GameObject go in settingOptions)
        {
            go.SetActive(false);
        }
    }
}
    