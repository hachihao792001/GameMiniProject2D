using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : OneSceneMonoSingleton<GameController>
{
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string XP_TAG = "XP";

    public LayerMask EnemyLayerMask;

    public Camera MainCamera;
    public Transform Canvas;
    public Player Player;
    public GameObject XPPrefab;
    public DamageTextController DamageTextController;
    public PopupChooseSkillController PopupChooseSkillController;

    public Stage currentStage;

    public Action onPlayerLevelUp;

    protected override void Awake()
    {
        base.Awake();
        currentStage = (Stage)PlayerPrefs.GetInt("stage", (int)Stage.DeathCity);
    }
}
