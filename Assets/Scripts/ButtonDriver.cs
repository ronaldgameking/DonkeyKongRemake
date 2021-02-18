using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Everything button related
/// </summary>
public class ButtonDriver : MonoBehaviour
{
    public Animator menuAnim;
    public GameObject[] settingOptions;

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
        CultureInfo ci = CultureInfo.InstalledUICulture;

        Debug.Log(string.Format("Default Language Info:"));
        Debug.Log(string.Format("* English Name: {0}", ci.Name));
        if (menuAnim.GetInteger("showSettings") >= 3)
        {
            menuAnim.SetInteger("showSettings", 0);
        }
        menuAnim.SetInteger("showSettings", menuAnim.GetInteger("showSettings") + 1);
        Debug.Log(menuAnim.GetInteger("showSettings").ToString());
    }

    public void ResetHighScore()
    {

    }

    public void ShowSettingButtons()
    {
        foreach (GameObject go in settingOptions)
        {
            go.SetActive(true);
        }
    }

    
}
