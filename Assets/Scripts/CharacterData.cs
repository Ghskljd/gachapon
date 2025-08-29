using UnityEngine;

[System.Serializable]
public class CharacterData
{
    private string ID;
    private int count;

    public CharacterData(string ID, int count)
    {
        this.ID = ID;
        this.count = count;
    }

    public int GetCount()
    {
        return count;
    }

    public string GetID()
    {
        return ID;
    }
}
