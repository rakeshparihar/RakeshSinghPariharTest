using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PersistentStorage
{
    static string savePath ;
    const string fileName = "SaveData.dat";
    static  PersistentStorage()
    {
        savePath = Path.Combine(Application.persistentDataPath, fileName);
    }

    public static void SaveData(int scoreData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, scoreData);
        file.Close();
    }

    public static int LoadData()
    {
        if (File.Exists(savePath))
        {            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            int bestScore = (int)bf.Deserialize(file);           
            file.Close();
            return bestScore;
        }
        else
            SaveData(0);
        return 0;

    }

}
