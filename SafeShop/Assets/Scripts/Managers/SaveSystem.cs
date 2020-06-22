using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
  private static string SavePath()
    {
        return Application.persistentDataPath + "/level.io";         
    }
    public static void CreateSaveLevelFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = SavePath();
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData lvlData= new LevelData(0);
        formatter.Serialize(stream, lvlData);
        stream.Close();
        Debug.Log("File created");

    }

        public static void SaveLevelAt (LevelData lvlData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = SavePath();
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        formatter.Serialize(stream, lvlData);
        stream.Close();
        //Debug.Log("File saved");
    }

    public static LevelData LoadLevelData()
    {
        string path = SavePath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            //Debug.Log("File loaded");
            return data;
        }
        else
        {
            Debug.LogError("Save not found");
            return null;
        }
    }
}
