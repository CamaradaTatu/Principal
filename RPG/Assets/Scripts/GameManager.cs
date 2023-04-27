using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class PlayerData
{ 
    public List<item> playerItemsDB;
    public List<ItemImage> playerItemImages;
    public List<itemInInv> playerItemInInv;
}

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public List<item> playerItemsDB;
    public List<ItemImage> playerItemImages;
    public List<itemInInv> playerItemInInv;

    private string path;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        path = Application.persistentDataPath + "/playerSave.sav";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData();

        data.playerItemsDB = playerItemsDB;
        data.playerItemInInv = playerItemInInv;
        data.playerItemImages = playerItemImages;

        bf.Serialize(file, data);

        file.Close();
    }
    void Load()
    {
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            playerItemsDB = data.playerItemsDB;
            playerItemInInv = data.playerItemInInv;
            playerItemImages = data.playerItemImages;
        }
    }
}
