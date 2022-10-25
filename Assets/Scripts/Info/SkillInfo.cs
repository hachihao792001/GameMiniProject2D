using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Boomerang,
    Bomb,
    Ball,
    IncreaseDamage,
    IncreaseMaxHealth,
    IncreaseMoveSpeed,
    IncreaseDefense,
    IncreaseAttractXPRange,
    IncreaseAttackRange
}

public enum SkillUpgradeActionType
{
    None,
    UnlockBullet,
    IncreaseBulletDamage,
    IncreaseBulletAffectArea,
    ShootAnotherBulletOpposite,
    IncreaseOverallDamage,
    IncreaseMaxHealth,
    IncreaseMoveSpeed,
    IncreaseDefense,
    IncreaseAttractXPRange,
    IncreaseAttackRange
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
    public string name;
    public string[] levelDescriptions;
    public SkillUpgradeAction[] upgradeActions;
    public Sprite image;
}
