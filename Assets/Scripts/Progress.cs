using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Coins;
    public int Width;
    public int Height;
    public int Level;
}

public class Progress : MonoBehaviour
{

    public PlayerInfo PlayerInfo;


    public static Progress Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Load();
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerInfo = new PlayerInfo();
            Save();
        }
    }
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        PlayerPrefs.SetString("PlayerInfo", jsonString);
        PlayerPrefs.Save();
      
    }

    public void Load()
    {
        string jsonString = PlayerPrefs.GetString(key:"PlayerInfo");
        PlayerInfo = new PlayerInfo();
        if (!string.IsNullOrEmpty(jsonString))
        {
            PlayerInfo = JsonUtility.FromJson<PlayerInfo>(jsonString);
        }
    }
}

