using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    [SerializeField] float _speed;
    public override void Init(Transform target)
    {
        base.Init(target);
        transform.up = (target.position - transform.position).normalized;
        rb.velocity = transform.up * _speed;
    }
}
