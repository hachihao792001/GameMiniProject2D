using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    None = 0,
    MeleeEnemy,
    RangedEnemy,
    BigRangedEnemy
}

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    protected Player player;

    public float TotalHealth;
    public float CurrentHealth;

    public int xp;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _meleeDamage;

    [SerializeField] FlashingRed _flashingRed;

    public virtual void Start()
    {
        CurrentHealth = TotalHealth;
        player = GameController.Instance.Player;
    }
    public void TakeHealth(float h)
    {
        CurrentHealth -= h;

        _flashingRed.DoFlash();
        GameController.Instance.DamageTextController.SpawnNewText(transform.position, h);
        AudioController.Instance.PlayRandomEnemyHurt();

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        XP newXP = Instantiate(GameController.Instance.XPPrefab, transform.position, Quaternion.identity);
        newXP.Init(xp);
        Destroy(gameObject);
    }
}
