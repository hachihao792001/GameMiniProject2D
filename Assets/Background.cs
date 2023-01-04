using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textMeshPro; 
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = PlayerPrefs.GetInt("Money", 1000).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
