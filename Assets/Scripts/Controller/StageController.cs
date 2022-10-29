using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Stage
{
    DeathCity,
    CloudyPark,
    StampedeWorld
}


public class StageController : MonoBehaviour
{
    public Stage stage;
    public void playGame()
    {
        PlayerPrefs.SetInt("stage", (int)stage);
        SceneManager.LoadScene("Game");
    }
}
