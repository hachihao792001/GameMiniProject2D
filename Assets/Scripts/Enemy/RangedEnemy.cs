using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    readonly int ShootingHash = Animator.StringToHash("Shooting");

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _sr;

    [SerializeField] Animator _animator;
    [SerializeField] RangedEnemyBullet _bulletPrefab;
    [SerializeField] float _startShootingRange;
    [SerializeField] float _stopShootingRange;

    [SerializeField] float _bulletDamage;

    bool isInShootingState;

    public override void Start()
    {
        base.Start();
        isInShootingState = false;
    }

    void Update()
    {
        CheckShootingState();

        _animator.SetBool(ShootingHash, isInShootingState);
        if (isInShootingState)
        {
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _rb.velocity = (player.transform.position - transform.position).normalized * _speed;
        }
        _sr.flipX = player.transform.position.x - transform.position.x < 0;
    }

    private void CheckShootingState()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, GameController.Instance.Player.transform.position);
        if (isInShootingState)
        {
            if (distanceToPlayer > _stopShootingRange)
            {
                isInShootingState = false;
            }
        }
        else
        {
            if (distanceToPlayer < _startShootingRange)
            {
                isInShootingState = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().PlayerHealth.TakeHealth(_meleeDamage);
        }
    }

    public void ShootBullet()   //animation event
    {
        if (isInShootingState)
        {
            RangedEnemyBullet newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            newBullet.Init(_bulletDamage, GameController.Instance.Player.transform.position);
        }
    }
}
