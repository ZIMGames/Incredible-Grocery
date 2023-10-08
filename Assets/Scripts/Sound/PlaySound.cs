using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public static PlaySound Instance;

    public List<string> keys = new List<string>();
    public List<AudioClip> values = new List<AudioClip>();

    private AudioSource _audioSource;
    public SettingsController _settingsController;

    private void Start()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(string soundName)
    {
        if (_settingsController.Sound)
        {
            int index = keys.IndexOf(soundName);

            if (index != -1 && index < values.Count)
            {
                _audioSource.clip = values[index];
                _audioSource.Play();
            }
        }
    }
}

