using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelController : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void SettingClick()
    {

    }

    public void ResumeClick()
    {
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
