using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet
{
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] float _explosionRadius;
    [SerializeField] float _speed;
    [SerializeField] float _timeUntilExplode;
    [SerializeField] float _timeToDisappearAfterExplode;
    [SerializeField] GameObject _explodeEffect;

    float tick = 0;
    bool exploded = false;

    public override void Init(BulletInfo info, Transform target, float bonusDamage)
    {
        base.Init(info, target, bonusDamage);
        transform.up = (target.position - transform.position).normalized;
        rb.velocity = transform.up * _speed;
    }

    private void Update()
    {
        tick += Time.deltaTime;
        if (tick >= _timeUntilExplode && !exploded)
        {
            _explodeEffect.SetActive(true);
            Destroy(gameObject, _timeToDisappearAfterExplode);

            Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, GameController.Instance.EnemyLayerMask);
            rb.velocity = Vector2.zero;
            _sr.enabled = false;

            for (int i = 0; i < hittedEnemies.Length; i++)
            {
                hittedEnemies[i].GetComponent<Enemy>().TakeHealth(myInfo.damage + bonusDamage);
            }

            exploded = true;
        }
    }
}
