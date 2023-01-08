using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoSingleton<GameInformation>
{
    public List<BulletInfo> bulletInfos;
    public List<SkillInfo> skillInfos;
    public List<StageInfo> stageInfos;
    public List<SkinInfo> skinInfos;
    public int[] levelXPs;

    public static bool IsPhone => Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;

}
