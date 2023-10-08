using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _audioSource;
    public SettingsController _settingsController;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Play();
        SettingsController.NewSettings += Play;
    }

    public void Play()
    {
        if (_settingsController.Music)
        {
            _audioSource.Play();
        } else
        {
            _audioSource.Stop();
        }
    }

    private void OnDestroy()
    {
        SettingsController.NewSettings -= Play;
    }
}
