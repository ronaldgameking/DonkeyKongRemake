using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Everything button related
/// </summary>
public class ButtonDriver : MonoBehaviour
{
    public Animator menuAnim;
    public Int16 reg_stage = 0;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }

    public void ResumeGame()
    {
        GameManager.Instance.isPaused = false;
        UIManager.Instance.DoResumeTransition();
    }

    public void RetToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ToCredits()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleSettings()
    {
        
        if (menuAnim.GetInteger("showSettings") >= 3)
        {
            menuAnim.SetInteger("showSettings", 0);
        }
        menuAnim.SetInteger("showSettings", menuAnim.GetInteger("showSettings") + 1);
        Debug.Log(menuAnim.GetInteger("showSettings").ToString());
    }

    public void ResetHighScore(Image image)
    {
        try
        {
            PlayerPrefs.DeleteKey("HighScoreA");
            PlayerPrefs.DeleteKey("HighScoreB");
            StartCoroutine(SuccessfulDelete(image));
        }
        catch (Exception e)
        {
            StartCoroutine(FailedDelete(image));
        }
    }

    public IEnumerator SuccessfulDelete(Image img)
    {
        img.color = Color.green;
        yield return new WaitForSeconds(1f);
        img.color = Color.white;
    }
    public IEnumerator FailedDelete(Image img)
    {
        img.color = Color.red;
        yield return new WaitForSeconds(1f);
        img.color = Color.white;
    }
    
}
