using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct XPSprite
{
    public int amount;
    public Sprite sprite;
}

public class GameController : OneSceneMonoSingleton<GameController>
{
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string XP_TAG = "XP";

    public LayerMask EnemyLayerMask;
    public LayerMask BallHitLayerMask;

    public Camera MainCamera;
    public Transform Canvas;
    public Player Player;
    public XP XPPrefab;
    public DamageTextController DamageTextController;
    public PopupChooseSkillController PopupChooseSkillController;

    public GameObject RainEffect;
    public GameObject DarkSky;

    public List<XPSprite> xpSprites;

    public Stage currentStage;

    public Action onPlayerLevelUp;

    protected override void Awake()
    {
        base.Awake();
        currentStage = (Stage)PlayerPrefs.GetInt("stage", (int)Stage.DeathCity);
    }

    private void Start()
    {
        RainEffect.SetActive(currentStage == Stage.CloudyPark);
        DarkSky.SetActive(currentStage == Stage.CloudyPark);
    }
}
