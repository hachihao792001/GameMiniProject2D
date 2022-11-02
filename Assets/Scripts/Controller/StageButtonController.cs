using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Stage
{
    DeathCity = 0,
    CloudyPark = 1,
    StampedeWorld = 2
}


public class StageButtonController : MonoBehaviour
{
    public Stage stage;
    [SerializeField] GameObject lockIcon;
    [SerializeField] bool isUnlocked;
    [SerializeField] Button button;

    public void SetData(bool isUnlocked)
    {
        this.isUnlocked = isUnlocked;
        lockIcon.SetActive(!isUnlocked);
    }

    public void playGame()
    {
        if (isUnlocked)
        {
            PlayerPrefs.SetInt("stage", (int)stage);
            SceneManager.LoadScene("Game");
        }
    }

    public void Click()
    {
        button.onClick.Invoke();
    }
}
