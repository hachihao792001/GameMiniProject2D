using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string XP_TAG = "XP";

    public Camera MainCamera;
    public Transform Canvas;
    public Player Player;
    public GameObject XPPrefab;
    public DamageTextController DamageTextController;
}

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T s_singleton;
    public static T Instance
    {
        get
        {
            if (s_singleton == null)
            {
                AssignSingleton(FindObjectOfType<T>());
            }
            return s_singleton;
        }
    }

    private static void AssignSingleton(T instance)
    {
        s_singleton = instance;
        DontDestroyOnLoad(s_singleton);
    }

    private void Awake()
    {
        if (s_singleton == null)
        {
            AssignSingleton((T)(MonoBehaviour)this);
        }
        else if (s_singleton != this)
        {
            Destroy(gameObject);
        }
    }
}