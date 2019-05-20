using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    private string fileName = "GameData.json";
    private string filePath;

    private static SaveLoad _instance;

    public static SaveLoad Instance
    {
        get { return _instance; }
        //set { _instance = value; }
    }

    public GameData gameData;

    private void Awake()
    {
       DontDestroyOnLoad(gameObject);

        if (_instance == null)
        {
            _instance = new SaveLoad();
        }

        if (gameObject==null)
        {
            gameData = new GameData();
        }

        filePath = Path.Combine(Application.dataPath, fileName);
    }

    private void Start()
    {
        LoadGameData();
    }

    void LoadGameData()
    {
        string json;

        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.Log("File is missing: " + filePath);
        }
    }

    void SaveGameData()
    {
        string json = JsonUtility.ToJson(gameData);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
        
        File.WriteAllText(filePath, json);
    }

    [System.Serializable]

    public class GameData
    {
        public string saveName;
    }
}

