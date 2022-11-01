using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PausePanelController : MonoBehaviour
{
    [SerializeField] TMP_Text _txtPlayInfo;
    public void Show()
    {
        _txtPlayInfo.text = GameController.Instance.CurrentStageInfo.stageName;

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
