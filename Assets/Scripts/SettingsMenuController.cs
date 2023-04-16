using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] SoundManager soundManager;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        soundManager.SetVolume(volume);
    }
}

