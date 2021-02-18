using System;

using UnityEngine;

public class AnimationFunctions : MonoBehaviour
{
    public Animator menuAnim;
    public Int16 reg_stage = 0;

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
        foreach (GameObject go in settingOptions)
        {
            go.SetActive(true);
        }
    }
}
    