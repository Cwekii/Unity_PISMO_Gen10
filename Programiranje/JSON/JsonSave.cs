using System;
using UnityEngine;
using System.IO;

public class JsonSave : MonoBehaviour
{
    #region Variables
    public static JsonSave instance;
    
    [SerializeField] private Data data = new Data();
    private string filePath;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        instance = this;  
        filePath = Application.persistentDataPath + "/data.json";
        
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
            
            Debug.Log($"File Created at {filePath}");
        }

        else
        {
            Load();
        }
    }

    void OnApplicationQuit()
    {
        Save(); 
    }
    #endregion

    #region Save/Load
    public void Save()
    {
        if (data == null)
        {
            Debug.LogError("Data is null");
            
            return; 
        }
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        
        Debug.Log("Data Saved");
    }

    public void Load()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found");
            
            return;
        }
        
        string json = File.ReadAllText(filePath);
        data = JsonUtility.FromJson<Data>(json);
        
        Debug.Log($"Data loaded: {json}");
    }
    #endregion

    #region Get/Set
    public void SetScore(int scoreToAdd)
    {
        data.score = scoreToAdd;
    }

    public void SetName(string name)
    {
        data.playerName = name;
    }

    public void SetPassword(string password)
    {
        data.password = password;
    }

    public string GetName()
    {
        return data.playerName;
    }

    public int GetScore()
    {
        return data.score;
    }

    public string GetPassword()
    {
        return data.password;
    }
    #endregion

    public bool CheckPassword(string inputPassword)
    {
        if(String.IsNullOrEmpty(data.password))
        {
            Debug.Log("Password doesen't exist");
            return false;
        }    

        if (String.Equals(data.password, inputPassword))
        {
            Debug.Log("Password is correct!");
            return true;
        }

        else
        {
            Debug.LogError("Password is incorrect!");
            return false;
        }
    }
}

[Serializable]
public class Data
{
    public int score;
    public string playerName;
    public string password;
    public string theTruth;
    public Vector3[] coinPositions;
}



