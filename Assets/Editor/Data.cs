using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Data : MonoBehaviour
{
    [MenuItem("SurvivalLand/Clear Data")]
    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
