using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoSingleton<GameInformation>
{
    public List<BulletInfo> bulletInfos;
    public List<SkillInfo> skillInfos;
    public int[] levelXPs;

    public bool IsBulletSkill(SkillType skill)
    {
        return skill == SkillType.Boomerang ||
                skill == SkillType.Ball ||
                skill == SkillType.Bomb;
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
}
