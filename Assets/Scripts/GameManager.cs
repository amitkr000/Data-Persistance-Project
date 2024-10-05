using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string inputNameText;
    public string playerName;
    public int highestScore;
    
    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    [Serializable]
    class SaveData{
        public int score;
        public string name;
    }

    public void SaveFile(int score, string name){
        SaveData data = new SaveData();
        data.score = score;
        data.name = name;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadFile(){
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);

        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.name;
            highestScore = data.score;
        }
    }

}
