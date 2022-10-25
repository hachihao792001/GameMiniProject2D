using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] Transform _bulletParent;
    [SerializeField] DetectEnemy _detectEnemy;

    float[] _bulletTimers;

    List<BulletInfo> _bulletInfos;

    private void Start()
    {
        _bulletInfos = GameInformation.Instance.bulletInfos;
        _bulletTimers = new float[_bulletInfos.Count];
    }

    void Update()
    {
        for (int i = 0; i < _bulletInfos.Count; i++)
        {
            _bulletTimers[i] += Time.deltaTime;
            if (_bulletTimers[i] >= _bulletInfos[i].shootInterval)
            {
                if (_detectEnemy.nearestEnemy != null)
                {
                    Bullet newBullet = Instantiate(_bulletInfos[i].prefab, transform.position, Quaternion.identity, _bulletParent);
                    newBullet.Init(_bulletInfos[i], _detectEnemy.nearestEnemy);
                    _bulletTimers[i] = 0;
                }
            }
        }
    }
}
