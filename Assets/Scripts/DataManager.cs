using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static List<bool> StageUnlocked
    {
        get
        {
            string data = PlayerPrefs.GetString("StageUnlocked", "1;0;0");
            List<bool> result = new List<string>(data.Split(';')).ConvertAll(x => x == "1" ? true : false);
            return result;
        }

        set
        {
            List<bool> newData = value;
            string dataToSave = "";
            for (int i = 0; i < newData.Count; i++)
            {
                dataToSave += (newData[i] ? "1" : "0");
                if (i < newData.Count - 1)
                    dataToSave += ";";
            }
            PlayerPrefs.SetString("StageUnlocked", dataToSave);
        }
    }

    public static void UnlockStage(Stage stage)
    {
        List<bool> stageUnlocked = StageUnlocked;
        stageUnlocked[(int)stage] = true;
        StageUnlocked = stageUnlocked;
    }

    public static bool IsStageUnlocked(Stage stage)
    {
        return StageUnlocked[(int)stage];
    }
}