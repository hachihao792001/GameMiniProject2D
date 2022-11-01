using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEnemy : MeleeEnemy
{
    [SerializeField] GameObject _poisonCloudPrefab;
    [SerializeField] float _explosionRadius;
    [SerializeField] GameObject _explosionEffect;

    [SerializeField] float _poisonCloudSpawningDelay;
    [SerializeField] float _explosionDamage;
    [SerializeField] float _dieTimeAfterExplode;
    float tick = 0;

    protected override void Update()
    {
        base.Update();
        tick += Time.deltaTime;
        if (tick >= _poisonCloudSpawningDelay)
        {
            Instantiate(_poisonCloudPrefab, transform.position, Quaternion.Euler(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f)));
            tick = 0;
        }
    }

    public override void Die()
    {
        _explosionEffect.SetActive(true);
        Collider2D[] hitted = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, GameController.Instance.PlayerLayerMask);

        if (hitted.Length > 0)
        {
            for (int i = 0; i < hitted.Length; i++)
            {
                if (hitted[i].TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
                {
                    playerHealth.TakeHealth(_explosionDamage);
                    break;
                }
            }
        }

        _sr.enabled = false;
        StartCoroutine(dieAfterExplode());
    }

    IEnumerator dieAfterExplode()
    {
        yield return new WaitForSeconds(_dieTimeAfterExplode);
        base.Die();
    }
}
