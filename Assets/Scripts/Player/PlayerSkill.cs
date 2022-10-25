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
    }
}
