using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] protected AudioSource musicAudioSource;
    [SerializeField] protected AudioSource sfxAudioSource;

    [SerializeField] protected AudioClip backgroundClip;
    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public void PlaySFX (AudioClip clip)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.PlayOneShot(clip);
    }
}
