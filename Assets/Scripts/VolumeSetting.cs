using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSoundVolume();
            SetSFXVolume();
        }
    }
    public void SetSoundVolume()
    {
        float volume = soundSlider.value;
        myMixer.SetFloat("Sound", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    private void LoadVolume()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetSoundVolume();
        SetSFXVolume();
    }
}
