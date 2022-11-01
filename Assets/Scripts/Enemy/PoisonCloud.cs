using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _damageDelay;
    [SerializeField] float _range;
    float tick = 0;

    private void Start()
    {
        tick = _damageDelay;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            tick += Time.deltaTime;
            if (tick >= _damageDelay)
            {
                playerHealth.TakeHealth(_damage);
                tick = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            tick = _damageDelay;    //lap tuc damage lan sau
        }
    }
}
