using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _damageDelay;
    [SerializeField] float _range;

    [SerializeField] float _disappearDelay;
    float tick = 0;
    bool stopDamage = false;

    private void Start()
    {
        tick = _damageDelay;
        StartCoroutine(AutoDisappear());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth) && !stopDamage)
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

    IEnumerator AutoDisappear()
    {
        yield return new WaitForSeconds(_disappearDelay);
        stopDamage = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
