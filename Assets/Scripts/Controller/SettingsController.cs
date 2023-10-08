using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SettingsController : MonoBehaviour
{
    public static Action NewSettings;
    public static SettingsController Instance;
    public bool Sound;
    public bool Music;

    private void Awake()
    {
        Instance = this;
        LoadSettings();
    }

    private void LoadSettings()
    {
        Dictionary<string, int> data = PlayerSettings.GetSoundSettings();

        if (data["sound"] == 0)
        {
            Sound = false;
        } else
        {
            Sound = true;
        }

        if (data["music"] == 0)
        {
            Music = false;
        }
        else
        {
            Music = true;
        }

        NewSettings?.Invoke();
    }

    public void SaveNewSettings(Dictionary<string, int> newSettings)
    {
        foreach (var item in newSettings)
        {
            PlayerPrefs.SetInt(item.Key, item.Value);
        }

        PlayerPrefs.Save();

        LoadSettings();
    }
}
