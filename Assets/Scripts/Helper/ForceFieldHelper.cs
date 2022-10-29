using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldHelper : Helper
{
    [SerializeField] float _damageDelay;
    float tick = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            tick += Time.deltaTime;
            if (tick >= _damageDelay)
            {
                enemy.TakeHealth(getFinalDamage());
                tick = 0;
            }
        }
    }

    public void AddRange(float value)
    {
        transform.localScale += Vector3.one * value;
    }
}
