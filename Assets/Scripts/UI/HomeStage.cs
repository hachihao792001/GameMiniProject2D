using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeStage : MonoBehaviour
{
    public GameObject home;
    public GameObject stage;
    // Start is called before the first frame update
    void Start()
    {
        home.SetActive(true);
        stage.SetActive(false);
    }

    public void battle()
    {
        home.SetActive(false);
        stage.SetActive(true);
    }

    public void backHome()
    {
        home.SetActive(true);
        stage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
