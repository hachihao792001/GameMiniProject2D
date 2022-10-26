using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Bullet
{
    [SerializeField] float _speed;
    public override void Init(BulletInfo info, Transform target, float bonusDamage)
    {
        base.Init(info, target, bonusDamage);
        transform.up = (target.position - transform.position).normalized;
        rb.velocity = transform.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeHealth(myInfo.damage + bonusDamage);
            rb.velocity = collision.contacts[0].normal * _speed;
        }
    }
}
