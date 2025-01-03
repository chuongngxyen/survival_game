using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameSceneManager : AudioManager
{
    [SerializeField] public AudioClip hitMob;
    [SerializeField] public AudioClip mobPunch;

    protected override void Start()
    {
        base.Start();
        musicAudioSource.clip = backgroundClip;
        musicAudioSource.Play();
    }

    protected override void Update()
    {
        base.Update();
    }
}
