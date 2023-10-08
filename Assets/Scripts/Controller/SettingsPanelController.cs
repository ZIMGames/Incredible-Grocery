using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelController : MonoBehaviour
{
    [SerializeField] private Sprite OnSpr, OffSpr;
    [SerializeField] private Image SoundImg, MusicImg;
    [SerializeField] private Text SoundTxt, MusicTxt;

    private Dictionary<string, int> data;


    private void OnEnable()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        data = PlayerSettings.GetSoundSettings();

        ChangeButsVisual(data);
    }

    public void ChangeValue(string type)   // sound or music
    {
        PlaySound.Instance.Play("button");

        if (data[type] == 0)
        {
            data[type] = 1;
        } else
        {
            data[type] = 0;
        }

        ChangeButsVisual(data);
    }

    private void ChangeButsVisual(Dictionary<string, int> data)
    {
        if (data["sound"] == 0)
        {
            SoundImg.sprite = OffSpr;
            SoundTxt.text = "OFF";
        }
        else
        {
            SoundImg.sprite = OnSpr;
            SoundTxt.text = "ON";
        }

        if (data["music"] == 0)
        {
            MusicImg.sprite = OffSpr;
            MusicTxt.text = "OFF";
        }
        else
        {
            MusicImg.sprite = OnSpr;
            MusicTxt.text = "ON";
        }
    }

    public void SaveNewValues()
    {
        SettingsController.Instance.SaveNewSettings(data);
        ClosePanel();
    }
    public void ClosePanel()
    {
        PlaySound.Instance.Play("button");
        gameObject.SetActive(false);
    }
}
