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

    private void Start()
    {
        CurrentHealth = TotalHealth;
        player = GameController.Instance.Player;
    }
    public void TakeHealth(float h)
    {
        CurrentHealth -= h;
        if (CurrentHealth <= 0)
            Destroy(gameObject);
    }
}
