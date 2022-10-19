using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Normal
}

[CreateAssetMenu(fileName = "BulletInfo", menuName = "ScriptableObjects/BulletInfo")]
public class BulletInfo : ScriptableObject
{
    public BulletType type;
    public string description;
    public float shootInterval;
    public Sprite image;
    public Bullet prefab;
}
