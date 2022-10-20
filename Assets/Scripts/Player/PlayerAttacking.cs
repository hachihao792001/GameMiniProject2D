using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] Transform _bulletParent;
    [SerializeField] DetectEnemy _detectEnemy;

    float[] _bulletTimers;

    private void Start()
    {
        _bulletTimers = new float[GameInformation.Instance.bulletInfos.Length];
    }

    void Update()
    {
        for (int i = 0; i < GameInformation.Instance.bulletInfos.Length; i++)
        {
            _bulletTimers[i] += Time.deltaTime;
            if (_bulletTimers[i] >= GameInformation.Instance.bulletInfos[i].shootInterval)
            {
                if (_detectEnemy.nearestEnemy != null)
                {
                    Bullet newBullet = Instantiate(GameInformation.Instance.bulletInfos[i].prefab, transform.position, Quaternion.identity, _bulletParent);
                    newBullet.Init(GameInformation.Instance.bulletInfos[i], _detectEnemy.nearestEnemy);
                    _bulletTimers[i] = 0;
                }
            }
        }
    }
}
