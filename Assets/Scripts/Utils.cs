using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Utils : MonoBehaviour
{
    public static List<T> GetListEnum<T>()
    {
        return new List<T>((T[])Enum.GetValues(typeof(T)));
    }

    public static List<T> GetNRandomElements<T>(List<T> list, int n)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < n; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            result.Add(list[randomIndex]);
            list.RemoveAt(randomIndex);
        }
        return result;
    }

    public static bool LayerInLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}
