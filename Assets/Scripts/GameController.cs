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
    public PopupChooseSkillController PopupChooseSkillController;
}
