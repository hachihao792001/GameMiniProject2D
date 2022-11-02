using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SplashController : MonoBehaviour
{
    [SerializeField] SceneSwitcher _sceneSwitcher;
    [SerializeField] Slider _loadingBar;
    [SerializeField] TMP_Text _txtPercent;
    [SerializeField] GameObject _tapToStart;
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

    public void SplashScreenOnClicK()
    {
        _tapToStart.SetActive(false);
        _loadingBar.gameObject.SetActive(true);
        StartCoroutine(loadingCoroutine());
    }

    IEnumerator loadingCoroutine()
    {
        float currentPercent = 0;
        while (currentPercent < 100)
        {
            _txtPercent.text = "Loading..." + currentPercent + "%";
            _loadingBar.value = currentPercent / 100f;
            currentPercent++;
            yield return null;
        }
        currentPercent = 100;
        _txtPercent.text = "Loading..." + currentPercent + "%";
        _loadingBar.value = currentPercent / 100f;
        yield return new WaitForSeconds(0.5f);
        _sceneSwitcher.SwitchScene("Home");
    }
}
