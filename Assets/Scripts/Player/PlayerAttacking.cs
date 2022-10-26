using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BulletBonusStat
{
    public float damage;
    public float affectArea;
    public bool shootOpposite;
}

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] Transform _bulletParent;
    public DetectEnemy DetectEnemy;

    float[] _bulletTimers;
    bool[] _bulletUnlocked;
    BulletBonusStat[] _bulletBonusStats;

    List<BulletInfo> _bulletInfos;

    public int overallBonusDamage;
    private void Start()
    {
        _bulletInfos = GameInformation.Instance.bulletInfos;
        _bulletTimers = new float[_bulletInfos.Count];
        _bulletUnlocked = new bool[_bulletInfos.Count];
        _bulletBonusStats = new BulletBonusStat[_bulletInfos.Count];

        UnlockBullet(BulletType.Normal);

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
                    newBullet.Init(_bulletInfos[i], DetectEnemy.nearestEnemy.position, _bulletBonusStats[i]);

                    if (_bulletBonusStats[i].shootOpposite)
                    {
                        newBullet = Instantiate(_bulletInfos[i].prefab, transform.position, Quaternion.identity, _bulletParent);
                        newBullet.Init(_bulletInfos[i], transform.position + (transform.position - DetectEnemy.nearestEnemy.position), _bulletBonusStats[i]);
                    }

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

        _bulletBonusStats[_bulletInfos.FindIndex(x => x.type == bulletType)].damage += value;
    }

    public void AddBulletAffectArea(BulletType bulletType, float value)
    {
        if (!_bulletInfos.Exists(x => x.type == bulletType)) return;  //for unimplemented bullets

        _bulletBonusStats[_bulletInfos.FindIndex(x => x.type == bulletType)].affectArea += value;
    }

    public void SetBulletShootOpposite(BulletType bulletType)
    {
        if (!_bulletInfos.Exists(x => x.type == bulletType)) return;  //for unimplemented bullets

        _bulletBonusStats[_bulletInfos.FindIndex(x => x.type == bulletType)].shootOpposite = true;
    }
}
