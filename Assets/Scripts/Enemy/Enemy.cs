using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum EnemyType
{
    None = 0,
    MeleeEnemy,
    RangedEnemy,
    BigRangedEnemy,
    PoisonEnemy
}

public class Enemy : MonoBehaviour
{

    public EnemyType enemyType;
    protected Player player;

    public float TotalHealth;
    public float CurrentHealth;

    public int xp;
    public Random r;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _meleeDamage;

    [SerializeField] FlashingRed _flashingRed;

    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected SpriteRenderer _sr;

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

    public virtual void Die()
    {
        Random rnd = new Random();
        XP newXP = Instantiate(GameController.Instance.XPPrefab, transform.position, Quaternion.identity);
        int goldEarned = rnd.Next(10, 50);
        int currentGold = DataManager.Money;
        DataManager.Money = currentGold + goldEarned;
        newXP.Init(xp);
        Destroy(gameObject);
    }
}
