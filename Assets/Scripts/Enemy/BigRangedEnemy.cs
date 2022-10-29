using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRangedEnemy : RangedEnemy
{
    public override void ShootBullet()
    {
        if (isInShootingState)
        {
            Vector3 centerVec = GameController.Instance.Player.transform.position - transform.position;
            Vector3 leftVec = Quaternion.Euler(0, 0, -45) * centerVec;
            Vector3 rightVec = Quaternion.Euler(0, 0, 45) * centerVec;

            RangedEnemyBullet newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            newBullet.Init(_bulletDamage, transform.position + centerVec);
            newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            newBullet.Init(_bulletDamage, transform.position + leftVec);
            newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            newBullet.Init(_bulletDamage, transform.position + rightVec);

            AudioController.Instance.PlayAudio(Audio.RangedEnemyShoot);
        }
    }
}
