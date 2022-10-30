using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupChooseSkillItemController : MonoBehaviour
{
    public SkillType skillType;
    [SerializeField] Image _imgIcon;
    [SerializeField] Text _txtDescription;
    [SerializeField] Text _txtName;
    [SerializeField] SkillLevelDisplayer _levelDisplayer;

    Action<PopupChooseSkillItemController> onClick;

    public void Init(SkillType skillType, int level, Action<PopupChooseSkillItemController> onClick)
    {
        this.skillType = skillType;
        this.onClick = onClick;

        SkillInfo skillInfo = GameInformation.Instance.skillInfos.Find(x => x.type == skillType);

        _imgIcon.sprite = skillInfo.image;
        _txtDescription.text = skillInfo.levelDescriptions[level - 1];
        _txtName.text = skillInfo.skillName;
        _levelDisplayer.SetLevel(level);
    }

    public void OnClick()
    {
        onClick?.Invoke(this);
    }
}
