using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gold; 
    // Start is called before the first frame update
    void Start()
    {
        gold.text = PlayerPrefs.GetInt("Money").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
