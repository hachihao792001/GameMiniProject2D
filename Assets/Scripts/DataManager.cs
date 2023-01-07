using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private const string IsTutorialShownDataKey = "IsTutorialShown";
    private const string StageUnlockedDataKey = "StageUnlocked";
    private const string CurrentStageDataKey = "CurrentStage";
    private const string SkinUnlockedDataKey = "SkinUnlocked";
    private const string MoneyDataKey = "Money";
    private const string EquippedSkinIndexDataKey = "EquippedSkinIndex";

    #region Tutorial
    public static bool IsTutorialShown
    {
        get
        {
            return PlayerPrefs.GetInt(IsTutorialShownDataKey, 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("IsTutorialShown", value ? 1 : 0);
        }
    }
    #endregion

    #region Stage
    public static List<bool> StageUnlocked
    {
        get
        {
            string data = PlayerPrefs.GetString(StageUnlockedDataKey, "1;0;0");
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
            PlayerPrefs.SetString(StageUnlockedDataKey, dataToSave);
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

    public static Stage CurrentStage
    {
        get
        {
            return (Stage)PlayerPrefs.GetInt(CurrentStageDataKey, (int)Stage.DeathCity);
        }

        set
        {
            PlayerPrefs.SetInt(CurrentStageDataKey, (int)value);
        }
    }
    #endregion

    #region Skin
    public static List<bool> SkinUnlocked
    {
        get
        {
            string data = PlayerPrefs.GetString(SkinUnlockedDataKey, "1;0;0;0;0;0;0;0;0");
            List<bool> result = new List<string>(data.Split(';')).ConvertAll(x => x == "1" ? true : false);
            return result;
        }

        set
        {
            List<bool> newData = value;
            string skinToSave = "";
            for (int i = 0; i < newData.Count; i++)
            {
                skinToSave += (newData[i] ? "1" : "0");
                if (i < newData.Count - 1)
                    skinToSave += ";";
            }
            PlayerPrefs.SetString(SkinUnlockedDataKey, skinToSave);
        }
    }

    public static void UnlockSkin(Skin_index skin_idx)
    {
        List<bool> skinUnlocked = SkinUnlocked;
        skinUnlocked[(int)skin_idx] = true;
        SkinUnlocked = skinUnlocked;
    }

    public static bool IsSkinUnlocked(Skin_index skin_idx)
    {
        return SkinUnlocked[(int)skin_idx];
    }

    public static int EquippedSkinIndex
    {
        get
        {
            return PlayerPrefs.GetInt(EquippedSkinIndexDataKey, 0);
        }

        set
        {
            PlayerPrefs.SetInt(EquippedSkinIndexDataKey, value);
        }
    }
    #endregion

    #region Money
    public static int Money
    {
        get
        {
            return PlayerPrefs.GetInt(MoneyDataKey, 1000);
        }

        set
        {
            PlayerPrefs.SetInt(MoneyDataKey, value);
        }
    }
    #endregion
}