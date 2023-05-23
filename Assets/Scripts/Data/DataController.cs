using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DataController : MonoBehaviour
{
    public static DataController instance;

    private Data data;
    private int score;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            instance.data = new Data();
            score = 0;
            LoadDate();
        }

        Destroy(gameObject);
    }

    public void SetVolume(float volume)
    {
        data.Volume = volume;
        SaveData();
    }
    public float GetVolume()
    {
        return data.Volume;
    }

    public void SetRecord(int newRecord)
    {
        if (newRecord > data.record)
        {
            data.record = newRecord;
            SaveData();
        }
    }
    public int GetRecord()
    {
        return data.record;
    }
    public void AddScore(int addingscore)
    {
        score += addingscore;
    }
    private void LoadDate()
    {
        if (PlayerPrefs.HasKey("Data"))
        {
            string str = PlayerPrefs.GetString("Data");
            data = JsonUtility.FromJson<Data>(str);
        }
    }

    public void SaveData()
    {
        string str = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Data", str);
    }

}

[Serializable]
public class Data
{
    public int record;
    public float Volume;
}