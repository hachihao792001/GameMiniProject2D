using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] Rigidbody2D _rb;

    void Update()
    {
        _rb.velocity = (player.transform.position - transform.position).normalized * _speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().PlayerHealth.TakeHealth(_damage);
        }
    }
}
