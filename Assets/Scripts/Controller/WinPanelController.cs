using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanelController : MonoBehaviour
{
    public Button nextStageButton;
    private Stage currentStage;

    private void OnEnable()
    {
        currentStage = DataManager.CurrentStage;
        nextStageButton.interactable = currentStage != Stage.StampedeWorld;

        if (currentStage != Stage.StampedeWorld)
            DataManager.UnlockStage((Stage)((int)currentStage + 1));
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }
    public void NextStageClick()
    {
        GameController.Instance.NextStage();
        Time.timeScale = 1;
    }

    public void ExitClick()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }
}
