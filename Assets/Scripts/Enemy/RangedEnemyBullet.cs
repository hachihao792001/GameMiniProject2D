using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBullet : MonoBehaviour
{
    [SerializeField] float _speed;
    float _damage;
    [SerializeField] Rigidbody2D rb;

    public void Init(float damage, Vector3 des)
    {
        _damage = damage;
        transform.up = (des - transform.position).normalized;
        rb.velocity = transform.up * _speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.TakeHealth(_damage);

            Destroy(gameObject);
        }
    }
}
