using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    [SerializeField] float _speed;
    public override void Init(BulletInfo info, Transform target)
    {
        base.Init(info, target);
        transform.up = (target.position - transform.position).normalized;
        rb.velocity = transform.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeHealth(myInfo.damage);
            Destroy(gameObject);
        }
    }
}
