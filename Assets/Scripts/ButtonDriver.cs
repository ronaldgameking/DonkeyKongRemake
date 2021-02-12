using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Everything button related
/// </summary>
public class ButtonDriver : MonoBehaviour
{
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
}
