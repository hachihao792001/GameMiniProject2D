using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Audio
{
    EnemyHurt1,
    ShootNormal,
    ThrowSomething,
    PlayerHurt1,
    PlayerHurt2,
    Explosion,
    PickUpXP,
    ButtonClick,
    RangedEnemyShoot,
    EnemyHurt2,
    HomeMusic,
    GameMusic
}

[Serializable]
public class AudioInfo
{
    public Audio audio;
    public AudioClip audioClip;
    public AudioSource audioSrc;
    public bool looping;
    public float volume = 1;
}

public class AudioController : MonoSingleton<AudioController>
{
    public List<AudioInfo> AudioInfos;

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < AudioInfos.Count; i++)
        {
            AudioInfos[i].audioSrc = gameObject.AddComponent<AudioSource>();
            AudioInfos[i].audioSrc.clip = AudioInfos[i].audioClip;
            AudioInfos[i].audioSrc.loop = AudioInfos[i].looping;
            AudioInfos[i].audioSrc.volume = AudioInfos[i].volume;
        }
    }

    public void PlayAudio(Audio audio)
    {
        AudioSource audioSrc = AudioInfos.Find(x => x.audio == audio).audioSrc;
        if (!audioSrc.isPlaying)
            audioSrc.Play();
    }

    public void StopAudio(Audio audio)
    {
        AudioInfos.Find(x => x.audio == audio).audioSrc.Stop();
    }

    public void PlayRandomPlayerHurt()
    {
        PlayAudio(Random.Range(0, 2) == 0 ? Audio.PlayerHurt1 : Audio.PlayerHurt2);
    }

    public void PlayRandomEnemyHurt()
    {
        PlayAudio(Random.Range(0, 2) == 0 ? Audio.EnemyHurt1 : Audio.EnemyHurt2);

    }
}
