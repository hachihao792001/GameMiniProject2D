using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] Player player;

    public Dictionary<SkillType, int> skillLevels = new Dictionary<SkillType, int>();

    public void UpgradeSkill(SkillType skillType)
    {
        if (skillLevels.ContainsKey(skillType))
        {
            if (skillLevels[skillType] < 3)
                skillLevels[skillType]++;
        }
        else
        {
            skillLevels.Add(skillType, 1);
        }
        int newLevel = skillLevels[skillType];

        SkillInfo skillInfo = GameInformation.Instance.skillInfos.Find(x => x.type == skillType);
        SkillUpgradeAction upgradeAction = skillInfo.upgradeActions[newLevel - 1];
        float upgradeActionValue = upgradeAction.value;

        if (GameInformation.Instance.IsBulletSkill(skillType))
        {
            BulletType bulletType = GameInformation.Instance.SkillTypeToBullet(skillType);
            if (!player.PlayerAttacking.IsBulletUnlocked(bulletType))
            {
                player.PlayerAttacking.UnlockBullet(bulletType);
            }

            switch (upgradeAction.type)
            {
                case SkillUpgradeActionType.IncreaseBulletDamage:
                    player.PlayerAttacking.AddBulletBonusDamage(bulletType, upgradeActionValue);
                    break;
                case SkillUpgradeActionType.IncreaseBulletAffectArea:
                    break;
                case SkillUpgradeActionType.ShootAnotherBulletOpposite:
                    break;
            }
        }
        else
        {
            switch (skillType)
            {
                case SkillType.IncreaseAttackRange:
                    player.PlayerAttacking.DetectEnemy.IncreaseRange(upgradeActionValue);
                    break;
                case SkillType.IncreaseDamage:
                    player.PlayerAttacking.AddOverallBonusDamage((int)upgradeActionValue);
                    break;
                case SkillType.IncreaseAttractXPRange:
                    player.PlayerXP.DetectXP.IncreaseRange(upgradeActionValue);
                    break;
                case SkillType.IncreaseDefense:
                    player.PlayerHealth.IncreaseDefense(upgradeActionValue);
                    break;
                case SkillType.IncreaseMaxHealth:
                    player.PlayerHealth.IncreaseMaxHealth(upgradeActionValue);
                    break;
                case SkillType.IncreaseMoveSpeed:
                    player.PlayerMoving.AddBonusSpeed(upgradeActionValue);
                    break;
            }
        }
    }
}
