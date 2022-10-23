using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Player player;

    public float TotalHealth;
    public float CurrentHealth;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;

    [SerializeField] FlashingRed _flashingRed;

    private void Start()
    {
        CurrentHealth = TotalHealth;
        player = GameController.Instance.Player;
    }
    public void TakeHealth(float h)
    {
        CurrentHealth -= h;

        _flashingRed.DoFlash();
        GameController.Instance.DamageTextController.SpawnNewText(transform.position, h);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(GameController.Instance.XPPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
