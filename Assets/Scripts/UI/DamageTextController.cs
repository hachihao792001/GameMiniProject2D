using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
    [SerializeField] DamageText _damageTextPrefab;
    [SerializeField] Transform _damageTextParent;

    public void SpawnNewText(Vector3 worldPos, float damage)
    {
        Vector2 screenPos = GameController.Instance.MainCamera.WorldToScreenPoint(worldPos);
        DamageText newDamageText = Instantiate(_damageTextPrefab, screenPos, Quaternion.identity, _damageTextParent);
        newDamageText.Init(damage);
    }
}
