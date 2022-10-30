using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    public int amount;
    [SerializeField] SpriteRenderer _sr;

    public void Init(int amount)
    {
        this.amount = amount;
        _sr.sprite = GameController.Instance.xpSprites.Find(x => x.amount == amount).sprite;
    }
}
