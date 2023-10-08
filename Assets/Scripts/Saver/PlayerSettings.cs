using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSettings
{
    public static Dictionary<string, int> GetSoundSettings()
    {
        Dictionary<string, int> soundSettings = new Dictionary<string, int>();
        soundSettings["sound"] = PlayerPrefs.GetInt("sound", 1);
        soundSettings["music"] = PlayerPrefs.GetInt("music", 1);
        return soundSettings;
    }

    public static int GetMoneyData()
    {
        return PlayerPrefs.GetInt("Money", 400);
    }
}
