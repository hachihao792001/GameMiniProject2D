using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletInfo myInfo;

    public Rigidbody2D rb;
    protected BulletBonusStat bonusStat;

    public virtual void Init(BulletInfo info, Vector3 targetPos, BulletBonusStat bonusStat)
    {
        myInfo = info;
        this.bonusStat = bonusStat;
    }

    protected float getFinalDamage()
    {
        return myInfo.damage + GameController.Instance.Player.PlayerAttacking.overallBonusDamage + bonusStat.damage;
    }
}
