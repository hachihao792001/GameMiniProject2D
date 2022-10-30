using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public void playGame()
    {
        PlayerPrefs.SetInt("stage", (int)stage);
        SceneManager.LoadScene("Game");
    }
}
