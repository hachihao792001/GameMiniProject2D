using System;
using System.Collections.Generic;
using UnityEngine;

public enum HelperType
{
    None,
    Sword,
    ForceField
}

[Serializable]
public struct HelperGO
{
    public HelperType type;
    public Helper helper;
}

public class PlayerHelper : MonoBehaviour
{
    public List<HelperGO> helpers;

    public void UnlockHelper(HelperType type)
    {
        helpers.Find(x => x.type == type).helper.Active();
    }

    public void AddHelperBonusDamage(HelperType helperType, float value)
    {
        if (!helpers.Exists(x => x.type == helperType)) return;  //for unimplemented helpers

        helpers.Find(x => x.type == helperType).helper.AddBonusDamage(value);
    }

    public void SwordHelperAddOneMoreSword()
    {
        (helpers.Find(x => x.type == HelperType.Sword).helper as SwordHelper).AddOneMoreSword();
    }

    public void ForceFieldIncreaseRange()
    {
        //(helpers.Find(x => x.type == HelperType.Sword).helper as ForceFieldHelper);
    }
}
