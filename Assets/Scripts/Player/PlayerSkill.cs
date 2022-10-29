using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] Player player;

    public Dictionary<SkillType, int> skillLevels = new Dictionary<SkillType, int>();

    public void UpgradeSkill(SkillType skillType)
    {
        if (skillType == SkillType.Heal)
        {
            player.PlayerHealth.AddHealth(GameInformation.Instance.skillInfos.Find(x => x.type == SkillType.Heal).upgradeActions[0].value);
            return;
        }

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
                    player.PlayerAttacking.AddBulletAffectArea(bulletType, upgradeActionValue);
                    break;
                case SkillUpgradeActionType.ShootAnotherBulletOpposite:
                    player.PlayerAttacking.SetBulletShootOpposite(bulletType);
                    break;
            }
        }
        else if (GameInformation.Instance.IsHelperSkill(skillType))
        {
            HelperType helperType = GameInformation.Instance.SkillTypeToHelper(skillType);
            player.PlayerHelper.UnlockHelper(helperType);

            switch (upgradeAction.type)
            {
                case SkillUpgradeActionType.IncreaseHelperDamage:
                    player.PlayerHelper.AddHelperBonusDamage(helperType, upgradeActionValue);
                    break;
                case SkillUpgradeActionType.IncreaseHelperAmount:
                    player.PlayerHelper.SwordHelperAddOneMoreSword();
                    break;
                case SkillUpgradeActionType.IncreaseHelperRange:
                    player.PlayerHelper.ForceFieldIncreaseRange(upgradeActionValue);
                    break;
            }
        }
        else
        {
            switch (upgradeAction.type)
            {
                case SkillUpgradeActionType.IncreaseAttackRange:
                    player.PlayerAttacking.DetectEnemy.IncreaseRange(upgradeActionValue);
                    break;
                case SkillUpgradeActionType.IncreaseOverallDamage:
                    player.PlayerAttacking.AddOverallBonusDamage((int)upgradeActionValue);
                    break;
                case SkillUpgradeActionType.IncreaseAttractXPRange:
                    player.PlayerXP.DetectXP.IncreaseRange(upgradeActionValue);
                    break;
                case SkillUpgradeActionType.IncreaseDefense:
                    player.PlayerHealth.IncreaseDefense(upgradeActionValue);
                    break;
                case SkillUpgradeActionType.IncreaseMaxHealth:
                    player.PlayerHealth.IncreaseMaxHealth(upgradeActionValue);
                    break;
                case SkillUpgradeActionType.IncreaseMoveSpeed:
                    player.PlayerMoving.AddBonusSpeed(upgradeActionValue);
                    break;
            }
        }
    }
}
