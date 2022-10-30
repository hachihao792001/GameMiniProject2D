using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoSingleton<GameInformation>
{
    public List<BulletInfo> bulletInfos;
    public List<SkillInfo> skillInfos;
    public List<StageSpawningInfo> stageSpawningInfos;

    public int[] levelXPs;
    public bool IsBulletSkill(SkillType skill)
    {
        return skill != SkillType.None && (int)skill < 101;
    }

    public BulletType SkillTypeToBullet(SkillType skill)
    {
        switch (skill)
        {
            case SkillType.Boomerang:
                return BulletType.Boomerang;
            case SkillType.Bomb:
                return BulletType.Bomb;
            case SkillType.Ball:
                return BulletType.Ball;
            default:
                return BulletType.None;
        }
    }

    public bool IsHelperSkill(SkillType skill)
    {
        return (int)skill >= 201;
    }

    public HelperType SkillTypeToHelper(SkillType skill)
    {
        switch (skill)
        {
            case SkillType.Sword:
                return HelperType.Sword;
            case SkillType.ForceField:
                return HelperType.ForceField;
            default:
                return HelperType.None;
        }
    }
}
