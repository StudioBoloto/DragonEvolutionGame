using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }
    private const float DefaultVolume = 0.5f;
    private float _volume = DefaultVolume;
    public float Volume
    {
        get { return _volume; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        audioSource.volume = DefaultVolume;
    }

    public void SetVolume(float volume)
    {
        _volume = volume;
        audioSource.volume = _volume;
    }
}
