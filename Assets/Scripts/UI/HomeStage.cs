using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeStage : MonoBehaviour
{
    public GameObject home;
    public GameObject stage;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        home.SetActive(true);
        stage.SetActive(false);
        shop.SetActive(false);

        AudioController.Instance.StopAudio(Audio.GameMusic);
        AudioController.Instance.PlayAudio(Audio.HomeMusic);
    }

    public void battle()
    {
        home.SetActive(false);
        stage.SetActive(true);
        shop.SetActive(false);
    }

    public void backHome()
    {
        home.SetActive(true);
        stage.SetActive(false);
        shop.SetActive(false);
    }

    public void shop_skin()
    {
        home.SetActive(false);
        stage.SetActive(false);
        shop.SetActive(true);
    }
}
