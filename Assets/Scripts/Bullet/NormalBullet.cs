using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    [SerializeField] float _speed;

    public override void Init(BulletInfo info, Vector3 targetPos, BulletBonusStat bonusStat)
    {
        base.Init(info, targetPos, bonusStat);
        transform.up = (targetPos - transform.position).normalized;
        rb.velocity = transform.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeHealth(getFinalDamage());

            Destroy(gameObject);
        }
    }
}
