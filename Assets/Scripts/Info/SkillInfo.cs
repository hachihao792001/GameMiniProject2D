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
    public string name;
    public string[] levelDescriptions;
    public SkillUpgradeAction[] upgradeActions;
    public Sprite image;
}
