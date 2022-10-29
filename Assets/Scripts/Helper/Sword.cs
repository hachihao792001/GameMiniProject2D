using System;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Action<Enemy> OnHitEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            OnHitEnemy?.Invoke(enemy);
        }
    }
}
