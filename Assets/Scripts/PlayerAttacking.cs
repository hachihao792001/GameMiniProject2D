using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] Transform _bulletParent;
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] DetectEnemy _detectEnemy;

    [SerializeField] float _shootInterval;

    float tick = 0;

    void Start()
    {

    }

    void Update()
    {
        tick += Time.deltaTime;
        if (tick >= _shootInterval)
        {
            if (_detectEnemy.nearestEnemy != null)
            {
                GameObject newBullet = Instantiate(_bulletPrefab, _bulletParent);
                newBullet.transform.position = transform.position;
                newBullet.transform.up = _detectEnemy.nearestEnemy.position - transform.position;
                newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.up * 2;
                tick = 0;
            }
        }
    }
}
