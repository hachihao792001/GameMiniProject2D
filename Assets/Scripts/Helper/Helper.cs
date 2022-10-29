using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public float damage;
    protected float bonusDamage;

    public virtual void Active()
    {
        gameObject.SetActive(true);
    }

    public void AddBonusDamage(float value)
    {
        bonusDamage += value;
    }

    protected float getFinalDamage()
    {
        return damage + GameController.Instance.Player.PlayerAttacking.overallBonusDamage + bonusDamage;
    }
}
