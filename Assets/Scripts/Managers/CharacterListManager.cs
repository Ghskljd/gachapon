using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterListManager : MonoBehaviour
{
    public static CharacterListManager Instance { get; private set; }

    //TESTING PURPOSES REMOVE LATER
    [SerializeField]
    private TMP_Text textMeshProGui;

    [SerializeField]
    private List<Characters_SO> AllCharacters_SO;
    public Dictionary<Characters_SO, int> PlayerCollection { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Character List Manager instance!");
        }

        Instance = this;

        PlayerCollection = SaveSystem.loadCharacters() ?? new Dictionary<Characters_SO, int>();
        CheckIfAllCharacters();
    }

    void Update()
    {
        string buh = "";
        foreach (KeyValuePair<Characters_SO, int> keyValuePair in PlayerCollection)
        {
            buh += keyValuePair.Key.name + " " + keyValuePair.Value + "\n";
        }

        textMeshProGui.text = buh;
    }

    public void OnApplicationQuit()
    {
        SaveSystem.SaveCharacters(PlayerCollection);
    }

    public Characters_SO GetCharacterByID(string ID)
    {
        return AllCharacters_SO.Find(x => x.ID == ID);
    }

    private void CheckIfAllCharacters()
    {
        foreach (Characters_SO characters_SO in AllCharacters_SO)
        {
            if (!PlayerCollection.ContainsKey(characters_SO))
            {
                PlayerCollection.Add(characters_SO, 0);
            }
        }
    }

    public void AddToPlayerCollection(Characters_SO characters_SO)
    {
        PlayerCollection[characters_SO]++;
    }

    public void RemoveFromPlayerCollection(Characters_SO characters_SO)
    {
        if (PlayerCollection[characters_SO] > 0)
        {
            PlayerCollection[characters_SO]--;
        }
    }
}
