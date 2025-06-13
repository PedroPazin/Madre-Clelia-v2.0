using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer myMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private bool _isDone;
    public int diff = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolumeSFX();
        }
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolumeMusic();
        }

        SetVolumeMusic();
        SetVolumeSFX();
    }

    private void Update()
    {
        if (_isDone) return;

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            float volume = sfxSlider.value;
            myMixer.SetFloat("walking", MathF.Log10(volume - diff) * 20);
            _isDone = true;
        }
    }

    public void SetVolumeMusic()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", MathF.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolumeMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SetVolumeSFX()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("sfx", MathF.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolumeSFX()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }
    
    
}
