using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletInfo myInfo;

    public Rigidbody2D rb;
    protected float bonusDamage;

    public virtual void Init(BulletInfo info, Transform target, float bonusDamage)
    {
        myInfo = info;
        this.bonusDamage = bonusDamage;
    }
}
