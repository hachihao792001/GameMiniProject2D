using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashController : MonoBehaviour
{
    public Button SplashScreen;

    private void Start()
    {
        AudioController.Instance.PlayAudio(Audio.HomeMusic);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SplashScreen.onClick.Invoke();
        }
    }
}
