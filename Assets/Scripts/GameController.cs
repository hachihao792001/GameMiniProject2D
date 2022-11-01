using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public LayerMask PlayerLayerMask;

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
    public Button PauseButton;
    public Button ResumeButton;
    public bool IsPause = false;

    protected override void Awake()
    {
        base.Awake();
        currentStage = (Stage)PlayerPrefs.GetInt("stage", (int)Stage.DeathCity);
    }

    private void Start()
    {
        RainEffect.SetActive(currentStage == Stage.CloudyPark);
        DarkSky.SetActive(currentStage == Stage.CloudyPark);
        float ratio = (float)Screen.width / Screen.height;
        if (ratio > 1.5f)
        {
            MainCamera.orthographicSize = 2.5f;
        }
        else
        {
            MainCamera.orthographicSize = 5f;
        }
    }

    public void NextStage()
    {
        currentStage++;
        PlayerPrefs.SetInt("stage", (int)currentStage);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPause)
            {
                PauseButton.onClick.Invoke();
            }
            else
            {
                ResumeButton.onClick.Invoke();
            }
        }
    }
}
