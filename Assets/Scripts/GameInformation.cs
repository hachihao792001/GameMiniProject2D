using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoSingleton<GameInformation>
{
    public BulletInfo[] bulletInfos;
    public int[] levelXPs;
}
