using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void SaveCharacters(Dictionary<Characters_SO, int> PlayerColletion)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = getCharacterDataPath();
        FileStream stream = new FileStream(path, FileMode.Create);

        List<CharacterData> characterDatas = new List<CharacterData>();

        foreach (KeyValuePair<Characters_SO, int> keyValuePair in PlayerColletion)
        {
            CharacterData data = new CharacterData(keyValuePair.Key.ID, keyValuePair.Value);
            characterDatas.Add(data);
        }

        formatter.Serialize(stream, characterDatas);
        stream.Close();
    }

    public static Dictionary<Characters_SO, int> loadCharacters()
    {
        string path = getCharacterDataPath();
        if (File.Exists(path))
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Length == 0)
            {
                Debug.Log("Save file is empty, returning empty dictionary");
                return new Dictionary<Characters_SO, int>();
            }
            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<CharacterData> data = (List<CharacterData>)formatter.Deserialize(stream);
            stream.Close();

            Dictionary<Characters_SO, int> PlayerCollection = new Dictionary<Characters_SO, int>();
            foreach (CharacterData CharacterData in data)
            {
                PlayerCollection.Add(CharacterListManager.Instance.GetCharacterByID(CharacterData.GetID()), CharacterData.GetCount());
            }
            return PlayerCollection;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    private static string getCharacterDataPath()
    {
        return Application.persistentDataPath + "/characters.data";
    }
}
