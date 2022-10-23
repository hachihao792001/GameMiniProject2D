using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletInfo myInfo;

    public Rigidbody2D rb;
    public virtual void Init(BulletInfo info, Transform target)
    {
        myInfo = info;
    }
}
