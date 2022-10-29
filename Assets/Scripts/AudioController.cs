using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Audio
{
    EnemyHurt,
    ShootNormal,
    ShootBoomearang,
    ShootBall,
    PlayerHurt1,
    PlayerHurt2,
    Explosion,
    PickUpXP,
    ButtonClick,
}

[Serializable]
public class AudioInfo
{
    public Audio audio;
    public AudioClip audioClip;
    public AudioSource audioSrc;
}

public class AudioController : MonoSingleton<AudioController>
{
    public List<AudioInfo> AudioInfos;

    private void Awake()
    {
        for (int i = 0; i < AudioInfos.Count; i++)
        {
            AudioInfos[i].audioSrc = gameObject.AddComponent<AudioSource>();
            AudioInfos[i].audioSrc.clip = AudioInfos[i].audioClip;
        }
    }

    public void PlayAudio(Audio audio)
    {
        AudioInfos.Find(x => x.audio == audio).audioSrc.Play();
    }
}
