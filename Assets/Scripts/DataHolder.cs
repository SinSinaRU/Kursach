using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour
{
    string filePath;

    public static int lastLVL = 1;
    public static int lastWeapon = 0;
    public static double score = 0;
    public static double[] records;
    public static int compleetedLVLs = 0;
    public static int openedWeapons = 1;

    public void Start()
    {
        records = new double[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            records[i] = 0;
        }
        filePath = Application.persistentDataPath + "/save.gamesave";
        Load();
        Debug.Log("Count of scenes " + records.Length.ToString());
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.gamesave.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.gamesave.gd", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            lastLVL = save.data.lastLVL;
            lastWeapon = save.data.lastWeapon;
            if (records.Length >= save.data.records.Length)
            {
                for (int i = 0; i < save.data.records.Length; i++)
                {
                    records[i] = save.data.records[i];
                }
            }
            else
            {
                for (int i = 0; i < records.Length; i++)
                {
                    records[i] = save.data.records[i];
                }
            }
            compleetedLVLs = save.data.compleetedLVLs;
            openedWeapons = save.data.openedWeapons;
            Debug.Log("LastLVL: " + lastLVL.ToString());
            Debug.Log("lastWeapon: " + lastWeapon.ToString());
            Debug.Log("compleetedLVLs: " + compleetedLVLs.ToString());
            Debug.Log("openedWeapons: " + openedWeapons.ToString());
            

            Debug.Log("Records:");
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                Debug.Log(records[i]);
            }
        }


        /*
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        lastLVL = save.data.lastLVL;
        lastWeapon = save.data.lastWeapon;
        if (records.Length >= save.data.records.Length)
        {
            for (int i = 0; i < save.data.records.Length; i++)
            {
                records[i] = save.data.records[i];
            }
        }
        else
        {
            for (int i = 0; i < records.Length; i++)
            {
                records[i] = save.data.records[i];
            }
        }
        compleetedLVLs = save.data.compleetedLVLs;
        openedWeapons = save.data.openedWeapons;
        Debug.Log("Count of Weapons:" + openedWeapons.ToString());

        Debug.Log("Records:");
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            Debug.Log(records[i]);
        }
        */
    }

    public void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.gamesave.gd");
        Save save = new Save(lastLVL, lastWeapon, records, compleetedLVLs, openedWeapons);
        bf.Serialize(file, save);
        file.Close();
        /*
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save(lastLVL, lastWeapon, records, compleetedLVLs, openedWeapons);

        bf.Serialize(fs, save);

        fs.Close();
        */
    }

    public void ResetProgress()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            records[i] = 0;
        }
        lastLVL = 1;
        lastWeapon = 0;
        score = 0;
        compleetedLVLs = 0;
        openedWeapons = 1;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.gamesave.gd");
        Save save = new Save(lastLVL, lastWeapon, records, compleetedLVLs, openedWeapons);
        bf.Serialize(file, save);
        file.Close();
    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct DATA
    {
        public int lastLVL;
        public int lastWeapon;
        public double[] records;
        public int compleetedLVLs;
        public int openedWeapons;
    }

    public DATA data;

    public Save(int lastLVL, int lastWeapon, double[] records, int compleetedLVLs, int openedWeapons)
    {
        this.data.lastLVL = lastLVL;
        this.data.lastWeapon = lastWeapon;
        this.data.records = new double[records.Length];
        for (int i = 0; i < records.Length; i++)
        {
            this.data.records[i] = records[i];
        }
        this.data.compleetedLVLs = compleetedLVLs;
        this.data.openedWeapons = openedWeapons;
    }
}
