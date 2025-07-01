using System;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    [SerializeField] string saveKey;

    [SerializeField] PlayerPreferences saveData;

    [SerializeField] bool save;
    [SerializeField] bool load;

    void OnValidate()
    {
        if (save)
        {
            Save();
            save = false;
        }
        if (load)
        {
            Load();
            load = false;
        }

    }

    void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(saveKey, json);
        PlayerPrefs.Save();
    }

    void Load()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            string json = PlayerPrefs.GetString(saveKey);
            saveData = JsonUtility.FromJson<PlayerPreferences>(json);
        }
        else
        {
            saveData = new();
        }
    }
}

[Serializable]
class PlayerPreferences
{
    public float musicVolume;
    public float soundVolume;
    public bool isFullScreen;
    public Vector2Int resolution;
}

[Serializable]
class PlayerProfile
{
    public int level;
    public int score;
    public List<LevelData> levels = new();
}

[Serializable]
class LevelData
{
    public float progress;
    public int score;
}