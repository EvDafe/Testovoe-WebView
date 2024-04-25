using Assets.CodeBase;
using System;
using TMPro;
using UnityEngine;

public class LoadingService : IService
{
    private const string PlayerProgressKey = "PlayerProgress";

    public PlayerProgress Progress;
    private TMP_Text domenText;

    public LoadingService(TMP_Text domenText)
    {
        this.domenText = domenText;
    }

    public void Load()
    {
        if (PlayerPrefs.GetString(PlayerProgressKey) == null || PlayerPrefs.GetString(PlayerProgressKey).Length == 0)
            Progress = new();
        else
        {
            Progress = PlayerPrefs.GetString(PlayerProgressKey).FromJson<PlayerProgress>();
            domenText.text = PlayerPrefs.GetString(PlayerProgressKey);
            Debug.Log(PlayerPrefs.GetString(PlayerProgressKey));
        }
    }

    public void Save() => 
        PlayerPrefs.SetString(PlayerProgressKey, Progress.ToJson());
}

[Serializable]
public class PlayerProgress
{
    public OnlineData Data;
}