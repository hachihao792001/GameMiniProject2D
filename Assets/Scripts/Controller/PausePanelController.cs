using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelController : MonoBehaviour
{
    public void Show()
    {
        GameController.Instance.IsPause = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void SettingClick()
    {

    }

    public void ResumeClick()
    {
        GameController.Instance.IsPause = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ExitClick()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

}
