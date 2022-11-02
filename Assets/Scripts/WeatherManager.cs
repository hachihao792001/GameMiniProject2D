using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] GameObject RainEffect;
    [SerializeField] GameObject DarkSky;
    [SerializeField] GameObject MeteorEffect;
    [SerializeField] GameObject RedSky;

    void Start()
    {
        Stage currentStage = GameController.Instance.currentStage;
        RainEffect.SetActive(currentStage == Stage.CloudyPark);
        DarkSky.SetActive(currentStage == Stage.CloudyPark);
        MeteorEffect.SetActive(currentStage == Stage.StampedeWorld);
        RedSky.SetActive(currentStage == Stage.StampedeWorld);
    }
}
