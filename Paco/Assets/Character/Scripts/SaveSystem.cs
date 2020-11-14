using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "player.info";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerStats stats = new PlayerStats(player);

        formatter.Serialize(stream, stats);
        stream.Close();
    }

    public static PlayerStats LoadPlayer()
    {
        string path = Application.persistentDataPath + "player.info";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerStats data = formatter.Deserialize(stream) as PlayerStats;

            stream.Close();

            return data;

        }
        else
        {
            File.Create(path);
            LoadPlayer();
            Debug.LogError("Save file not found : " + path);
            return null;
        }

    }
}
