using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    None = 0,

    Boomerang = 1,
    Bomb = 2,
    Ball = 3,

    IncreaseDamage = 101,
    IncreaseMaxHealth = 102,
    IncreaseMoveSpeed = 103,
    IncreaseDefense = 104,
    IncreaseAttractXPRange = 105,
    IncreaseAttackRange = 106,

    Sword = 201,
    ForceField = 202,

    Heal = 301
}

public enum SkillUpgradeActionType
{
    None,

    UnlockBullet = 1,
    IncreaseBulletDamage = 2,
    IncreaseBulletAffectArea = 3,
    ShootAnotherBulletOpposite = 4,

    IncreaseOverallDamage = 101,
    IncreaseMaxHealth = 102,
    IncreaseMoveSpeed = 103,
    IncreaseDefense = 104,
    IncreaseAttractXPRange = 105,
    IncreaseAttackRange = 106,

    IncreaseHelperDamage = 201,
    IncreaseHelperAmount = 202,
    IncreaseHelperRange = 203,

    Heal = 301
}

[System.Serializable]
public struct SkillUpgradeAction
{
    public SkillUpgradeActionType type;
    public float value;
}

[CreateAssetMenu(fileName = "SkillInfo", menuName = "ScriptableObjects/SkillInfo")]
public class SkillInfo : ScriptableObject
{
    public SkillType type;
    public string skillName;
    public string[] levelDescriptions;
    public SkillUpgradeAction[] upgradeActions;
    public Sprite image;


    public const int FirstBulletSkill = 1;
    public const int LastBulletSkill = 100;
    public const int FirstAttributeSkill = 101;
    public const int LastAttributeSkill = 200;
    public const int FirstHelperSkill = 201;
    public const int LastHelperSkill = 300;
    public const int FirstInstantSkill = 301;

    public static bool IsBulletSkill(SkillType skill)
    {
        int skillInt = (int)skill;
        return skillInt >= FirstBulletSkill && skillInt <= LastBulletSkill;
    }

    public static BulletType SkillTypeToBullet(SkillType skill)
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

    public static bool IsHelperSkill(SkillType skill)
    {
        int skillInt = (int)skill;
        return skillInt >= FirstHelperSkill && skillInt <= LastHelperSkill;
    }

    public static HelperType SkillTypeToHelper(SkillType skill)
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
