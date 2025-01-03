using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] protected AudioMixer audioMixer;
    [SerializeField] private Slider musicVolumeController;
    [SerializeField] private Slider SFXVolumeController;
    private const string MUSIC_VOLUME = "MusicVolume";
    private const string SFX_VOLUME = "SFXVolume";
    private void Start()
    {
        LoadVolume();
    }

    private void Update()
    {
        SetMusicVolume();
        SetSFXVolume();
    }

    private void LoadVolume()
    {
        LoadMusicVolume();
        LoadSFXVolume();
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicVolumeController.value;
        // Chuyển đổi giá trị từ 0-1 thành -80db đến 0dB
        audioMixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(musicVolume)*20f);
        PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);
    }

    public void SetSFXVolume()
    {
        float sfxVolume = SFXVolumeController.value;
        // Chuyển đổi giá trị từ 0-1 thành -80db đến 0dB
        audioMixer.SetFloat(SFX_VOLUME, Mathf.Log10(sfxVolume) * 20f);
        PlayerPrefs.SetFloat(SFX_VOLUME, sfxVolume);
    }

    private void LoadSFXVolume()
    {
        if (PlayerPrefs.HasKey(SFX_VOLUME))
        {
            SFXVolumeController.value = PlayerPrefs.GetFloat(SFX_VOLUME);
            SetSFXVolume();
        }
    }
    private void LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            musicVolumeController.value = PlayerPrefs.GetFloat(MUSIC_VOLUME);
            SetMusicVolume();
        }
    }
}
