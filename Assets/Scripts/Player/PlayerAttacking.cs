using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] Transform _bulletParent;
    public DetectEnemy DetectEnemy;

    float[] _bulletTimers;
    bool[] _bulletUnlocked;
    float[] _bulletBonusDamage;

    List<BulletInfo> _bulletInfos;

    int overallBonusDamage;


    private void Start()
    {
        _bulletInfos = GameInformation.Instance.bulletInfos;
        _bulletTimers = new float[_bulletInfos.Count];
        _bulletUnlocked = new bool[_bulletInfos.Count];
        _bulletBonusDamage = new float[_bulletInfos.Count];

        _bulletUnlocked[_bulletInfos.FindIndex(x => x.type == BulletType.Normal)] = true;

        overallBonusDamage = 0;
    }

    void Update()
    {
        for (int i = 0; i < _bulletInfos.Count; i++)
        {
            if (!_bulletUnlocked[i]) continue;

            _bulletTimers[i] += Time.deltaTime;
            if (_bulletTimers[i] >= _bulletInfos[i].shootInterval)
            {
                if (DetectEnemy.nearestEnemy != null)
                {
                    Bullet newBullet = Instantiate(_bulletInfos[i].prefab, transform.position, Quaternion.identity, _bulletParent);
                    newBullet.Init(_bulletInfos[i], DetectEnemy.nearestEnemy, _bulletBonusDamage[i] + overallBonusDamage);
                    _bulletTimers[i] = 0;
                }
            }
        }
    }

    public void AddOverallBonusDamage(int value)
    {
        overallBonusDamage += value;
    }

    public bool IsBulletUnlocked(BulletType bulletType)
    {
        if (!_bulletInfos.Exists(x => x.type == bulletType)) return false;  //for unimplemented bullets
        return _bulletUnlocked[_bulletInfos.FindIndex(x => x.type == bulletType)];
    }

    public void UnlockBullet(BulletType bulletType)
    {
        if (!_bulletInfos.Exists(x => x.type == bulletType)) return;  //for unimplemented bullets

        _bulletUnlocked[_bulletInfos.FindIndex(x => x.type == bulletType)] = true;
    }

    public void AddBulletBonusDamage(BulletType bulletType, float value)
    {
        if (!_bulletInfos.Exists(x => x.type == bulletType)) return;  //for unimplemented bullets

        _bulletBonusDamage[_bulletInfos.FindIndex(x => x.type == bulletType)] += value;
    }
}
