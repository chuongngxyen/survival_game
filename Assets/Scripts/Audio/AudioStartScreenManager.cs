using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioStartScreenManager : AudioManager
{
    

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
