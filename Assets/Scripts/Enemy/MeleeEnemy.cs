using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _sr;

    void Update()
    {
        _rb.velocity = (player.transform.position - transform.position).normalized * _speed;
        if(_rb.velocity.x != 0)
        {
            _sr.flipX = _rb.velocity.x < 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().PlayerHealth.TakeHealth(_damage);
        }
    }
}
