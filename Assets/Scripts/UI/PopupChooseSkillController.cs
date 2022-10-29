using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupChooseSkillController : MonoBehaviour
{
    [SerializeField] PopupChooseSkillItemController[] _items;

    PlayerSkill playerSkill;

    public void Show()
    {
        if (playerSkill == null)
        {
            playerSkill = GameController.Instance.Player.PlayerSkill;
        }

        Time.timeScale = 0;

        gameObject.SetActive(true);
        List<SkillType> notMaxSkillTypes = Utils.GetListEnum<SkillType>().FindAll(
            skill => skill != SkillType.None && (!playerSkill.skillLevels.ContainsKey(skill) || playerSkill.skillLevels[skill] < 3));

        List<SkillType> _3RandomSkills = Utils.GetNRandomElements(notMaxSkillTypes, 3);

        for (int i = 0; i < _3RandomSkills.Count; i++)
        {
            SkillType currentSkill = _3RandomSkills[i];
            _items[i].Init(currentSkill,
                playerSkill.skillLevels.ContainsKey(currentSkill) ? playerSkill.skillLevels[currentSkill] + 1 : 1,
                OnItemClicked);
        }
    }

    void OnItemClicked(PopupChooseSkillItemController item)
    {
        playerSkill.UpgradeSkill(item.skillType);
        Close();
    }

    public void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
