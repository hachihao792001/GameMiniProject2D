using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoosePanelController : MonoBehaviour
{
    public void HomeClick()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

    public void RetryClick()
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
