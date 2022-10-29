using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    None = 0,
    Normal,
    Boomerang,
    Bomb,
    Ball
}

[CreateAssetMenu(fileName = "BulletInfo", menuName = "ScriptableObjects/BulletInfo")]
public class BulletInfo : ScriptableObject
{
    public BulletType type;
    public float shootInterval;
    public float damage;
    public Bullet prefab;
}
